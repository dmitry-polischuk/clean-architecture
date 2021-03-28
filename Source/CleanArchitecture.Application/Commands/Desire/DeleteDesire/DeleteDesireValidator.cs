using CleanArchitecture.Application.Common.Strings;
using FluentValidation;

namespace CleanArchitecture.Application.Commands.Desire.DeleteDesire
{
    public class DeleteDesireValidator : AbstractValidator<DeleteDesireCommand>
    {
        public DeleteDesireValidator()
        {
            RuleFor(x => x.DesireId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.DesireId)))
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.DesireId)));
        }
    }
}
