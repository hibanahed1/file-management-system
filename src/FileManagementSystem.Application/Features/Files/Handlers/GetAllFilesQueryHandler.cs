using FileManagementSystem.Application.Features.Files.Queries.GetFiles;
using FileManagementSystem.Application.Interfaces;
using FileManagementSystem.Domain.Entities;
using MediatR;

namespace FileManagementSystem.Application.Handlers;

public class GetAllFilesQueryHandler : IRequestHandler<GetAllFilesQuery, List<FileItem>>
{
    private readonly IFileRepository _repository;

    public GetAllFilesQueryHandler(IFileRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FileItem>> Handle(GetAllFilesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
