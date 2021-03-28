using CleanArchitecture.Application.Quieries.Desire;
using FluentValidation;

namespace PushNotificationService.Application.NotificationResponses.Queries.GetNotificationResponses
{
    public class GetDesiresQueryValidator : AbstractValidator<GetDesireQuery>
    {
        public GetDesiresQueryValidator()
        {
        }
    }
}
