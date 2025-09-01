namespace FileManagementSystem.Application.DTOs
{
    public record FileDto(Guid Id, string Name, long Size, string Path);
}
