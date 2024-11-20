using System;
using Lab1;
using Lab2;
using Lab3;

namespace LabLibrary
{
    public class LabRunner
    {
        public void RunLab1(string inputFilePath, string outputFilePath)
        {
            int result = Lab1.Program.CalculateProfit(inputFilePath, outputFilePath);
            Console.WriteLine($"Lab1 Result: {result}");
        }

        public void RunLab2(string inputFilePath, string outputFilePath)
        {
            int winner = Lab2.Program.CalculateWinner(inputFilePath, outputFilePath);
            Console.WriteLine($"Lab2 Winner: {winner}");
        }

        public void RunLab3(string inputFilePath, string outputFilePath)
        {
            int result = Lab3.Program.CalculateResult(inputFilePath, outputFilePath);
            Console.WriteLine($"Lab3 Result: {result}");
        }

        public static void Main(string[] args)
        {
            LabRunner runner = new LabRunner();

            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";

            runner.RunLab1(inputFilePath, outputFilePath); 
            runner.RunLab2(inputFilePath, outputFilePath); 
            runner.RunLab3(inputFilePath, outputFilePath); 
        }
    }
}
