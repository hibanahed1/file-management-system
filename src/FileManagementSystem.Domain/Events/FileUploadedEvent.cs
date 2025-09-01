using System;
using FileManagementSystem.Domain.Entities;

namespace FileManagementSystem.Domain.Events
{
    public class FileUploadedEvent : IDomainEvent
    {
        public FileItem File { get; }
        public DateTime OccurredOn { get; }

        public FileUploadedEvent(FileItem file)
        {
            File = file;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
