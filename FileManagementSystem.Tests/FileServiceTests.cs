using Xunit;
using Moq;
using FileManagementSystem.Infrastructure.Services;
using FileManagementSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using FileManagementSystem.Infrastructure.Data;

public class FileServiceTests
{
    private FileDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<FileDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        return new FileDbContext(options);
    }

    [Fact]
    public async Task UploadFile_Should_Add_File_To_Database()
    {
        // Arrange
        var dbContext = GetDbContext();
        var service = new FileService(dbContext);
        var fileItem = new FileItem { Id = Guid.NewGuid(), FileName = "test.txt", Size = 100 };

        // Act
        await service.AddFileAsync(fileItem);
        var result = await dbContext.FileItems.FirstOrDefaultAsync(f => f.FileName == "test.txt");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("test.txt", result.FileName);
    }

    [Fact]
    public async Task DeleteFile_Should_Remove_File_From_Database()
    {
        // Arrange
        var dbContext = GetDbContext();
        var service = new FileService(dbContext);
        var fileItem = new FileItem { Id = Guid.NewGuid(), FileName = "delete.txt", Size = 200 };

        await service.AddFileAsync(fileItem);

        // Act
        await service.DeleteFileAsync(fileItem.Id);
        var result = await dbContext.FileItems.FindAsync(fileItem.Id);

        // Assert
        Assert.Null(result);
    }
}
