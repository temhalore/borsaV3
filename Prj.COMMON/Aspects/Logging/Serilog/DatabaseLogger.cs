﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prj.COMMON.Helpers;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;

namespace Prj.COMMON.Aspects.Logging.Serilog
{
   public class DatabaseLogger:LoggerServiceBase
    {
        public DatabaseLogger()
        {
            var configuration = ServiceProviderHelper.ServiceProvider.GetService<IConfiguration>();
            var logConfig = configuration.GetSection("SeriLogConfigurations").Get<LogingConfigurationModel>() ??
                            throw new Exception("Null Options Message");
            var sinkOpts = new MSSqlServerSinkOptions
            {
                TableName = "Logs",
                AutoCreateSqlTable = true,
                BatchPostingLimit = 1
            };

            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.Exception);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);

            var seriLogConfig = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: logConfig.Serilog.MSSqlServer.ConnectionString,
                    sinkOptions: sinkOpts,
                    columnOptions: columnOptions
                    )
                .MinimumLevel.Verbose()
                .CreateLogger();

            Logger = seriLogConfig;
        }
    }
}
