using SimpleCrud.Application.Abstractions.Commands;
using SimpleCrud.Application.Abstractions.Queries;

namespace SimpleCrud.Application.Abstractions.Dispatchers;

public interface IDispatcher
{
    // Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    //Task<TResult> SendAsyncWithResponse<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    //Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}