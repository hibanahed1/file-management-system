// using FileManagementSystem.Application.Commands;
// using FileManagementSystem.Application.Interfaces;
// using FileManagementSystem.Domain.Entities;
// using MediatR;

// namespace FileManagementSystem.Application.Handlers;

// public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Guid>
// {
//     private readonly IFileRepository _repository;

//     public CreateFileCommandHandler(IFileRepository repository)
//     {
//         _repository = repository;
//     }

//     public async Task<Guid> Handle(CreateFileCommand request, CancellationToken cancellationToken)
//     {
//         // Create FileItem entity using all required parameters
//         var file = new FileItem(request.Name, request.Size, request.Path);

//         await _repository.AddAsync(file);

//         return file.Id;
//     }
// }
