﻿using Booking.Application.Contract.Dtos;
using Booking.Application.Infrastructure;

namespace Booking.Infrastructure.RepositoriesImpl;

public class BookingRepository : IBookingRepository
{
    public void Delete(Guid id)
    {
        if (!Database.Bookings.ContainsKey(id)) throw new Exception("Booking findes ikke i databasen");
        
        Database.Bookings.Remove(id);
    }

    void IBookingRepository.Add(Domain.Entities.Booking booking)
    {
        Database.Bookings.Add(booking.Id, new BookingQueryDto{Id = booking.Id, Slut = booking.Slut, Start = booking.Start});
    }

    Domain.Entities.Booking IBookingRepository.Get(Guid id)
    {
        var db = Database.Bookings[id];
        return new Domain.Entities.Booking(db.Id, db.Start, db.Slut);
    }

    void IBookingRepository.Save(Domain.Entities.Booking booking)
    {
        if (!Database.Bookings.ContainsKey(booking.Id)) throw new Exception("Booking findes ikke i databasen");

        var db = Database.Bookings[booking.Id];
        db.Id = booking.Id;
        db.Start = booking.Start;
        db.Slut = booking.Slut; 
    }
}