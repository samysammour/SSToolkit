namespace SSToolkit.Infrastructure.Azure.CosmosDb
{
    using System.Linq;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Linq;
    using SSToolkit.Domain.Repositories.Model;

    public class CosmosDbLinqQuery : ICosmosDbLinqQuery
    {
        public FeedIterator<TEntity> GetFeedIterator<TEntity>(IQueryable<TEntity> source)
            where TEntity : CosmosDbEntity, IEntity<string>, IStateEntity
        {
            return source.ToFeedIterator();
        }
    }

    public interface ICosmosDbLinqQuery
    {
        FeedIterator<TEntity> GetFeedIterator<TEntity>(IQueryable<TEntity> source)
            where TEntity : CosmosDbEntity, IEntity<string>, IStateEntity;
    }
}
