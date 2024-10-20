using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace HairSellingApp.Tests
{
    public class HairSellingTests
    {
        private readonly ITestOutputHelper output;

        public HairSellingTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> ProfitTestData()
        {
            yield return new object[] { "5\n73 31 96 24 46\n", 380 };
            yield return new object[] { "3\n10 20 30\n", 60 };
            yield return new object[] { "4\n1 2 3 4\n", 10 };
            yield return new object[] { "5\n5 5 5 5 5\n", 75 };
        }

        [Theory]
        [MemberData(nameof(ProfitTestData))]
        public void TestCalculateMaxProfit(string inputData, int expectedProfit)
        {
            // Arrange
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");

            try
            {
                // Act
                File.WriteAllText(inputPath, inputData);
                Directory.SetCurrentDirectory(tempDir);
                Program.Main();

                // Assert
                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                Assert.Equal(expectedProfit.ToString(), result);
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void TestFileOperations()
        {
            // Arrange
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            string inputPath = Path.Combine(tempDir, "INPUT.TXT");
            string outputPath = Path.Combine(tempDir, "OUTPUT.TXT");
            string originalDirectory = Directory.GetCurrentDirectory();

            try
            {
                // Act
                File.WriteAllText(inputPath, "5\n73 31 96 24 46\n");
                Directory.SetCurrentDirectory(tempDir);
                Program.Main();

                // Assert
                Assert.True(File.Exists(outputPath), $"OUTPUT.TXT does not exist at {outputPath}");
                string result = File.ReadAllText(outputPath);
                Assert.Equal("380", result);
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDirectory);
                Directory.Delete(tempDir, true);
            }
        }
    }
}