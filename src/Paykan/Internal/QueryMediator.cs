﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Paykan.Abstractions;
using Paykan.Internal.Extensions;

namespace Paykan.Internal
{
    internal class QueryMediator : IQueryMediator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageRegistry _messageRegistry;

        public QueryMediator(IServiceProvider serviceProvider,
                             IMessageRegistry messageRegistry)
        {
            _serviceProvider = serviceProvider;
            _messageRegistry = messageRegistry;
        }
        
        public Task<TQueryResult> QueryAsync<TQuery, TQueryResult>(TQuery query,
                                                                   CancellationToken cancellationToken = default)
            where TQuery : IQuery<TQueryResult>
        {
            var descriptor = _messageRegistry[query.GetType()];

            var handler = _serviceProvider.GetHandler<TQuery, Task<TQueryResult>>(descriptor.HandlerTypes.First());

            return handler.HandleAsync(query, cancellationToken);
        }

        public IAsyncEnumerable<TQueryResult> StreamQueryAsync<TQuery, TQueryResult>(
            TQuery query,
            CancellationToken cancellationToken = default) where TQuery : IStreamQuery<TQueryResult>
        {
            var descriptor = _messageRegistry[query.GetType()];

            var handler = _serviceProvider.GetHandler<TQuery, IAsyncEnumerable<TQueryResult>>(descriptor.HandlerTypes.First());

            return handler.HandleAsync(query, cancellationToken);
        }
    }
}