using System;
using System.IO;

namespace lab2{
public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllText("INPUT.TXT").Split();
            int M = int.Parse(input[0]);
            int N = int.Parse(input[1]);

            bool[,] dp = new bool[M + 1, N + 1];

            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (i == 1 && j == 1) continue;
                    bool hasLosingMove = false;

                    for (int k = 1; k < i; k++)
                    {
                        if (!dp[k, j])
                        {
                            hasLosingMove = true;
                            break;
                        }
                    }
                    if (!hasLosingMove)
                    {
                        for (int k = 1; k < j; k++)
                        {
                            if (!dp[i, k])
                            {
                                hasLosingMove = true;
                                break;
                            }
                        }
                    }
                    if (!hasLosingMove)
                    {
                        for (int k = 1; k < Math.Min(i, j); k++)
                        {
                            if (!dp[i - k, j - k])
                            {
                                hasLosingMove = true;
                                break;
                            }
                        }
                    }
                    dp[i, j] = hasLosingMove;
                }
            }
            int winner = dp[M, N] ? 1 : 2;
            File.WriteAllText("OUTPUT.TXT", winner.ToString());
        }
    }
}
