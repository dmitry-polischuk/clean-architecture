﻿using CleanArchitecture.Application.Common.Strings;
using CleanArchitecture.Application.Quieries.Desire;
using FluentValidation;

namespace PushNotificationService.Application.NotificationResponses.Queries.GetNotificationResponses
{
    public class GetDesiresQueryValidator : AbstractValidator<GetDesireQuery>
    {
        public GetDesiresQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.UserId)))
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.UserId)));
        }
    }
}
