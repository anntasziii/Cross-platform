using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace lab3.tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestDFS_NoAtari()
        {
            char[,] board = {
                { 'B', 'B', 'B' },
                { 'B', 'B', 'B' },
                { 'B', 'B', 'B' }
            };
            bool[,] visited = new bool[3, 3];
            List<(int, int)> group = new List<(int, int)>();
            HashSet<(int, int)> dame = new HashSet<(int, int)>();

            Program.DFS(board, visited, 0, 0, group, dame);

            Assert.AreEqual(9, group.Count);
            Assert.AreEqual(0, dame.Count);
        }

        [TestMethod]
        public void TestAtariCount_Example1()
        {
            string[] inputLines = {
                "9",
                ".........",
                ".........",
                ".........",
                "...WW....",
                "...BW.B..",
                "B..W.W...",
                "B...WBW..",
                "....WBW..",
                "W....BW.."
            };
            int atariCount = CountAtari(inputLines);
            Assert.AreEqual(2, atariCount);
        }

        [TestMethod]
        public void TestAtariCount_Example2()
        {
            string[] inputLines = {
                "6",
                "WB.WBB",
                ".B.W.B",
                "..WW.W",
                "WWW..W",
                "..W...",
                "BBW..."
            };
            int atariCount = CountAtari(inputLines);
            Assert.AreEqual(1, atariCount);
        }

        private int CountAtari(string[] lines)
        {
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
                        Program.DFS(board, visited, i, j, group, dame);

                        if (dame.Count == 1)
                        {
                            atariCount++;
                        }
                    }
                }
            }

            return atariCount;
        }
    }
}
