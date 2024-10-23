using System;
using System.IO;
using NUnit.Framework;

namespace lab2.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void TestGame_WithWinningPosition()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");
            string originalDirectory = Directory.GetCurrentDirectory();

            try
            {
                File.WriteAllText(inputPath, "3 4");
                TestContext.WriteLine($"Created INPUT.TXT with contents: 3 4 at {inputPath}");

                Directory.SetCurrentDirectory(tempDir);
                TestContext.WriteLine($"Changed current directory to {tempDir}");
                Program.Main(null);

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                TestContext.WriteLine($"Content of OUTPUT.TXT: {result}");
                Assert.AreEqual("1", result);
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
                Directory.Delete(tempDir, true);
            }
        }

        [Test]
        public void TestGame_WithLosingPosition()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");
            string originalDirectory = Directory.GetCurrentDirectory();

            try
            {
                File.WriteAllText(inputPath, "1 1");
                TestContext.WriteLine($"Created INPUT.TXT with contents: 1 1 at {inputPath}");

                Directory.SetCurrentDirectory(tempDir);
                TestContext.WriteLine($"Changed current directory to {tempDir}");
                Program.Main(null);

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                TestContext.WriteLine($"Content of OUTPUT.TXT: {result}");
                Assert.AreEqual("2", result); 
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
                Directory.Delete(tempDir, true);
            }
        }

        [Test]
        public void TestGame_AnotherScenario()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");
            string originalDirectory = Directory.GetCurrentDirectory();

            try
            {
                File.WriteAllText(inputPath, "2 3");
                TestContext.WriteLine($"Created INPUT.TXT with contents: 2 3 at {inputPath}");

                Directory.SetCurrentDirectory(tempDir);
                TestContext.WriteLine($"Changed current directory to {tempDir}");
                Program.Main(null);

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                TestContext.WriteLine($"Content of OUTPUT.TXT: {result}");
                Assert.AreEqual("2", result); 
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
                Directory.Delete(tempDir, true);
            }
        }

        [Test]
        public void TestGame_WithLargeValues()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");
            string originalDirectory = Directory.GetCurrentDirectory();

            try
            {
                File.WriteAllText(inputPath, "10 10");
                TestContext.WriteLine($"Created INPUT.TXT with contents: 10 10 at {inputPath}");

                Directory.SetCurrentDirectory(tempDir);
                TestContext.WriteLine($"Changed current directory to {tempDir}");
                Program.Main(null);

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                TestContext.WriteLine($"Content of OUTPUT.TXT: {result}");
                Assert.AreEqual("1", result); 
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
                Directory.Delete(tempDir, true);
            }
        }

        [Test]
        public void TestGame_WithEdgeCase()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");
            string originalDirectory = Directory.GetCurrentDirectory();

            try
            {
                File.WriteAllText(inputPath, "5 5");
                TestContext.WriteLine($"Created INPUT.TXT with contents: 5 5 at {inputPath}");

                Directory.SetCurrentDirectory(tempDir);
                TestContext.WriteLine($"Changed current directory to {tempDir}");
                Program.Main(null);

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                TestContext.WriteLine($"Content of OUTPUT.TXT: {result}");
                Assert.AreEqual("1", result);
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
                Directory.Delete(tempDir, true);
            }
        }

        [Test]
        public void TestGame_WithNonSquareValues()
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");
            string originalDirectory = Directory.GetCurrentDirectory();

            try
            {
                File.WriteAllText(inputPath, "4 6");
                TestContext.WriteLine($"Created INPUT.TXT with contents: 4 6 at {inputPath}");

                Directory.SetCurrentDirectory(tempDir);
                TestContext.WriteLine($"Changed current directory to {tempDir}");
                Program.Main(null);

                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                TestContext.WriteLine($"Content of OUTPUT.TXT: {result}");
                Assert.AreEqual("2", result); 
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
                Directory.Delete(tempDir, true);
            }
        }
    }
}
