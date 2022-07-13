using System.Reflection;
using DevOps.AutomatedActions.Api.Services;
using DevOps.AutomatedActions.Api.Services.Interfaces;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddHttpClient<IAzureHttpFactory, AzureHttpFactory>();
builder.Services.AddScoped<IAzureHttpFactory, AzureHttpFactory>();
builder.Services.AddScoped<IPullRequestService, PullRequestService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
