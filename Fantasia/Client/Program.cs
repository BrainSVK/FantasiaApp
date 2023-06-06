global using Fantasia.Client.Services.AuthService;
global using Fantasia.Client.Services.PostavaService;
global using Fantasia.Client.Services.UtokyService;
global using Fantasia.Client.Services.BojService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using MudBlazor.Services;
using Fantasia.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPostavaService, PostavaService>();
builder.Services.AddScoped<IUtokyService, UtokyService>();
builder.Services.AddScoped<IBojService, BojService>();
builder.Services.AddScoped<HideNavBar, HideNavBar>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
