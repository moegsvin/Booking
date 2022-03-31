
using Booking.Contract;
using Booking.Contract.Dto;

namespace Booking.Web.Infrastructure
{
    public class BookingServiceProxy : IBookingService
    {
        private readonly IHttpClientFactory _httpClient;
        public BookingServiceProxy(HttpClient httpClient)
        {
            _httpClient= (IHttpClientFactory?)httpClient;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookingServiceDto> Get()
        {




            throw new NotImplementedException();
        }

        public BookingServiceDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Post(BookingServiceDto booking)
        {
            throw new NotImplementedException();
        }

        public void Put(BookingServiceDto booking)
        {
            throw new NotImplementedException();
        }
    }
}
