using System;
using System.Linq;

namespace SolveApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 8, 4, 2, 6, 5 };
            string[] operators = new string[] { "+", "-", "*", "/", "%", "^" }; 

            int idx = 1;
            while (true)
            {
                Random rnd = new Random();
                int[] numbersShuffle = numbers.OrderBy(x => rnd.Next()).ToArray();

                string solve = "";
                double result = 0;
                for (int i = 1; i < numbersShuffle.Length; i++)
                {
                    int rndOperator = rnd.Next(0, 6);

                    result = Operator(operators[rndOperator], (i == 1 ? (double)numbersShuffle[i - 1] : result), numbersShuffle[i]);

                    solve = string.Format(@"{0} {1} {2}", (i == 1 ? numbersShuffle[i - 1].ToString() : solve), operators[rndOperator], numbersShuffle[i]);
                }

                if ((int)result == 497)
                {
                    Console.WriteLine("[Random: " + idx + "] " + solve + " = " + (int)result + " = 497");
                    break;
                }
                else
                {
                    Console.WriteLine("[Random: " + idx + "] " + solve + " = " + (int)result + " != 497");
                }

                idx++;
            }

            Console.ReadKey();
        }

        public static double Operator(string o, double n1, int n2)
        {
            double r = 0d;
            switch (o)
            {
                case "+": r = n1 + n2; break;
                case "-": r = n1 - n2; break;
                case "*": r = n1 * n2; break;
                case "/": r = n1 / n2; break;
                case "%": r = n1 % n2; break;
                case "^": r = Math.Pow(n1, n2); break;
            }
            return r;
        }
    }
}
