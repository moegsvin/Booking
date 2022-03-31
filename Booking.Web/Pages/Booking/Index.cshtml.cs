using System.ComponentModel;
using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Booking.Contract;
using Booking.Contract.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking.Web.Pages.Booking;

public class IndexModel : PageModel
{
    //private readonly IBookingQuery _bookingQuery;
    private readonly IBookingService _bookingService;

    public IndexModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [BindProperty] public IEnumerable<BookingIndexModel> Bookings { get; set; } = Enumerable.Empty<BookingIndexModel>();

    public void OnGet()
    {
        var bookings = new List<BookingIndexModel>();
        _bookingService.Get().ToList().ForEach(a => bookings.Add(new BookingIndexModel(a)));
        Bookings = bookings;
    }

    public class BookingIndexModel
    {
        public BookingIndexModel(BookingServiceDto booking)
        {
            Id = booking.Id;
            Start = booking.Start;
            Slut = booking.Slut;
        }

        public Guid Id { get; set; }

        [DisplayName("Start tidspunkt")] public DateTime Start { get; set; }

        [DisplayName("Slut tidspunkt")] public DateTime Slut { get; set; }
    }
}