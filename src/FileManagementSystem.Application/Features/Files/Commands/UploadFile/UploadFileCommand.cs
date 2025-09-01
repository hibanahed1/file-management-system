using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace FileManagementSystem.Application.Features.Files.Commands.UploadFile
{
    public class UploadFileCommand : IRequest<Guid>
    {
        public IFormFile File { get; set; }

        public UploadFileCommand() { }
    }
}
