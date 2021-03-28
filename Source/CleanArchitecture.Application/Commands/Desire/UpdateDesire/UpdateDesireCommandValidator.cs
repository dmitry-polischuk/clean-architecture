using CleanArchitecture.Application.Common.Strings;
using FluentValidation;
using PushNotificationService.Application.Desires.Command.UpdateDesire;

namespace CleanArchitecture.Application.Commands.Desire.UpdateDesire
{
    public class UpdateDesireCommandValidator : AbstractValidator<UpdateDesireCommand>
    {
        public UpdateDesireCommandValidator()
        {
            RuleFor(x => x.DesireId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.DesireId)))
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.DesireId)));

            RuleFor(x => x.Requestor)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyEmpty, nameof(x.Requestor)))
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.Requestor)))
                .MaximumLength(32).WithMessage(x => string.Format(ErrorStrings.MaxLengthExceeded, nameof(x.Requestor), 32));

        }
    }
}
