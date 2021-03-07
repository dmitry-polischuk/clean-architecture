using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyCqrs.Application.Authorization;

namespace PushNotificationService.Application.Common.Authorization.Filters
{
    public class HasScopeFilter : IAuthorizationFilter
    {
        private readonly Scopes[] _scopes;

        public HasScopeFilter(params Scopes[] scopes)
        {
            _scopes = scopes;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (null != context)
            {
                foreach (var requiredScope in _scopes)
                {
                    
                    var userScope = context.HttpContext.User.FindFirst(c => c.Type.ToLower() == "scope" &&
                                    c.Value.ToLower() == requiredScope.ToString().ToLower());
                    if (null == userScope)
                    {
                        context.Result = new ForbidResult();
                    }

                }

            }
        }
    }
}
