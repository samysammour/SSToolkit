using SSToolkit.Infrastructure.Azure.CosmosDb;
using SSToolkit.Infrastructure.Azure.CosmosDb.Reference;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();

var connectionString = builder.Configuration.GetValue(typeof(string), "ConnectionString").ToString() ?? String.Empty;
builder.Services.AddScoped<ICosmosDbRepository<Customer>>(serviceProvider =>
        CosmosDbRepositoryFactory.Create<Customer>(connectionString: connectionString, x => x.Location, database: "database-name")
        .AddLoggingDecorator(serviceProvider.GetRequiredService<ILogger<ICosmosDbRepository<Customer>>>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/customers", async (ICosmosDbRepository<Customer> repository) =>
{
    var customer = new Customer
    {
        Name = "Customer",
        Location = "Germany"
    };

    customer = await repository.InsertAsync(customer);
    var dbCustomer = await repository.FindOneAsync(customer.Id.ToString());
    await repository.DeleteAsync(customer.Id);
    return dbCustomer;
});

app.Run();