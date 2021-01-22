using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace IChoosrAPI.Helpers
{
    internal class SwaggerHelper
    {
        internal static void SetSwaggerOptions(SwaggerGenOptions c)
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "IChoosrAPI",
                Description = "Api for getting data from Camera CSV file",
                Contact = new OpenApiContact
                {
                    Name = "IChoosr",
                }
            });
        }

        internal static (string uri, string title) CreateEnpointInfo(string version)
        {
            return ($"/swagger/{version}/swagger.json", $"IChoosrAPI {version}");
        }
    }
}
