using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using ParkwaylabsExercise2;
using ParkwaylabsExercise2.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ParkwaylabsExercise2_Test
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.test.json")
            .Build();

            WebHostBuilder webHostBuilder = new WebHostBuilder();
            webHostBuilder.ConfigureServices(s => 
                s.AddDbContext<DevTeamDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection"))));
            webHostBuilder.UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);

            Client = server.CreateClient();
        }
    }
}
