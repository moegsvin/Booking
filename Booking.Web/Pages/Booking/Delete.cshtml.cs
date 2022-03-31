using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Booking.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking.Web.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly IBookingCommand _bookingCommand;
        private readonly IBookingQuery _bookingQuery;

        private readonly IBookingService _bookingService;

        public DeleteModel(IBookingService bookingService)
        {
            //_bookingQuery = bookingQuery;
            //_bookingCommand = bookingCommand; 
            _bookingService = bookingService;
        }


        public IActionResult OnGet(Guid? id)
        {
            if (id == null) return NotFound();

            var domainBooking = _bookingService.Get(id.Value);
            if (domainBooking == null) return NotFound();

            _bookingService.Delete( id.Value );

            return RedirectToPage("./Index");
        }


    }
}
