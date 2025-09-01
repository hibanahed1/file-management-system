using FileManagementSystem.Application.Features.Files.Commands.UploadFile;
using FileManagementSystem.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/files")]
public class FilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload([FromForm] UploadFileCommand command)
    {
        if (command.File == null)
            return BadRequest("No file uploaded");

        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IFileRepository repo)
    {
        var files = await repo.GetAllAsync();
        return Ok(files);
    }

    [HttpGet("download/{id}")]
    public async Task<IActionResult> Download(Guid id, [FromServices] IFileRepository repo)
    {
        var file = await repo.GetByIdAsync(id);
        if (file == null) return NotFound();

        return File(file.Content, "application/octet-stream", file.FileName);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromServices] IFileRepository repo)
    {
        var file = await repo.GetByIdAsync(id);
        if (file == null)
            return NotFound();

        await repo.DeleteAsync(file);
        return NoContent();
    }
}
