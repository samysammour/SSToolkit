﻿namespace SSToolkit.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Specifications;
    using SSToolkit.Domain.Repositories.Model;
    using SSToolkit.Fundamental.Extensions;

    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly IRepository<TEntity> decoratee;

        protected Repository(IRepository<TEntity> decoratee)
        {
            this.decoratee = decoratee;
        }

        public virtual async Task<RepositoryActionResult> DeleteAsync(object id)
            => await this.decoratee.DeleteAsync(id).AnyContext();

        public virtual async Task<RepositoryActionResult> DeleteAsync(TEntity entity)
            => await this.decoratee.DeleteAsync(entity).AnyContext();

        public virtual async Task<bool> ExistsAsync(object id)
            => await this.decoratee.ExistsAsync(id).AnyContext();

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
            => await this.decoratee.FindAllAsync(options, cancellationToken).AnyContext();

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(ISpecification<TEntity> specification, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
            => await this.decoratee.FindAllAsync(specification, options, cancellationToken).AnyContext();

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(IEnumerable<ISpecification<TEntity>> specifications, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
            => await this.decoratee.FindAllAsync(specifications, options, cancellationToken).AnyContext();

        public virtual async Task<TEntity> FindOneAsync(object id)
            => await this.decoratee.FindOneAsync(id).AnyContext();

        public virtual async Task<TEntity> FindOneAsync(IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
            => await this.decoratee.FindOneAsync(options, cancellationToken).AnyContext();

        public virtual async Task<TEntity> FindOneAsync(ISpecification<TEntity> specification, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
            => await this.decoratee.FindOneAsync(specification, options, cancellationToken).AnyContext();

        public virtual async Task<TEntity> FindOneAsync(IEnumerable<ISpecification<TEntity>> specifications, IFindOptions<TEntity> options = null, CancellationToken cancellationToken = default)
            => await this.decoratee.FindOneAsync(specifications, options, cancellationToken).AnyContext();

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
            => await this.decoratee.InsertAsync(entity).AnyContext();

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
            => await this.decoratee.UpdateAsync(entity).AnyContext();

        public virtual async Task<(TEntity entity, RepositoryActionResult action)> UpsertAsync(TEntity entity)
            => await this.decoratee.UpsertAsync(entity).AnyContext();
    }
}
