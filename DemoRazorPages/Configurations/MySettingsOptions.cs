using System.ComponentModel.DataAnnotations;

namespace DemoRazorPages.Configurations;

public class MySettingsOptions
{
    public const string ConfigurationSectionName = "MyCustomSettingsSection";

    [RegularExpression(@"[\w\d]{2,18}")]
    public required string Title { get; set; }

    [Range(0,100, ErrorMessage ="Il valore per {0} deve essere compreso tra {1} e {2}")]
    public required int Scale { get; set; }

    public required int VerbosityLevel { get; set; }

}
