using FluentValidation;
using CleanArchitecture.Application.Common.Strings;

namespace CleanArchitecture.Application.CQRS.Devices.Command.DeleteDevice
{
    public class DeleteDeviceCommandValidator : AbstractValidator<DeleteDeviceCommand>
    {
        public DeleteDeviceCommandValidator()
        {
            RuleFor(v => v.DeviceId)
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.DeviceId)))
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyEmpty, nameof(x.DeviceId)));
        }
    }
}
