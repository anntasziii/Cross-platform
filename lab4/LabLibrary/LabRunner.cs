using System;

namespace LabLibrary
{
    public class LabRunner
    {
        public void RunLab1(string inputFilePath, string outputFilePath)
        {
            if (File.Exists(inputFilePath))
            {
                Console.WriteLine("Lab1 execution...");
                if (File.Exists(outputFilePath))
                {
                    lab1.Program.Lab1(new string[] { inputFilePath, outputFilePath });
                } 
                else
                {
                    lab1.Program.Lab1(new string[] { inputFilePath, "OUTPUT.txt" });
                }
                
                Console.WriteLine("Lab1 executed");
            }
        }

        public void RunLab2(string inputFilePath, string outputFilePath)
        {
            if (File.Exists(inputFilePath))
            {
                Console.WriteLine("Lab2 execution...");
                if (File.Exists(outputFilePath))
                {
                    lab2.Program.Lab2(new string[] { inputFilePath, outputFilePath });
                } 
                else
                {
                    lab2.Program.Lab2(new string[] { inputFilePath, "OUTPUT.txt" });
                }
                
                Console.WriteLine("Lab2 executed");
            }
        }

        public void RunLab3(string inputFilePath, string outputFilePath)
        {
            if (File.Exists(inputFilePath))
            {
                Console.WriteLine("Lab3 execution...");
                if (File.Exists(outputFilePath))
                {
                    lab3.Program.Lab3(new string[] { inputFilePath, outputFilePath });
                } 
                else
                {
                    lab3.Program.Lab3(new string[] { inputFilePath, "OUTPUT.txt" });
                }
                
                Console.WriteLine("Lab3 executed");
            }
        }
    }
}