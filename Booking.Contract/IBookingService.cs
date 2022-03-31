using Booking.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Contract
{
    public interface IBookingService
    {
        public IEnumerable<BookingServiceDto> Get();

        public BookingServiceDto Get(Guid id);

        public void Post(BookingServiceDto booking);


        public void Put(BookingServiceDto booking);


        public void Delete(Guid id);
    }
}

