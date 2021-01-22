using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IChoosrAPI.Helpers;
using IChoosrAPI.Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IChoosrAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //configure services for the connection of the DB which refers to a json file with the data for the connection

            services.AddLogic(Configuration)
                    .AddData();

            services.AddSwaggerGen(c => SwaggerHelper.SetSwaggerOptions(c));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var v1 = SwaggerHelper.CreateEnpointInfo("v1");
                c.SwaggerEndpoint(v1.uri, v1.title);
                c.DisplayRequestDuration();
                c.DocumentTitle = "IChoosr";
                c.EnableValidator();
                if (!env.IsDevelopment()) c.SupportedSubmitMethods(new Swashbuckle.AspNetCore.SwaggerUI.SubmitMethod[] { });
                c.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
