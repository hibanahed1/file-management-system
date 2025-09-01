using FileManagementSystem.Application.Features.Files.Commands.UploadFile;
using FileManagementSystem.Application.Interfaces;
using FileManagementSystem.Domain.Entities;
using MediatR;
using System.IO;

namespace FileManagementSystem.Application.Features.Files.Handlers
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Guid>
    {
        private readonly IFileRepository _fileRepository;

        public UploadFileCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<Guid> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var file = request.File;
            if (request.File == null)
                throw new ArgumentException("No file provided");

            // Read file into byte array
            byte[] fileContent;
            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms, cancellationToken);
                fileContent = ms.ToArray();
            }

            // Create FileItem with correct types
            var fileItem = new FileItem
            {
                FileName = file.FileName,
                Size = file.Length,
                Content = fileContent
            };

            await _fileRepository.AddAsync(fileItem);

            return fileItem.Id;
        }
    }
}
