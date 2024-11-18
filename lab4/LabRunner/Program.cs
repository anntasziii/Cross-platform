using System;

namespace LabRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner runner = new Runner();
            runner.Execute(args);
        }
    }
}