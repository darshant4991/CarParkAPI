using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParkAPI.Models;
namespace CarParkAPI.Interfaces
{
    public interface IParkSpaces
    {
        ParkSpace GetAvailability(DateTime from, DateTime to);

        UserParkSpace AddReservation(int UserId, int ParkSpaceId, DateTime date);

        public string CancelReservation(int UserId, int ParkSpaceId, DateTime date);

        public string AmendReservation(int UserId, int ParkSpaceId, DateTime date, int NewParkSpaceId, DateTime Newdate);

        public string GetPrice(DateTime date);
    }
}
