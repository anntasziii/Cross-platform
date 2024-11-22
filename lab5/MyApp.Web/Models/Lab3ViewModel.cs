namespace MyApp.Web.Models
{
    public class Lab3ViewModel
    {
        public int TaskNumber { get; set; } = 2;
        public int TaskVariant { get; set; } = 32;
        public string TaskDescription { get; set; }
        public string InputDescription { get; set; }
        public string OutputDescription { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public List<TestCase3> TestCases { get; set; }
    }

    public class TestCase3
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
