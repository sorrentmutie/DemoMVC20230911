namespace DemoRazorPages.Configurations
{
    public class Features
    {
        public const string FirstFeature = nameof(FirstFeature);
        public const string SecondFeature = nameof(SecondFeature);
        public bool Enabled { get; set; }
        public string?  ApiKey { get; set; }
    }
}
