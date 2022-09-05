using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAPI.Models
{
    public class ParkSpace
    {
        public int ParkSpaceId { get; set; }
        public int Price { get; set; }
        public DateTime date { get; set; }
        public int availableSpaces { get; set; }
    }
}
