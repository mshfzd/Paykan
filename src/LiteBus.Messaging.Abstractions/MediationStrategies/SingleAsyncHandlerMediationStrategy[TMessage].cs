#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;

namespace LiteBus.Messaging.Abstractions;

public sealed class SingleAsyncHandlerMediationStrategy<TMessage> : IMessageMediationStrategy<TMessage, Task> where TMessage : notnull
{
    public async Task Mediate(TMessage message, IMessageDependencies messageDependencies)
    {
        if (messageDependencies.Handlers.Count > 1)
        {
            throw new MultipleHandlerFoundException(typeof(TMessage), messageDependencies.Handlers.Count);
        }

        Task? messageResult = null;

        try
        {
            await messageDependencies.RunAsyncPreHandlers(message);

            var handler = messageDependencies.Handlers.Single().Value;

            messageResult = (Task) handler.Handle(message);

            await messageResult;

            await messageDependencies.RunPostHandlers(message, messageResult);
        }
        catch (Exception e)
        {
            if (messageDependencies.ErrorHandlers.Count + messageDependencies.IndirectErrorHandlers.Count == 0)
            {
                throw;
            }

            await messageDependencies.RunErrorHandlers(message, messageResult, e);
        }
    }
}