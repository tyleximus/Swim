using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Swim.App;
using Swim.App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

var apiUrl = builder.Configuration["apiUrl"] ?? builder.HostEnvironment.BaseAddress;

builder.Services
  .AddScoped<IHttpService, HttpService>()
  .AddScoped<ILocalStorageService, LocalStorageService>()
  .AddScoped<ISwimService, SwimService>()
  .AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });

await builder.Build().RunAsync();
