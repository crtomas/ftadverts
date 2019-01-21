using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			//https://github.com/Microsoft/aspnet-api-versioning/tree/master/samples/aspnetcore/BasicSample
            //services.AddApiVersioning(
            //    options =>
            //    {
            //        // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
            //        options.ReportApiVersions = true;
			//} );	
			//
            services.AddCors(o => o.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("{\"api\": \"ftadvertsv15\"}");
            });
        }
    }
}
