namespace MyApp.Web.Models
{
    public class Lab1ViewModel
    {
        public int TaskNumber { get; set; } = 1;
        public int TaskVariant { get; set; } = 32;
        public string TaskDescription { get; set; }
        public string InputDescription { get; set; }
        public string OutputDescription { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public List<TestCase1> TestCases { get; set; }
    }

    public class TestCase1
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
