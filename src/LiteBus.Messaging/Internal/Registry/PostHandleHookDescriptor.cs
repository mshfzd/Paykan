﻿using System;
using LiteBus.Messaging.Abstractions;

namespace LiteBus.Messaging.Internal.Registry
{
    internal class PostHandleHookDescriptor : IHookDescriptor
    {
        public PostHandleHookDescriptor(Type hookType)
        {
            if (hookType.GetGenericTypeDefinition().IsAssignableTo(typeof(IPostHandleHook<>)))
            {
                throw new NotSupportedException($"{nameof(hookType)} is not valid pre handle hook type.");
            }
            
            HookType = hookType;

            MessageType = hookType.GetGenericArguments()[0];

            HookOrderAttribute hookOrderAttribute =
                (HookOrderAttribute) Attribute.GetCustomAttribute(hookType, typeof(HookOrderAttribute));

            if (hookOrderAttribute is not null)
            {
                Order = hookOrderAttribute.Order;
            }
        }

        public Type HookType { get; }

        public int Order { get; }

        public Type MessageType { get; }
    }
}