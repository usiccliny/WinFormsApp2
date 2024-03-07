using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class SampleRow
    {
        public string brenchName { get; set; } 
        public string address { get; set; }
        public int number_of_seats { get; set; }
        public decimal reviews { get; set; }
        
        public SampleRow(string brenchName, string address, int number_of_seats, decimal reviews)
        {
            this.brenchName = brenchName;
            this.address = address;
            this.number_of_seats = number_of_seats;
            this.reviews = reviews;
        }
    }
}
