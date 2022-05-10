namespace SSToolkit.Infrastructure.Azure.CosmosDb.Reference
{
    using SSToolkit.Infrastructure.Azure.CosmosDb;

    public class Customer : CosmosDbEntity
    {
        public string Name { get; set; }

        public string Location { get; set; }
    }
}
