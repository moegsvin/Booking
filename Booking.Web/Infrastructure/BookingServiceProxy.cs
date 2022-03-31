
using Booking.Contract;
using Booking.Contract.Dto;

namespace Booking.Web.Infrastructure
{
    public class BookingServiceProxy : IBookingService
    {
        private readonly HttpClient _httpClient;
        public BookingServiceProxy(HttpClient httpClient)
        {
            _httpClient= (HttpClient?)httpClient;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingServiceDto>> GetAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookingServiceDto>>("api/Booking");
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
