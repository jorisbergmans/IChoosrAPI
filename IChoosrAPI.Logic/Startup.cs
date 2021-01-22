using IChoosrAPI.Logic.StartupBuilder;
using Logic.Implementations;
using Logic.Services;
using Logic.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IChoosrAPI.Logic
{
    public static class Startup
    {
        public static ILogicBuilder AddLogic(this IServiceCollection services, IConfiguration configuration)
        {
            //Register interfaces here 
            services.AddScoped<ISearchHandler, SearchHandler>();
            services.AddScoped<ICSVHelper, CSVHelper>();

            return new LogicBuilder(services, configuration);
        }
    }
}
