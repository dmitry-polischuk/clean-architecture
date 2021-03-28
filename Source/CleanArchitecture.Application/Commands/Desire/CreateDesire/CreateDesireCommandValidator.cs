using FluentValidation;
using CleanArchitecture.Application.Commands.Desire.CreateDesire;
using CleanArchitecture.Application.Common.Strings;

namespace CleanArchitecture.Application.Desires.Command.CreateDesire
{
    public class CreateDesireCommandValidator : AbstractValidator<CreateDesireCommand>
    {
        public CreateDesireCommandValidator()
        {
            RuleFor(x => x.Dto.Name)
                .MaximumLength(255).WithMessage(x => string.Format(ErrorStrings.MaxLengthExceeded, nameof(x.Dto.Name), 255));   
        }
    }
}
