﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Careerio.Authorization
{
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation ResourceOperation { get; }
        public ResourceOperationRequirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }

    }
}
