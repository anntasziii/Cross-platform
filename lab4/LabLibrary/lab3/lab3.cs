using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    public class Program
    {
        public static int CalculateResult(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int N = int.Parse(lines[0]); 
            char[,] board = new char[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = lines[i + 1][j];
                }
            }

            bool[,] visited = new bool[N, N];
            int atariCount = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 'B' && !visited[i, j]) 
                    {
                        List<(int, int)> group = new List<(int, int)>();
                        HashSet<(int, int)> dame = new HashSet<(int, int)>();

                        DFS(board, visited, i, j, group, dame); 

                        if (dame.Count == 1)
                        {
                            atariCount++;
                        }
                    }
                }
            }

            File.WriteAllText(outputFilePath, atariCount.ToString());
            return atariCount;
        }

        public static void DFS(char[,] board, bool[,] visited, int x, int y, List<(int, int)> group, HashSet<(int, int)> dame)
        {
            int N = board.GetLength(0);
            int[] dx = { -1, 1, 0, 0 }; 
            int[] dy = { 0, 0, -1, 1 }; 

            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((x, y)); 
            visited[x, y] = true; 

            while (stack.Count > 0)
            {
                var (cx, cy) = stack.Pop();
                group.Add((cx, cy)); 

                for (int i = 0; i < 4; i++)
                {
                    int nx = cx + dx[i];
                    int ny = cy + dy[i];

                    if (nx >= 0 && nx < N && ny >= 0 && ny < N)
                    {
                        if (board[nx, ny] == 'B' && !visited[nx, ny])
                        {
                            visited[nx, ny] = true;
                            stack.Push((nx, ny));
                        }
                        else if (board[nx, ny] == '.')
                        {
                            dame.Add((nx, ny));
                        }
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            string inputFilePath = "INPUT.TX";
            string outputFilePath = "OUTPUT.TXT";

            int result = CalculateResult(inputFilePath, outputFilePath);
            Console.WriteLine($"Atari count: {result}");
        }
    }
}
