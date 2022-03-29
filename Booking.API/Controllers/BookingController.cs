using Booking.Application.Contract;
using Booking.Application.Contract.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booking.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
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
        public IEnumerable<BookingQueryDto> Get()
        {
            var bookings = new List<BookingQueryDto>();
            _bookingQuery
                .GetBookings()
                .ToList()
                .ForEach( a => bookings.Add( new BookingQueryDto() 
                    { Id = a.Id, Start = a.Start, Slut = a.Slut } ));

            return bookings;
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public BookingQueryDto Get(Guid id)
        {
            var booking = _bookingQuery.GetBooking(id);
            return booking;
        }

        // POST api/<BookingController>
        [HttpPost]
        public void Post(BookingCommandDto booking)
        {
            
            _bookingCommand.Create(booking);
        }

        // PUT api/<BookingController>/5
        [HttpPut]
        public void Put(BookingCommandDto booking)
        {
            _bookingCommand.Edit(booking);
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _bookingCommand.Delete(new BookingCommandDto { Id = id });
        }
    }
}
