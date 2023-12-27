using CarRendalPay.Entities;
using System.Globalization;
using CarRendalPay.Services; 

namespace CarRendalPay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  entrada de dados 

            Console.WriteLine("Enter rental data");
            
            Console.Write("Car Model: ");
            string model = Console.ReadLine();

            Console.Write("Pickup (dd/MM/yyyy hh:mm:ss):  ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture );

            Console.Write("Return (dd/MM/yyyy hh:mm:ss):  ");
            DateTime finifh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // instaciamente do objeto CarRenatl 

            CarRendal carRendal = new CarRendal(start, finifh, new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day);

            rentalService.ProcessoInvoce(carRendal);

            Console.WriteLine("INVOCE:");
            Console.WriteLine(carRendal.Invoice);
        }
    }
}
