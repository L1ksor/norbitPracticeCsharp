namespace DataTypeTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Rhomd(N));
        }

        static string Rhomd(int N)
        {
            if (N % 2 == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(N), "Число должно быть положительным нечётным целым");
            }
            string str = new string (' ', N/2);
            string result = str + 'X' + str + '\n';
            string str2 = result;
            string str3;
            int left;
            int innerSpaces =  1;
            for (int i = 1; i < N/2; i++)
            {
                left = N/2 - i;
                

                str3 = new string(' ', left) + 'X' + new string(' ', innerSpaces) + 'X' + new string(' ', left) + '\n';
                str2 = str2 + str3;
                innerSpaces += 2;
            }

            for (int i = 0; i < N/2; i++)
            {
                left = i;


                str3 = new string(' ', left) + 'X' + new string(' ', innerSpaces) + 'X' + new string(' ', left) + '\n';
                str2 = str2 + str3;
                innerSpaces -= 2;
            }

            return str2 + str + 'X' + str + '\n';

        }
    }
}
