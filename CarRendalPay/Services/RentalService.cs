using CarRendalPay.Entities;

namespace CarRendalPay.Services
{
    internal class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private BrazilTaxService _brazilTaxService = new BrazilTaxService();
        
        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessoInvoce(CarRendal carRendal)
        {
            
            // Forma correta de calcular a duração entre duas horas 
            TimeSpan duration = carRendal.Finish.Subtract(carRendal.Start);

            double basicPayment = 0.0;

            if (duration.TotalHours <= 12.0 )
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); 
            }
            else
            {
                basicPayment = PricePerDay  *  Math.Ceiling(duration.TotalDays);
            }

            // calculando a taxa de imposto    
            double tax = _brazilTaxService.Tax(basicPayment);

            // instaciando um valor que era nullo no inicio 
            carRendal.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
