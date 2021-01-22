using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IChoosrAPI.Logic.StartupBuilder
{
    internal class LogicBuilder : ILogicBuilder
    {
        private IServiceCollection services;
        private readonly IConfiguration configuration;

        public LogicBuilder(IServiceCollection services, IConfiguration configuration)
        {
            this.services = services;
            this.configuration = configuration;
        }

        public ILogicBuilder AddData()
        {
            //Add the service from the Data class in the IChoosr.Data project for the DB.
            return this;
        }
    }
}
