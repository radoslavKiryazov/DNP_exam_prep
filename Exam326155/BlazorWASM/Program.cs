using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using BlazorWASM.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IStudentService, StudentHttpClient>();
builder.Services.AddScoped<IGradeService, GradeHttpClient>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7290") });

await builder.Build().RunAsync();