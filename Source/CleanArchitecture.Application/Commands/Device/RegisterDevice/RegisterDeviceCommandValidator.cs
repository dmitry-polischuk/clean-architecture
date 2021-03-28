using FluentValidation;
using CleanArchitecture.Application.Common.Strings;

namespace CleanArchitecture.Application.CQRS.Devices.Command.RegisterDevice
{
    public class RegisterDeviceCommandValidator : AbstractValidator<RegisterDeviceCommand>
    {
        public RegisterDeviceCommandValidator()
        {
            RuleFor(x => x.Dto.DeviceId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyEmpty, nameof(x.Dto.DeviceId)))
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.Dto.DeviceId)));

            RuleFor(x => x.Dto.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.Dto.UserId)))
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyEmpty, nameof(x.Dto.UserId)));
        }
    }
}
