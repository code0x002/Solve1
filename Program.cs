using System;
using System.Collections.Generic;
using System.Linq;

namespace SolveApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 8, 4, 2, 6, 5 };
            string[] operators = new string[] { "+", "-", "*", "/", "%", "^" };

            List<string> storageNumbersOperatorSet = new List<string>();

            int idx = 1;
            int ar = 1;
            while (true)
            {
                Random rnd = new Random();
                int[] numbersShuffle = numbers.OrderBy(x => rnd.Next()).ToArray();
                int[] randomOperatorSet = new int[] { rnd.Next(0, 6), rnd.Next(0, 6), rnd.Next(0, 6), rnd.Next(0, 6) };

                string numbersOperatorSet = numbersShuffle[0].ToString();
                for (int i = 1; i < numbersShuffle.Length; i++)
                {
                    numbersOperatorSet += string.Format(@"{0}{1}", operators[randomOperatorSet[i - 1]], numbersShuffle[i]);
                }

                if (!storageNumbersOperatorSet.Exists(x => x == numbersOperatorSet))
                {
                    storageNumbersOperatorSet.Add(string.Join("", numbersOperatorSet));

                    string solve = "";
                    double result = 0;
                    for (int i = 1; i < numbersShuffle.Length; i++)
                    {
                        int rndOperator = randomOperatorSet[i - 1];

                        result = Operator(operators[rndOperator], (i == 1 ? (double)numbersShuffle[i - 1] : result), numbersShuffle[i]);

                        solve = string.Format(@"{0} {1} {2}", (i == 1 ? numbersShuffle[i - 1].ToString() : solve), operators[rndOperator], numbersShuffle[i]);
                    }

                    if ((int)Math.Abs(result) == 497)
                    {
                        Console.WriteLine("[Random: " + idx + ", ARandom: " + ar + "] " + solve + " = " + (int)result + " = 497");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[Random: " + idx + ", ARandom: " + ar + "] " + solve + " = " + (int)result + " != 497");
                    }

                    idx++;
                }

                ar++;
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
