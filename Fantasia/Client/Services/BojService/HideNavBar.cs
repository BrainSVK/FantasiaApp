namespace Fantasia.Client.Services.BojService

{
    //nechal som si vygenerovať ChatGPT neupravoval som warningy
    public class HideNavBar
    {
        public event EventHandler<string> NavbarUpdated = delegate { };

        public async Task ToggleNavbarAsync()
        {
            await Task.Run(() =>
            {
                bool isNavbarVisible = true;

                NavbarUpdated?.Invoke(this, isNavbarVisible ? "block" : "none");
            });
        }
    }
}
