using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using Blazor.Clients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IAlbumClient, AlbumClientImpl>();
builder.Services.AddScoped<IImageClient, ImageClientImpl>();
builder.Services.AddScoped<IDisplayClient, DisplayClientImpl>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7066") });

await builder.Build().RunAsync();