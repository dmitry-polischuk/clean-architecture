using Microsoft.AspNetCore.Authorization;
using MyCqrs.Application.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace PushNotificationService.Application.Common.Authorization.Requirements
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public Scopes[] Scopes { get; set; }
        public HasScopeRequirement(params Scopes[] scopes)
        {
            Scopes = scopes ?? throw new ArgumentNullException(nameof(scopes)); ;
        }
    }
}
