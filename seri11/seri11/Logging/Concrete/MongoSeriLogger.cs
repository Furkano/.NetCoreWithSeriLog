using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using seri11.Logging.Interfaces;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.IO;

namespace seri11.Logging.Concrete
{
    public class MongoSeriLogger : LoggingConfiguration, ILogManager
    {
        protected override Logger GetLogger()
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .Build();
            //var constr = configuration.GetSection("ConnectionStrings:LogConnection").Value;
            //var constr2 = configuration.GetConnectionString("ConnectionStrings");
            //var constr3 = configuration["ConnectionStrings:LogConnection"];
            //var constr4 = configuration.Providers;
            var client = new MongoClient(configuration["ConnectionStrings:LogConnection"]);
            var db = client.GetDatabase("Logging");
            return new LoggerConfiguration()
                //.WriteTo.MongoDBCapped(databaseUrl: configuration["ConnectionStrings:LogConnection"],collectionName:"seriLog")
                .WriteTo.MongoDBCapped(db,collectionName:"serilog")
                .CreateLogger();
        }
        public void Verbose(string message) => GetLogger().Verbose(message);
        public void Verbose<T>(string message, T t) => GetLogger().Verbose(message, t);
        public void Fatal(string message) => GetLogger().Fatal(message);
        public void Fatal<T>(string message, T t) => GetLogger().Fatal(message, t);
        public void Information(string message) => GetLogger().Information(message);
        public void Information<T>(string message, T t) => GetLogger().Information(message, t);
        public void Warning(string message) => GetLogger().Warning(message);
        public void Warning<T>(string message, T t) => GetLogger().Warning(message, t);
        public void Debug(string message) => GetLogger().Debug(message);
        public void Debug<T>(string message, T t) => GetLogger().Debug(message, t);
        public void Error(string message) => GetLogger().Error(message);
        public void Error<T>(string message, T t) => GetLogger().Error(message, t);
    }
}
