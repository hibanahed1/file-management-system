using MediatR;

namespace FileManagementSystem.Application.Commands;

public record CreateFileCommand(string Name, long Size, string Path) : IRequest<Guid>;
