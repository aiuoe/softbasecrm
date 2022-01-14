using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace SBCRM.Test.Base.Configuration
{
    public static class AsyncQueryable
    {
        /// <summary>
        /// Returns the input typed as IQueryable that can be queried asynchronously
        /// </summary>
        /// <typeparam name="TEntity">The item type</typeparam>
        /// <param name="source">The input</param>
        public static IQueryable<TEntity> AsAsyncQueryable<TEntity>(this IEnumerable<TEntity> source)
            => new AsyncQueryable<TEntity>(source ?? throw new ArgumentNullException(nameof(source)));
    }

    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public AsyncEnumerator(IEnumerator<T> enumerator)
        {
            this._enumerator = enumerator;
        }

        public T Current => this._enumerator.Current;

        public ValueTask DisposeAsync()
        {
            return new ValueTask(Task.Run(() => this._enumerator.Dispose()));
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(this._enumerator.MoveNext());
        }
    }


    public class AsyncQueryable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public AsyncQueryable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        public AsyncQueryable(Expression expression)
            : base(expression)
        {
        }

        IQueryProvider IQueryable.Provider => new AsyncQueryProvider<T>(this);

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken token)
        {
            return new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }
    }


    public class AsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _innerQueryProvider;

        internal AsyncQueryProvider(IQueryProvider innerQueryProvider)
        {
            _innerQueryProvider = innerQueryProvider;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new AsyncQueryable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new AsyncQueryable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return this._innerQueryProvider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return this._innerQueryProvider.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var expectedResultType = typeof(TResult).GetGenericArguments()[0];
            var executionResult = ((IQueryProvider) this).Execute(expression);

            return (TResult) typeof(Task).GetMethod(nameof(Task.FromResult))
                ?.MakeGenericMethod(expectedResultType)
                .Invoke(null, new[] {executionResult});
        }
    }
}