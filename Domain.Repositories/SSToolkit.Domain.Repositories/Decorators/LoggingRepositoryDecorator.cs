namespace SSToolkit.Domain.Repositories.Decorators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Model;
    using Specifications;
    using SSToolkit.Fundamental.Extensions;

    public class LoggingRepositoryDecorator<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly IRepository<TEntity> decoratee;
        private readonly ILogger<IRepository<TEntity>> logger;

        public LoggingRepositoryDecorator(IRepository<TEntity> repository, ILogger<IRepository<TEntity>> logger)
        {
            this.decoratee = repository;
            this.logger = logger;
        }

        public async Task<RepositoryActionResult> DeleteAsync(object id)
        {
            this.logger.LogInformation($"Start deleting {typeof(TEntity)} {id}");
            var result = await this.decoratee.DeleteAsync(id).AnyContext();
            this.logger.LogInformation($"{typeof(TEntity)} {id} is deleted");
            return result;
        }

        public async Task<RepositoryActionResult> DeleteAsync(TEntity entity)
        {
            this.logger.LogInformation($"Start deleting {typeof(TEntity)} {entity.Id}");
            var result = await this.decoratee.DeleteAsync(entity).AnyContext();
            this.logger.LogInformation($"{typeof(TEntity)} {entity.Id} is deleted");
            return result;
        }

        public async Task<bool> ExistsAsync(object id)
        {
            this.logger.LogInformation($"Start checking if {typeof(TEntity)} {id} exists");
            var result = await this.decoratee.ExistsAsync(id).AnyContext();
            this.logger.LogInformation($"{typeof(TEntity)} {id} exists: {result}");
            return result;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
        {
            this.LogSpecificationTakeSkipWhenNotNull($"Get all {typeof(TEntity)}.", null, options);
            this.LogOrders(options);
            this.LogIncludes(options);
            
            return await this.decoratee.FindAllAsync(options, cancellationToken).AnyContext();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
        {
            this.LogSpecificationTakeSkipWhenNotNull($"Get all {typeof(TEntity)}.", specification.AsList(), options);
            this.LogOrders(options);
            this.LogIncludes(options);

            return await this.decoratee.FindAllAsync(specification, options, cancellationToken).AnyContext();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(IEnumerable<ISpecification<TEntity>> specifications, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
        {
            this.LogSpecificationTakeSkipWhenNotNull($"Get all {typeof(TEntity)}.", specifications, options);
            this.LogOrders(options);
            this.LogIncludes(options);

            return await this.decoratee.FindAllAsync(specifications, options, cancellationToken).AnyContext();
        }

        public async Task<TEntity> FindOneAsync(object id)
        {
            this.logger.LogInformation($"Get {typeof(TEntity)} by {id}.");
            return await this.decoratee.FindOneAsync(id).AnyContext();
        }

        public async Task<TEntity> FindOneAsync(IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
        {
            this.LogSpecificationTakeSkipWhenNotNull($"Get first {typeof(TEntity)}.", null, options);
            this.LogOrders(options);
            this.LogIncludes(options);

            return await this.decoratee.FindOneAsync(options, cancellationToken).AnyContext();
        }

        public async Task<TEntity> FindOneAsync(ISpecification<TEntity> specification, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
        {
            this.LogSpecificationTakeSkipWhenNotNull($"Get first {typeof(TEntity)}.", specification.AsList(), options);
            this.LogOrders(options);
            this.LogIncludes(options);

            return await this.decoratee.FindOneAsync(specification, options, cancellationToken).AnyContext();
        }

        public async Task<TEntity> FindOneAsync(IEnumerable<ISpecification<TEntity>> specifications, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
        {
            this.LogSpecificationTakeSkipWhenNotNull($"Get first {typeof(TEntity)}.", specifications, options);
            this.LogOrders(options);
            this.LogIncludes(options);

            return await this.decoratee.FindOneAsync(specifications, options, cancellationToken).AnyContext();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            this.logger.LogInformation($"Start inserting {typeof(TEntity)}");
            var result = await this.decoratee.InsertAsync(entity).AnyContext();
            this.logger.LogInformation($"{typeof(TEntity)} {result.Id} is inserted");
            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            this.logger.LogInformation($"Start updating {typeof(TEntity)}");
            var result = await this.decoratee.UpdateAsync(entity).AnyContext();
            this.logger.LogInformation($"{typeof(TEntity)} {result.Id} is updated");
            return result;
        }

        public async Task<(TEntity entity, RepositoryActionResult action)> UpsertAsync(TEntity entity)
        {
            this.logger.LogInformation($"Start upserting {typeof(TEntity)}");
            var result = await this.decoratee.UpsertAsync(entity).AnyContext();
            this.logger.LogInformation($"{typeof(TEntity)} {result.entity.Id} is {result.action}");
            return result;
        }

        private void LogSpecificationTakeSkipWhenNotNull(string message, IEnumerable<ISpecification<TEntity>> specifications, IFindOptions<TEntity> options)
        {
            var loggingMessage = new StringBuilder(message);
            foreach (var specification in specifications.Safe())
            {
                loggingMessage.Append($" Specification: {specification}.");
            }

            if (options != null)
            {
                if (options.Take.HasValue)
                {
                    loggingMessage.Append($" Take: {options.Take.Value}.");
                }

                if (options.Skip.HasValue)
                {
                    loggingMessage.Append($" Skip: {options.Skip.Value}.");
                }
            }

            this.logger.LogInformation(loggingMessage.ToString().Replace("*", string.Empty).Trim());
        }

        private void LogOrders(IFindOptions<TEntity> options)
        {
            if (options != null && options.HasOrders())
            {
                var loggingMessage = new StringBuilder();
                foreach (var order in options.GetOrders())
                {
                    loggingMessage.Append($"Order: {order}. ");
                }

                this.logger.LogInformation(loggingMessage.ToString().Trim());
            }
        }

        private void LogIncludes(IFindOptions<TEntity> options)
        {
            if (options != null && options.ShouldInclude())
            {
                var loggingMessage = new StringBuilder();
                foreach (var include in options.GetIncludes())
                {
                    loggingMessage.Append($"Include: {include}. ");
                }

                this.logger.LogInformation(loggingMessage.ToString().Trim());
            }
        }
    }
}
