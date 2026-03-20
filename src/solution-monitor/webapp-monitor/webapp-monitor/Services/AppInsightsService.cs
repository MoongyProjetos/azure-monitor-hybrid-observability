using Microsoft.JSInterop;

namespace webapp_monitor.Services
{
    public class AppInsightsService
    {
        private readonly IJSRuntime _js;

        public AppInsightsService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task TrackPage(string page)
        {
            await _js.InvokeVoidAsync("appInsights.trackPageView", new
            {
                name = page,
                uri = page
            });
        }
    }
}
