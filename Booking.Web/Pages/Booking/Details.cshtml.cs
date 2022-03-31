using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Booking.Contract;
using Booking.Contract.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace Booking.Web.Pages.Booking
{
    public class DetailsModel : PageModel
    {
        //private readonly IBookingCommand _bookingCommand;
        //private readonly IBookingQuery _bookingQuery;

        private readonly IBookingService _bookingService;

        public DetailsModel(IBookingService bookingService)
        {
            //_bookingQuery = bookingQuery;
            //_bookingCommand = bookingCommand;

            _bookingService = bookingService;
        }

        [BindProperty] public BookingDetailsModel Booking { get; set; } = new();

        public IActionResult OnGet(Guid? id)
        {
            if (id == null) return NotFound();

            var domainBooking = _bookingService.Get(id.Value);
            if (domainBooking == null) return NotFound();

            Booking = BookingDetailsModel.CreateFromBookingServiceDto(domainBooking);

            return Page();
        }

        public class BookingDetailsModel
        {
            public BookingDetailsModel()
            {
            }

            private BookingDetailsModel(BookingServiceDto booking)
            {
                Id = booking.Id;
                Start = booking.Start;
                Slut = booking.Slut;
            }

            public Guid Id { get; set; }

            [DisplayName("Start tidspunkt")] public DateTime Start { get; set; }

            [DisplayName("Slut tidspunkt")] public DateTime Slut { get; set; }

            public BookingServiceDto GetAsBookingServiceDto()
            {
                return new BookingServiceDto { Id = Id, Start = Start, Slut = Slut };
            }

            public static BookingDetailsModel CreateFromBookingServiceDto(BookingServiceDto booking)
            {
                return new BookingDetailsModel(booking);
            }
        }
    }
}
