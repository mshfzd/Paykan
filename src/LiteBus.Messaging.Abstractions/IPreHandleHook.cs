﻿using System.Threading;
using System.Threading.Tasks;

namespace LiteBus.Messaging.Abstractions
{
    /// <summary>
    ///     Represents an action that is executed on <typeparamref name="TMessage"/> pre-handle phase
    /// </summary>
    /// <typeparam name="TMessage">The message type that is handled</typeparam>
    public interface IPreHandleHook<in TMessage> : IHook<TMessage>
    {
        
    }
}