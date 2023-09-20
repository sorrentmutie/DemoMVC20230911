using DemoRazorPages.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace DemoRazorPages.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly JwtOptions? options;
        private readonly JwtOptions? snapshot;
        private readonly JwtOptions? monitor;


        public string Message { get; set; } = "Your application description page.";
        public string SnapshotMessage { get; set; } = "Your application description page.";
        public string MonitorMessage { get; set; } = "Your application description page.";

        public PrivacyModel(ILogger<PrivacyModel> logger,
            IOptions<JwtOptions> options,
            IOptionsSnapshot<JwtOptions> snapshot,
            IOptionsMonitor<JwtOptions> monitor)
        {
            _logger = logger;
            this.options = options.Value;
            this.snapshot = snapshot.Value;
            this.monitor = monitor.CurrentValue;
        }

        public void OnGet()
        {
            Message = $"Settings: {options?.Issuer}";
            SnapshotMessage = $"Snapshot: {snapshot?.Issuer}";
            MonitorMessage = $"Monitor: {monitor?.Issuer}";
        }
    }
}