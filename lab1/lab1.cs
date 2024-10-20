using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = File.ReadAllLines("INPUT.TXT");
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
        File.WriteAllText("OUTPUT.TXT", totalProfit.ToString());
    }
}