using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking.Web.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly IBookingCommand _bookingCommand;
        private readonly IBookingQuery _bookingQuery;

        public DeleteModel(IBookingQuery bookingQuery, IBookingCommand bookingCommand)
        {
            _bookingQuery = bookingQuery;
            _bookingCommand = bookingCommand;
        }


        public IActionResult OnGet(Guid? id)
        {
            if (id == null) return NotFound();

            var domainBooking = _bookingQuery.GetBooking(id.Value);
            if (domainBooking == null) return NotFound();

            _bookingCommand.Delete(new BookingCommandDto { Id = id.Value });

            return RedirectToPage("./Index");
        }


    }
}
