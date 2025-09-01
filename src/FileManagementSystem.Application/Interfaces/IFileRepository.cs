using FileManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManagementSystem.Application.Interfaces
{
    public interface IFileRepository
    {
        Task<FileItem> AddAsync(FileItem file);
        Task<List<FileItem>> GetAllAsync();
        Task<FileItem> GetByIdAsync(Guid id);
        Task DeleteAsync(FileItem file);

    }
}
