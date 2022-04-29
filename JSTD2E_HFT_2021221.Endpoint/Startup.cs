using JSTD2E_HFT_2021221.Data;
using JSTD2E_HFT_2021221.Endpoint.Services;
using JSTD2E_HFT_2021221.Logic;
using JSTD2E_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsDb.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IBuyerLogic, BuyerLogic>();
            services.AddTransient<IGameLogic, GameLogic>();
            services.AddTransient<IDeveloperTeamLogic, DeveloperLogic>();
            services.AddTransient<IBuyerRepository, BuyerRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IDeveloperTeamRepository, DeveloperTeamRepository>();
            services.AddTransient<ModelsDbContext, ModelsDbContext>();

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
