using CQRS.Application.Books.Commands;
using CQRS.Application.Books.Interfaces;
using CQRS.Infrastructure.Persistence;
using CQRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using CQRS.Application.Behaviors;
using CQRS.Application.Books.Commands.AddBook;
using MediatR;
using BookStore.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<AddBookCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(AddBookCommandHandler).Assembly);
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("CQRS"));
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

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