using System.ComponentModel.DataAnnotations;

namespace FutureValue.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Please enter a monthly investment.")]
        [Range(1, 500000, ErrorMessage = "Monthly investment must be between 1 and 500000.")]
        public decimal? MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Please enter a yearly interest rate.")]
        [Range(0.1, 20.0, ErrorMessage = "Yearly interest rate must be between 0.1 and 20.0.")]
        public decimal? YearlyInterestRate { get; set; }

        [Required(ErrorMessage = "Please enter a number of years.")]
        [Range(1, 50, ErrorMessage = "Number of years must be between 1 and 50.")]
        public int? Years { get; set; }

        public decimal? Calculate()
        {
            int months = Years.Value * 12;
            decimal monthlyRate = YearlyInterestRate.Value / 100m / 12m;
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment.Value) * (1 + monthlyRate);
            }
            return futureValue;
        }
    }
}
