using System.ComponentModel;
using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Booking.Contract;
using Booking.Contract.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booking.Web.Pages.Booking;

public class EditModel : PageModel
{
    //private readonly IBookingCommand _bookingCommand;
    //private readonly IBookingQuery _bookingQuery;

    private readonly IBookingService _bookingService;

    //public EditModel(IBookingQuery bookingQuery, IBookingCommand bookingCommand)

    public EditModel(IBookingService bookingService)
    {
        //_bookingQuery = bookingQuery;
        //_bookingCommand = bookingCommand;
        _bookingService = bookingService;
    }

    // Hvad for en fisk?
    [FromRoute] public Guid Id { get; set; }

    [BindProperty] public BookingEditModel Booking { get; set; } = new();


    public IActionResult OnGet(Guid? id)
    {
        if (id == null) return NotFound();

        var domainBooking = _bookingService.Get(id.Value);
        if (domainBooking == null) return NotFound();

        Booking = BookingEditModel.CreateFromBookingServiceDto(domainBooking);

        return Page();
    }

    public IActionResult OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _bookingService.Put(Booking.GetAsBookingServiceDto());

        return RedirectToPage("./Index");
    }

    public class BookingEditModel
    {
        public BookingEditModel()
        {
        }

        private BookingEditModel(BookingServiceDto booking)
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
            return new BookingServiceDto {Id = Id, Start = Start, Slut = Slut};
        }

        public static BookingEditModel CreateFromBookingServiceDto(BookingServiceDto booking)
        {
            return new BookingEditModel(booking);
        }


    }
}