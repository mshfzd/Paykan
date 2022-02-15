using System.Threading.Tasks;
using LiteBus.Commands.Abstractions;
using LiteBus.Messaging.Abstractions;

namespace LiteBus.UnitTests.Data.FakeGenericCommandWithoutResult.PreHandlers;

public class FakeGenericCommandWithoutResultPreHandler<TPayload> : ICommandPreHandler<Messages.FakeGenericCommandWithoutResult<TPayload>>
{
    public Task HandleAsync(IHandleContext<Messages.FakeGenericCommandWithoutResult<TPayload>> context)
    {
        context.Message.ExecutedTypes.Add(typeof(FakeGenericCommandWithoutResultPreHandler<TPayload>));
        return Task.CompletedTask;
    }
}