using Microsoft.AspNetCore.Mvc;
using MyCqrs.Application.Authorization;
using PushNotificationService.Application.Common.Authorization.Filters;

namespace PushNotificationService.Application.Common.Authorization.Attributes
{
    public class HasScopeAttribute : TypeFilterAttribute
    {
        public HasScopeAttribute(params Scopes[] scopes) : base(typeof(HasScopeFilter))
        {
            Arguments = new object[] { scopes };
        }
    }
}
