using FileManagementSystem.Application.Commands;
using FluentValidation;

namespace FileManagementSystem.Application.Validators;

public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
{
    public CreateFileCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("File name is required");
        RuleFor(x => x.Path).NotEmpty().WithMessage("File path is required");
        RuleFor(x => x.Size).GreaterThan(0).WithMessage("File size must be greater than 0");
    }
}
