using CleanArchitecture.Application.Common.Strings;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Quieries.User.GetUser
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.UserId)))
                .NotNull().WithMessage(x => string.Format(ErrorStrings.PropertyMissing, nameof(x.UserId)));
        }
    }
}
