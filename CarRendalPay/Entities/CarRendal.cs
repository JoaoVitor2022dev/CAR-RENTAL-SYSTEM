using System;
using System.Collections.Generic;

namespace CarRendalPay.Entities
{
    internal class CarRendal
    {
        // relacionamente... um vehicle e um invoice 
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Invoice Invoice { get; set; }
        public Vehicle Vehicle { get; set; }

        public CarRendal(DateTime start, DateTime finish, Vehicle vehicle)
        {
            Start = start;
            Finish = finish;
            Vehicle = vehicle;
            Invoice = null; 
        } 
    }
}
