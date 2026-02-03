using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ScalableInventory.Core.Interfaces;
using ScalableInventory.Infrastructure;
using ScalableInventory.Infrastructure.Contexts;
using ScalableInventory.Infrastructure.Repositories;
using ScalableInventory.Services;
using ScalableInventory.Services.Catalog;
using ScalableInventory.Services.Inventory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogConnection")));

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryConnection")));

builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();


builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();


builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Scalable Inventory API - Desislava Angelova",
        Version = "v1",
        Description = "A professional CMS-ready API for Catalog and Inventory management."
    });
});
var app = builder.Build();
app.Use(async (context, next) =>
{
    if (context.Request.Path.Value == "/" || context.Request.Path.StartsWithSegments("/index.html"))
    {
        string? authHeader = context.Request.Headers.Authorization.ToString();

        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic ") &&
            authHeader.Substring(6) == "YWRtaW46UGFzc3dvcmQxMjMh")
        {
            await next();
            return;
        }

        // Използваме .Set вместо .Append за по-голяма съвместимост с Chrome
        context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"Swagger\", charset=\"UTF-8\"";
        context.Response.StatusCode = 401;

        // Важно: първо се праща хедърът, после тялото
        await context.Response.WriteAsync("Access Denied. Please refresh and enter credentials.");
        return;
    }

    await next();
});
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScalableInventory.API v1");
        c.RoutePrefix = string.Empty;
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
