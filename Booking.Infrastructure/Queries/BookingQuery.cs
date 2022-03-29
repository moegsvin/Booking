using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Booking.Infrastructure.Data;

namespace Booking.Infrastructure.Queries;

public class BookingQuery : IBookingQuery
{
    private readonly BookingContext context;

    public BookingQuery(BookingContext context)
    {
        this.context = context;
    }

    BookingQueryDto IBookingQuery.GetBooking(Guid id)
    {
        var dbBooking = context.Bookings.Find(id);
        return new BookingQueryDto { Id = dbBooking.Id, Start = dbBooking.Start, Slut = dbBooking.Slut };
    }

    IEnumerable<BookingQueryDto> IBookingQuery.GetBookings()
    {
        var result = new List<BookingQueryDto>();
        context.Bookings.ToList().ForEach(a => result.Add(new BookingQueryDto{ Id = a.Id, Start = a.Start, Slut = a.Slut }));
        return result; 
    }
}