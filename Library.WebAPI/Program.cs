using Library.Core.Mappings;
using Library.Infrastructure.Database;
using Library.WebAPI.Extensions;
using Library.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.Services.AddDbContext<LibraryDbContext>(options => options.UseMySql(connectionString, new MariaDbServerVersion("10.6")));
builder.Services.ConfigureServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();
await EnsureDb(app.Services, app.Logger);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task EnsureDb(IServiceProvider services, ILogger logger)
{
    logger.LogInformation("Ensuring database exists and is up to date at connection string '{connectionString}'", connectionString);

    using var db = services.CreateScope().ServiceProvider.GetRequiredService<LibraryDbContext>();
    await db.Database.MigrateAsync();
}