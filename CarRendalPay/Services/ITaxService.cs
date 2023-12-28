using System;

namespace CarRendalPay.Services
{
    internal interface ITaxService
    {
        double Tax(double amount);
    }
}
