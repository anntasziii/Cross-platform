using System;
using System.IO;
using System.Linq;

namespace Lab1
{
    public class Program
    {
        // Метод для обчислення прибутку
        public static int CalculateProfit(string inputFilePath, string outputFilePath)
        {
            string[] input = File.ReadAllLines(inputFilePath);
            int N = int.Parse(input[0]);
            int[] prices = input[1].Split(' ').Select(int.Parse).ToArray();

            int[] maxPricesFromToday = new int[N];
            maxPricesFromToday[N - 1] = prices[N - 1];

            for (int i = N - 2; i >= 0; i--)
            {
                maxPricesFromToday[i] = Math.Max(prices[i], maxPricesFromToday[i + 1]);
            }

            int totalProfit = 0;
            int hairLength = 0;

            for (int i = 0; i < N; i++)
            {
                hairLength++;
                if (prices[i] == maxPricesFromToday[i])
                {
                    totalProfit += hairLength * prices[i];
                    hairLength = 0;
                }
            }

            File.WriteAllText(outputFilePath, totalProfit.ToString());
            return totalProfit;
        }

        // Метод Main - точка входу в програму
        public static void Main(string[] args)
        {
            // Шлях до вхідного та вихідного файлів
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";

            // Викликаємо метод для обчислення прибутку
            int result = CalculateProfit(inputFilePath, outputFilePath);
            Console.WriteLine($"Lab1 Result: {result}");
        }
    }
}
