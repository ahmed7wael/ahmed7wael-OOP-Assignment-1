using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class Room
    {

        public int RoomNumber { get; }
        public RoomType RoomType { get; }
        public decimal NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }

        public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
        {
            if(nightlyRate <= 0)
            {
                throw new ArgumentException("Nightly rate cannot be zero or negative.");
            }
            RoomNumber = roomNumber;
            RoomType = roomType;
            NightlyRate = nightlyRate;
            IsUnderMaintenance = false;
        }
        public bool StartMaintenance()
        {
            if (!IsUnderMaintenance)
            {
                IsUnderMaintenance = true;
                return true;
            }
            return false;
        }
        public bool EndMaintenance()
        {
            if (IsUnderMaintenance)
            {
                IsUnderMaintenance = false;
                return true;
            }
            return false;
        }

        public void UpdateNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
            {
                throw new ArgumentException("Nightly rate must be greater than zero.");
            }
            NightlyRate = newRate;
        }


    }
}
