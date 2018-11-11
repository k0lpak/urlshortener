using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace UrlShortener
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters();
            ConfigureDependencies(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddLambdaLogger();
            app.UseXRay("UrlShortener");
            app.UseMvc();
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            services.AddSingleton<IAmazonDynamoDB>(_ => new AmazonDynamoDBClient());
            services.AddScoped<IDynamoDBContext>((provider) => new DynamoDBContext(provider.GetService<IAmazonDynamoDB>()));
        }
    }
}
