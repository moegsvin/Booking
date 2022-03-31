using Booking.Application.Contract;
using Booking.Application.Implementation;
using Booking.Application.Infrastructure;
using Booking.Contract;
using Booking.Domain.DomainServices;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.DomainServicesImpl;
using Booking.Infrastructure.Queries;
using Booking.Infrastructure.RepositoriesImpl;
using Booking.Web.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BookingContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection"), x =>
    {
        x.MigrationsAssembly("Booking.Web");
    }));

builder.Services.AddHttpClient();
builder.Services.AddScoped<IBookingQuery, BookingQuery>();
builder.Services.AddScoped<IBookingCommand, BookingCommand>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();
builder.Services.AddScoped<IBookingService, BookingServiceProxy>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
