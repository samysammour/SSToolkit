namespace SSToolkit.Infrastructure.Azure.CosmosDb.Tests
{
    using Microsoft.Azure.Cosmos;
    using NSubstitute;
    using SSToolkit.Domain.Repositories.Model;
    using System.Linq;

    public class TestCosmosDbRepository<TEntity> : CosmosDbRepository<TEntity>, ICosmosDbRepository<TEntity>
        where TEntity : CosmosDbEntity, IEntity<string>, IStateEntity
    {
        private ICosmosDbLinqQuery cosmosDbLinqQuery;
        public TestCosmosDbRepository(CosmosDbRepositoryOptions<TEntity> options)
            : base(options)
        {
        }

        protected override ICosmosDbLinqQuery CosmosDbLinqQuery
        {
            get => this.cosmosDbLinqQuery;
            set
            {
                var linqQuery = Substitute.For<ICosmosDbLinqQuery>();
                linqQuery.GetFeedIterator(Arg.Any<IQueryable<Stub>>())
                    .Returns(x => this.GetFeedIteratorMock((IQueryable<Stub>)x[0]));
                this.cosmosDbLinqQuery = linqQuery;
            }

        }

        private FeedIterator<Stub> GetFeedIteratorMock(IQueryable<Stub> list)
        {
            var feedResponse = Substitute.For<FeedResponse<Stub>>();
            var feedIterator = Substitute.For<FeedIterator<Stub>>();

            feedResponse.Resource.Returns(list.ToList());
            feedIterator.HasMoreResults.Returns(true);
            feedIterator.ReadNextAsync(cancellationToken: default).ReturnsForAnyArgs(feedResponse)
                .AndDoes(x => feedIterator.HasMoreResults.Returns(false));
            return feedIterator;
        }
    }
}
