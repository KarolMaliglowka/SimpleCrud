using SimpleCrud.Application.Abstractions.Dispatchers;
using SimpleCrud.Application.Abstractions.Queries;

namespace SimpleCrud.Application.Abstractions.Dispatchers;

internal sealed class Dispatchers : IDispatcher
{
    private readonly IQueryDispatcher _queryDispatcher;

    public Dispatchers()
    {
    }
    
    public Dispatchers(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }
    // public Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand
    //     => commandDispatcher.SendAsync(command, cancellationToken);

    // public Task<TResult> SendAsyncWithResponse<TResult>(ICommand<TResult> command,
    //     CancellationToken cancellationToken = default)
    //     => commandDispatcher.SendAsyncWithResponse(command, cancellationToken);
    //
    // public Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent
    //     => eventDispatcher.PublishAsync(@event, cancellationToken);

    public Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        => _queryDispatcher.QueryAsync(query, cancellationToken);
}