using System;

namespace Lab6.ViewModels
{
    public class RentalRecordViewModel
    {
        public int Id { get; set; }
        public string ClientFIO { get; set; }
        public string DiscName { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime DateOfReturn { get; set; }
        public string PaymentCheck { get; set; }
        public string ReturnCheck { get; set; }
        public string EmployeeFIO { get; set; }
    }
}
