using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Guest
    {
        private List<Reservation> _reservations = new List<Reservation>();
        public Guid GuestId { get; }
        public string FullName { get; private set; }
        public string PhoneNumber { get; private set; }

        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        public Guest(Guid reservationId, string fullName, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be empty.");
            }

            GuestId = reservationId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
        public void FullHistory()
        {
            foreach (var reservation in Reservations)
            {
                Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Status: {reservation.Status}, Total Cost: {reservation.TotalCost:C}");
            }
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");
            }
            _reservations.Add(reservation);
        }


    }
}
