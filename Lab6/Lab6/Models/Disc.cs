using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public class Disc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Creater { get; set; }
        public string Country { get; set; }
        public string MainActor { get; set; }
        public DateTime DateOfRecord { get; set; }
        public int Genre { get; set; }
        public string TypeOfDisc { get; set; }
        public decimal Price { get; set; }
    }
}
