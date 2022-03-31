using Booking.Application.Contract;
using Booking.Application.Implementation;
using Booking.Application.Infrastructure;
using Booking.Domain.DomainServices;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.DomainServicesImpl;
using Booking.Infrastructure.Queries;
using Booking.Infrastructure.RepositoriesImpl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookingQuery, BookingQuery>();
builder.Services.AddScoped<IBookingCommand, BookingCommand>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();

builder.Services.AddDbContext<BookingContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"), x =>
    {
        x.MigrationsAssembly("Booking.Web");
    }));

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
