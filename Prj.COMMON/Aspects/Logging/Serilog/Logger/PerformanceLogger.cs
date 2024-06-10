
using Serilog;

namespace Prj.COMMON.Aspects.Logging.Serilog.Logger
{

    public class PerformanceLogger : LoggerServiceBase
    {
        public static ILogger _Logger;
        public PerformanceLogger()
        {
            this.Logger = _Logger;
            //var config = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            //Logger = LoggingConfiguration.Configuration(config, "performance").CreateLogger();
        }
    }
}
