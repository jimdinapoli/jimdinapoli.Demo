using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SkullJocks.BenAdmin.App.Contracts;
using SkullJocks.BenAdmin.App.Services;
using SkullJocks.BenAdmin.App.Services.Base;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace SkullJocks.BenAdmin.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("https://skulljocksbenadminapi20210413190622.azurewebsites.net/")
            });

            builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://skulljocksbenadminapi20210413190622.azurewebsites.net/"));

            //builder.Services.AddSingleton(new HttpClient
            //{
            //    BaseAddress = new Uri("https://localhost:44342/")
            //});

            //builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:44342/"));

            builder.Services.AddScoped<ICustomerDataService, CustomerDataService>();
            builder.Services.AddScoped<ICustomerTypeDataService, CustomerTypeDataService>();

            await builder.Build().RunAsync();
        }
    }
}
