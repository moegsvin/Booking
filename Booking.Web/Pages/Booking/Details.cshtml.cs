using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace Booking.Web.Pages.Booking
{
    public class DetailsModel : PageModel
    {
        private readonly IBookingCommand _bookingCommand;
        private readonly IBookingQuery _bookingQuery;

        public DetailsModel(IBookingQuery bookingQuery, IBookingCommand bookingCommand)
        {
            _bookingQuery = bookingQuery;
            _bookingCommand = bookingCommand;
        }

        [BindProperty] public BookingDetailsModel Booking { get; set; } = new();

        public IActionResult OnGet(Guid? id)
        {
            if (id == null) return NotFound();

            var domainBooking = _bookingQuery.GetBooking(id.Value);
            if (domainBooking == null) return NotFound();

            Booking = BookingDetailsModel.CreateFromBookingQueryDto(domainBooking);

            return Page();
        }

        public class BookingDetailsModel
        {
            public BookingDetailsModel()
            {
            }

            private BookingDetailsModel(BookingQueryDto booking)
            {
                Id = booking.Id;
                Start = booking.Start;
                Slut = booking.Slut;
            }

            public Guid Id { get; set; }

            [DisplayName("Start tidspunkt")] public DateTime Start { get; set; }

            [DisplayName("Slut tidspunkt")] public DateTime Slut { get; set; }

            public BookingCommandDto GetAsBookingCommandDto()
            {
                return new BookingCommandDto { Id = Id, Start = Start, Slut = Slut };
            }

            public static BookingDetailsModel CreateFromBookingQueryDto(BookingQueryDto booking)
            {
                return new BookingDetailsModel(booking);
            }
        }
    }
}
