using FileManagementSystem.Domain.Entities;
using MediatR;

namespace FileManagementSystem.Application.Features.Files.Queries.GetFiles;

public record GetAllFilesQuery() : IRequest<List<FileItem>>;
