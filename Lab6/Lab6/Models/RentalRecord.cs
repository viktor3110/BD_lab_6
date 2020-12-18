using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class RentalRecord
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int DiscId { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime DateOfReturn { get; set; }
        public int PaymentCheck { get; set; }
        public int ReturnCheck { get; set; }
        public int EmployeeId { get; set; }
    }
}
