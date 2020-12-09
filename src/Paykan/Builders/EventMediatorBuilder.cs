﻿using System;
using Paykan.Abstractions;
using Paykan.Internal;
using Paykan.Internal.Mediators;

namespace Paykan.Builders
{
    public class EventMediatorBuilder
    {
        public IEventMediator Build(IServiceProvider serviceProvider,
                                    IMessageRegistry messageRegistry)
        {
            return new EventMediator(serviceProvider, messageRegistry);
        }
    }
}