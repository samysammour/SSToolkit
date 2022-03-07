using SSToolkit.Domain.Repositories;
using SSToolkit.Infrastructure.EntityFrameworkCore;
using SSToolkit.Infrastructure.EntityFrameworkCore.Reference;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.AddSqlServer(builder.Configuration.GetValue(typeof(string), "ConnectionString").ToString()));

builder.Services.AddLogging();

builder.Services.AddScoped<IRepository<Student>>(serviceProvider =>
    EntityFrameworkRepositoryFactory.Create<Student>(serviceProvider.GetRequiredService<MyDbContext>())
        .AddLoggingDecorator(serviceProvider.GetRequiredService<ILogger<IRepository<Student>>>()));

builder.Services.AddScoped<IRepository<Teacher>>(serviceProvider =>
    EntityFrameworkRepositoryFactory.Create<Teacher>(serviceProvider.GetRequiredService<MyDbContext>())
        .AddLoggingDecorator(serviceProvider.GetRequiredService<ILogger<IRepository<Teacher>>>()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.

app.MapGet("/teachers/get", async (IRepository<Teacher> repository) =>
{
    var teacher = new Teacher
    {
        FirstName = "Teacher"
    };

    teacher = await repository.InsertAsync(teacher);

    var dbTeacher = await repository.FindOneAsync(teacher.Id);
    await repository.DeleteAsync(dbTeacher);

    return dbTeacher;
});

app.Run();
