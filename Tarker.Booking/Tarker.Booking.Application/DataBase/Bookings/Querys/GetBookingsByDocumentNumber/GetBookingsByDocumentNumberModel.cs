﻿namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByDocumentNumber
{
    public class GetBookingsByDocumentNumberModel
    {
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
