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
            // Викликаємо метод Lab1 для розрахунку прибутку
            int result = Lab1.Program.CalculateProfit(inputFilePath, outputFilePath);
            Console.WriteLine($"Lab1 Result: {result}");
        }

        public void RunLab2(string inputFilePath, string outputFilePath)
        {
            // Викликаємо метод Lab2 для визначення переможця
            int winner = Lab2.Program.CalculateWinner(inputFilePath, outputFilePath);
            Console.WriteLine($"Lab2 Winner: {winner}");
        }

        public void RunLab3(string inputFilePath, string outputFilePath)
        {
            // Викликаємо метод Lab3 для обчислення результату
            int result = Lab3.Program.CalculateResult(inputFilePath, outputFilePath);
            Console.WriteLine($"Lab3 Result: {result}");
        }

        public static void Main(string[] args)
        {
            // Створюємо об'єкт LabRunner
            LabRunner runner = new LabRunner();

            // Шляхи до файлів
            string inputFilePath = "INPUT.TXT";
            string outputFilePath = "OUTPUT.TXT";

            // Запуск лабораторних робіт
            runner.RunLab1(inputFilePath, outputFilePath);  // Запуск Lab1
            runner.RunLab2(inputFilePath, outputFilePath);  // Запуск Lab2
            runner.RunLab3(inputFilePath, outputFilePath);  // Запуск Lab3
        }
    }
}
