using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLot.Models
{
    public class ParkingSlotViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // --- MỚI: Thêm thuộc tính này ---
        public bool IsFull { get; set; }
    }
}