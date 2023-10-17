using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi_.NetCore.Middlewares;
using WebApi_.NetCore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.TryAddTransient<IProductRepository, ProductRepository>();
builder.Services.TryAddTransient<IProductRepository, TestRepository>();
//builder.Services.AddSingleton<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddTransient<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject Middleware
//builder.Services.AddTransient<CustomMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


#region Middlewares

app.Use(async (context, next) =>
{
	await context.Response.WriteAsync("Use()\n");
	await next();
	await context.Response.WriteAsync("Use()\n");
});

app.Use(async (context, next) =>
{
	await context.Response.WriteAsync("Use2()\n");
	await next();
	await context.Response.WriteAsync("Use2()\n");
});

app.UseMiddleware<CustomMiddleware>();

app.Map("/map", HandleMapTest);

app.Run(async context => await context.Response.WriteAsync("Run()\n"));

app.Run();


static void HandleMapTest(IApplicationBuilder app)
{
	app.Run(async context => await context.Response.WriteAsync("Map()\n"));
}

#endregion