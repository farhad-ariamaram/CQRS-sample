using CQRS.Application.Books.Commands;
using CQRS.Application.Books.Interfaces;
using CQRS.Infrastructure.Persistence;
using CQRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(AddBookCommandHandler).Assembly);
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("CQRS"));
builder.Services.AddScoped<IBookRepository, BookRepository>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();