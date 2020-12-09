﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Paykan.Abstractions
{
    public interface IQueryMediator
    {
        Task<TQueryResult> QueryAsync<TQuery, TQueryResult>(TQuery query,
                                                            CancellationToken cancellationToken = default)
            where TQuery : IQuery<TQueryResult>;

        IAsyncEnumerable<TQueryResult> StreamQueryAsync<TQuery, TQueryResult>(TQuery query,
            CancellationToken cancellationToken = default)
            where TQuery : IStreamQuery<TQueryResult>;

        public Task<TQueryResult> QueryAsync<TQueryResult>(
            IQuery<TQueryResult> query,
            CancellationToken cancellationToken = default);

        IAsyncEnumerable<TQueryResult> StreamQueryAsync<TQueryResult>(IStreamQuery<TQueryResult> query,
                                                                      CancellationToken cancellationToken =
                                                                          default);
    }
}