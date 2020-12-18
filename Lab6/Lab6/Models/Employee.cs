using System;
using System.Collections.Generic;

namespace Lab6.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public DateTime DateOfWorkStart { get; set; }
        public string Position { get; set; }
    }
}
