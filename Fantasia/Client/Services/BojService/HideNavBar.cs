namespace Fantasia.Client.Services.BojService
{
    public class HideNavBar
    {
        public event EventHandler<string> NavbarUpdated;

        public async Task ToggleNavbarAsync()
        {
            bool isNavbarVisible = true;

            NavbarUpdated?.Invoke(this, isNavbarVisible ? "block" : "none");
        }
    }
}
