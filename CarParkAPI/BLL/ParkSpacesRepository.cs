using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParkAPI.Models;
using CarParkAPI.Interfaces;

namespace CarParkAPI.BLL
{
    public class ParkSpacesRepository : IParkSpaces
    {
        List<UserParkSpace> UserParkSpaces = new List<UserParkSpace>();
        List<ParkSpace> ParkSpaces = new List<ParkSpace>
        {
            new ParkSpace{ ParkSpaceId = 1, date = DateTime.Now.Date, Price = 10, availableSpaces = 4},
            new ParkSpace{ ParkSpaceId = 2, date = DateTime.Now.AddDays(1).Date, Price = 8, availableSpaces = 6},
            new ParkSpace{ ParkSpaceId = 1, date = DateTime.Now.AddDays(2).Date, Price = 11, availableSpaces = 3}
        };
        public ParkSpace GetAvailability(DateTime from, DateTime to)
        {
            return ParkSpaces.FirstOrDefault(x => x.date <= from && x.date >= to);
        }
        public UserParkSpace AddReservation(int UserId, int ParkSpaceId, DateTime date)
        {
            UserParkSpaces.Add(new UserParkSpace { UserId = UserId, date = date, ParkSpaceId = ParkSpaceId, status="Booked" });
            foreach (var ps in ParkSpaces)
            {
                if (ps.ParkSpaceId == ParkSpaceId && ps.date == date)
                    ps.availableSpaces = ps.availableSpaces - 1;
            }
            return UserParkSpaces.FirstOrDefault(x=>x.UserId == UserId && x.date == date && x.ParkSpaceId == ParkSpaceId);
        }
        public string CancelReservation(int UserId, int ParkSpaceId, DateTime date)
        {
            UserParkSpaces.RemoveAll(x => x.UserId == UserId && x.date == date && x.ParkSpaceId == ParkSpaceId);
            foreach (var ps in ParkSpaces)
            {
                if (ps.ParkSpaceId == ParkSpaceId && ps.date == date)
                    ps.availableSpaces = ps.availableSpaces + 1;
            }
            return "Reservation Cancelled";
        }
        public string AmendReservation(int UserId, int ParkSpaceId, DateTime date, int NewParkSpaceId, DateTime Newdate)
        {
            UserParkSpaces.RemoveAll(x => x.UserId == UserId && x.date == date && x.ParkSpaceId == ParkSpaceId);
            UserParkSpaces.Add(new UserParkSpace { UserId = UserId, ParkSpaceId = NewParkSpaceId, date=Newdate, status = "Booked" });
            foreach (var ps in ParkSpaces)
            {
                if (ps.ParkSpaceId == ParkSpaceId && ps.date == date)
                    ps.availableSpaces = ps.availableSpaces + 1;
                else if (ps.ParkSpaceId == NewParkSpaceId && ps.date == date)
                    ps.availableSpaces = ps.availableSpaces - 1;
            }
            return "Reservation Updated";
        }
        public string GetPrice(DateTime date)
        {
            string season = "summer"; // It can be set summer/winter
            int cost = 0;
            foreach (var ps in ParkSpaces)
            {
                if (ps.date == date)
                    cost = ps.Price;
            }
            if (season == "summer")
                return Convert.ToString(cost + 2);
            else
                return Convert.ToString(cost);
        }
    }
}
