namespace MyApp.Web.Models
{
    public class Lab1ViewModel
    {
        public int TaskNumber { get; set; } = 1;
        public int TaskVariant { get; set; } = 12;
        public string TaskDescription { get; set; } = "Завдання опис";
        public string InputDescription { get; set; } = "Опис вхідних даних";
        public string OutputDescription { get; set; } = "Опис вихідних даних";

        public List<TestCase1> TestCases { get; set; } = new List<TestCase1>
        {
            new TestCase1 { Input = "3\n10 20 30", Output = "300" }
        };
    }
}
