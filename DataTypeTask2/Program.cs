using System.Text;

namespace DataTypeTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Rhomb(n));
        }

        
        /// <summary>
        /// Отрисовка ромба
        /// </summary>
        /// <param name="n">Длина диагонали</param>
        /// <returns>Строка из X </returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        static string Rhomb(int n)
        {
            if (n % 2 == 0 || n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Число должно быть положительным нечётным целым");
            }

            string spaces = new string (' ', n/2);
            string topRhomb = spaces + 'X' + spaces + '\n';
            var result = new StringBuilder(topRhomb);

            if (n == 1)
            {
                return result.ToString();
            }

            string row;
            int outerSpaces;
            int innerSpaces = 1;
            for (int i = 1; i < n/2; i++)
            {
                outerSpaces = n/2 - i;
                row = new string(' ', outerSpaces) + 'X' + new string(' ', innerSpaces) + 'X' + new string(' ', outerSpaces) + '\n';
                result.Append(row);
                innerSpaces += 2;
            }

            for (int i = 0; i < n/2; i++)
            {
                outerSpaces = i;
                row = new string(' ', outerSpaces) + 'X' + new string(' ', innerSpaces) + 'X' + new string(' ', outerSpaces) + '\n';
                result.Append(row);
                innerSpaces -= 2;
            }

            result.Append(topRhomb);

            return result.ToString() ;

        }
    }
}
