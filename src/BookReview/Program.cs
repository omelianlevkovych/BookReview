using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace BookReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                     configuration.Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .Enrich.WithExceptionDetails()
                        .WriteTo.Debug()
                        .WriteTo.Console()
                        .WriteTo.Elasticsearch(ConfigureElasticSink(context))
                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .ReadFrom.Configuration(context.Configuration);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static ElasticsearchSinkOptions ConfigureElasticSink(HostBuilderContext context)
        {
            return new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
            {
                IndexFormat = GetELKIndexFormat(context),
                AutoRegisterTemplate = true,
                NumberOfReplicas = 1,
                NumberOfShards = 2,
            };
        }

        private static string GetELKIndexFormat(HostBuilderContext context)
        {
                // Application name can be changed to assebly name by using recursion.
                // Assembly.GetExecutingAssembly().GetName().Name
                // The approach with the application name from config file is easier to modify.
            return 
                $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".","-")}-{DateTime.UtcNow:yyyy-MM}";
        }
    }
}
