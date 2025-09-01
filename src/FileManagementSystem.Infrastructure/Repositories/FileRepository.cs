using FileManagementSystem.Application.Interfaces;
using FileManagementSystem.Domain.Entities;
using FileManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManagementSystem.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext _context;

        public FileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FileItem> AddAsync(FileItem file)
        {
            _context.Files.Add(file);
            await _context.SaveChangesAsync();
            return file;
        }

        public async Task<List<FileItem>> GetAllAsync()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<FileItem> GetByIdAsync(Guid id)
        {
            return await _context.Files.FirstOrDefaultAsync(f => f.Id == id);
        }
        public async Task DeleteAsync(FileItem file)
        {
            _context.Files.Remove(file);
            await _context.SaveChangesAsync();
        }

    }
}
