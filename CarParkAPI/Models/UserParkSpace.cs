using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAPI.Models
{
    public class UserParkSpace
    {
        public int UserId { get; set; }

        public int ParkSpaceId { get; set; }
        public DateTime date { get; set; }

        public string status { get; set; }

    }
}
