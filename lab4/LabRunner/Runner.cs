using System;
using McMaster.Extensions.CommandLineUtils;
using System.IO;

namespace LabRunner
{
    public class Runner
    {
        public void Execute(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "Lab4",
                Description = "Console application for running lab works"
            };

            app.Command("version", (command) =>
            {
                command.OnExecute(() =>
                {
                    ShowVersion();
                    return 0;
                });
            });

            app.Command("run", (command) =>
            {
                var labOption = command.Option("-l|--lab <LAB>", "Lab for execution (lab1, lab2, lab3)", CommandOptionType.SingleValue);
                var inputOption = command.Option("-i|--input <INPUT>", "Input file", CommandOptionType.SingleValue);
                var outputOption = command.Option("-o|--output <OUTPUT>", "Output file", CommandOptionType.SingleValue);

                command.OnExecute(() =>
                {
                    if (!labOption.HasValue())
                    {
                        Console.WriteLine("A subcommand is needed: lab1, lab2, or lab3");
                    } 
                    else 
                    {
                        string inputPath = GetInputFilePath(inputOption.Value());
                        if (inputPath == null)
                        {
                            Console.WriteLine("Input file not found.");
                        }

                        string outputPath = GetOutputFilePath(outputOption.Value());
                        if (outputPath == null)
                        {
                            Console.WriteLine("Output file not found.");
                        }

                        RunLab(labOption.Value(), inputPath, outputPath);
                    }
                });
            });

            app.Command("set-path", (command) =>
            {
                var pathOption = command.Option("-p|--path <PATH>", "Path to your folder with files", CommandOptionType.SingleValue);

                command.OnExecute(() =>
                {
                    if (!pathOption.HasValue())
                    {
                        Console.WriteLine("The path to the file folder is required.");
                        return 1;
                    }

                    SetPath(pathOption.Value());
                    return 0;
                });
            });

            app.HelpOption("-?|-h|--help");

            // Keep the application running until the "exit" command is given
            while (true)
            {
                Console.Write("> "); // Prompt for input
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue; // Skip if input is empty
                }

                // Check for exit command
                if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting the application...");
                    break; // Exit the loop
                }

                // Execute commands
                try
                {
                    app.Execute(input.Split(' '));
                }
                catch (CommandParsingException)
                {
                    Console.WriteLine("Unsupported command. Please check the command syntax.");
                }
            }
        }

        private void ShowVersion()
        {
            Console.WriteLine("Program: Lab4 LabRunner");
            Console.WriteLine("Author: Anastasiia Kushnir");
            Console.WriteLine("Version: 1.0.0");
        }

        private void RunLab(string lab, string inputPath, string outputPath)
        {
            var labRunner = new LabLibrary.LabRunner();
            switch (lab.ToLower())
            {
                case "lab1":
                    labRunner.RunLab1(inputPath, outputPath);
                    break;
                case "lab2":
                    labRunner.RunLab2(inputPath, outputPath);
                    break;
                case "lab3":
                    labRunner.RunLab3(inputPath, outputPath);
                    break;
                default:
                    Console.WriteLine("Incorrect lab.");
                    break;
            }
        }

        private void SetPath(string path)
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path);
            Console.WriteLine($"The path is set: {path}");
        }

        private string GetInputFilePath(string inputFileName)
        {
            // First, check the command-line parameter
            if (!string.IsNullOrEmpty(inputFileName) && File.Exists(inputFileName))
            {
                return inputFileName;
            }

            // Then check the LAB_PATH environment variable
            string labPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (!string.IsNullOrEmpty(labPath))
            {
                string fullPath = Path.Combine(labPath, "INPUT.txt");
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            // Finally, check the user's home directory
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string homePath = Path.Combine(homeDirectory, "INPUT.txt");
            if (File.Exists(homePath))
            {
                return homePath;
            }

            // If not found, return null
            return null;
        }

        private string GetOutputFilePath(string outputFileName)
        {
            // First, check the command-line parameter
            if (!string.IsNullOrEmpty(outputFileName) && File.Exists(outputFileName))
            {
                return outputFileName;
            }

            // Then check the LAB_PATH environment variable
            string labPath = Environment.GetEnvironmentVariable("LAB_PATH");
            if (!string.IsNullOrEmpty(labPath))
            {
                string fullPath = Path.Combine(labPath, "OUTPUT.txt");
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            // Finally, check the user's home directory
            string homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string homePath = Path.Combine(homeDirectory, "OUTPUT.txt");
            if (File.Exists(homePath))
            {
                return homePath;
            }

            // If not found, return null
            return null;
        }
    }
}