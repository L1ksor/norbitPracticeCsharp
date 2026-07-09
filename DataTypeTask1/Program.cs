using System.Text;

namespace DataTypeTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double initialDeposit = Convert.ToDouble(Console.ReadLine());
            int years = Convert.ToInt32(Console.ReadLine());
            double interestRate = Convert.ToDouble(Console.ReadLine());

            string result = CalculationOfFunds(initialDeposit, years, interestRate);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Расчёт сложного процента по годам.
        /// </summary>
        /// <returns>Строка с расчётом депозита для каждого года.</returns>
        static string CalculationOfFunds (double initialDeposit , double years, double interestRate)
        {
            interestRate = (interestRate + 100) / 100;
            var resultDeposit = new StringBuilder();
            
            for (int year = 1; year <= years; year++)
            {
                initialDeposit = initialDeposit * interestRate;
                resultDeposit.Append($"Год {year}: {initialDeposit:f2} руб. \n");
            }

            return resultDeposit.ToString();
        }
    }
}
