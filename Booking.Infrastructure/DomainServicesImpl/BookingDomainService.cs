using Booking.Application.Contract.Dtos;
using Booking.Domain.DomainServices;
using Booking.Infrastructure.Data;

namespace Booking.Infrastructure.DomainServicesImpl;

public class BookingDomainService : IBookingDomainService
{
    private readonly BookingContext context;

    public BookingDomainService(BookingContext context)
    {
        this.context = context;
    }
    IEnumerable<Domain.Entities.Booking> IBookingDomainService.GetExsistingBookings()
    {
        var bookings = new List<Domain.Entities.Booking>();

        context.Bookings.ToList().ForEach(a => bookings.Add(new Domain.Entities.Booking(a.Id, a.Start, a.Slut)));


        //Database.Bookings.Values.ToList()
        //    .ForEach(a => bookings.Add(new Domain.Entities.Booking(a.Id, a.Start, a.Slut)));

        return bookings;
    }
}