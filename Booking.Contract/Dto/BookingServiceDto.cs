using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Contract.Dto
{
    public class BookingServiceDto
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }
    }
}
