﻿using System;
using Paykan.Abstractions;
using Paykan.Internal;
using Paykan.Internal.Mediators;

namespace Paykan.Builders
{
    public class QueryMediatorBuilder
    {
        public IQueryMediator Build(IServiceProvider serviceProvider, 
                                    IMessageRegistry messageRegistry)
        {
            return new QueryMediator(serviceProvider, messageRegistry);
        }
    }
}