using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Careerio.Models;
using System.Security.Claims;

namespace Careerio.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Company>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Company company)
        {
            if (requirement.ResourceOperation == ResourceOperation.Create || requirement.ResourceOperation == ResourceOperation.Read)
            {
                context.Succeed(requirement);
            }

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role).Value;

           
            if (company.CreatedById == int.Parse(userId) || role == "Admin")
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;


        }
    }
}
