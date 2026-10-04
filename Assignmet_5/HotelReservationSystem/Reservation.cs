using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Reservation
    {

        public Guid ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public Room Room { get; }
        public ReservationStatus Status { get; private set; }

        public decimal TotalCost
        {
            get
            {
                int totalNights = (CheckOutDate - CheckInDate).Days;
                return totalNights * Room.NightlyRate;
            }
        }


        public Reservation(Guid reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
        {
            if (checkInDate >= checkOutDate)
            {
                throw new ArgumentException("Check-in date must be before check-out date.");
            }
            if(room.IsUnderMaintenance)
            {
                throw new InvalidOperationException("Cannot reserve a room that is under maintenance.");
            }
            ReservationId = reservationId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Room = room;
            Status = ReservationStatus.Pending;
        }
        public void Confirm()
        {
            if (Status == ReservationStatus.Pending)
            {
                Status = ReservationStatus.Confirmed;
            }
            else
            {
                throw new InvalidOperationException("Only pending reservations can be confirmed.");
            }
        }
        public void CheckIn()
        {
            if (Status == ReservationStatus.Confirmed)
            {
                Status = ReservationStatus.CheckedIn;
            }
            else
            {
                throw new InvalidOperationException("Only confirmed reservations can be checked in.");
            }
        }
        public void CheckOut()
        {
            if (Status == ReservationStatus.CheckedIn)
            {
                Status = ReservationStatus.CheckedOut;
            }
            else
            {
                throw new InvalidOperationException("Only Checked in reservations can be checked out.");
            }
        }
        public void Cancel()
        {
            if (Status == ReservationStatus.Pending || Status == ReservationStatus.Confirmed)
            {
                Status = ReservationStatus.Cancelled;
            }
            else
            {
                throw new InvalidOperationException("Only pending or confirmed reservations can be cancelled.");
            }
        }
    }
    
}
