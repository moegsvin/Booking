using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Booking.Contract;
using Booking.Contract.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booking.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase, IBookingService
    {
        private readonly IBookingCommand _bookingCommand;
        private readonly IBookingQuery _bookingQuery;


        public BookingController(IBookingQuery bookingQuery, IBookingCommand bookingCommand)
        {
            _bookingQuery = bookingQuery;
            _bookingCommand = bookingCommand;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public IEnumerable<BookingServiceDto> Get()
        {
            var bookings = new List<BookingServiceDto>();
            _bookingQuery
                .GetBookings()
                .ToList()
                .ForEach( a => bookings.Add( new BookingServiceDto() 
                    { Id = a.Id, Start = a.Start, Slut = a.Slut } ));

            return bookings;
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public BookingServiceDto Get(Guid id)
        {
            var booking = _bookingQuery.GetBooking(id);
            return new BookingServiceDto { Id = booking.Id, Start = booking.Start, Slut = booking.Slut };
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post(BookingServiceDto booking)
        {
            
            _bookingCommand.Create(new BookingCommandDto { Id = booking.Id, Start = booking.Start, Slut = booking.Slut });
        }

        // PUT api/<BookingController>/5
        [HttpPut]
        public void Put(BookingServiceDto booking)
        {
            _bookingCommand.Edit(new BookingCommandDto { Id = booking.Id, Start = booking.Start, Slut = booking.Slut });
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _bookingCommand.Delete(new BookingCommandDto { Id = id });
        }
    }
}
