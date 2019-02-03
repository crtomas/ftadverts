using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FTAdverts.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;
using Swashbuckle.AspNetCore.Swagger;

namespace api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
		
            services.Configure<Settings>(
            options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDb:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
                options.PaymentsCollection = Configuration.GetSection("MongoDb:PaymentsCollection").Value;                
            });      

            services.AddTransient<IPaymentContext, PaymentContext>(); 
            services.AddTransient<IPaymentRepository, PaymentRepository>(); 		
		
			//https://github.com/Microsoft/aspnet-api-versioning/tree/master/samples/aspnetcore/BasicSample
            services.AddApiVersioning(
               options =>
               {
                   // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                   options.ReportApiVersions = true;
			} );	
			
            services.AddCors(o => o.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FTAdverts API", Version = "v1" });
            });             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");

            var counter = Metrics.CreateCounter("PathCounter", "Counts requests to endpoints", new CounterConfiguration
            {
                LabelNames = new[] { "method", "endpoint" }
            });

            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FTAdverts API V1");
            });

            app.UseStatusCodePages();            
            app.UseMetricServer();

            AutoMapper.Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<Payment,PaymentDTO>();
                cfg.CreateMap<PaymentCreationDTO,Payment>();                
            });

            app.UseMvc();
        }
    }
}
