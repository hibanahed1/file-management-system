using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileManagementSystem.Domain.Entities
{
    public class FileItem
    {
        [Key]
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public long Size { get; set; }

        public byte[] Content { get; set; } // BLOB in DB

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Add this constructor
        public FileItem(string fileName, long size, byte[] content)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            Size = size;
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

        // Parameterless constructor is still needed by EF
        public FileItem() { }
    }
}
