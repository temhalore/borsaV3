
using Serilog;

namespace Prj.COMMON.Aspects.Logging.Serilog.Logger

{
    public class ExceptionLogger : LoggerServiceBase
    {
        public static ILogger _Logger;
        public ExceptionLogger()
        {
            this.Logger = _Logger;
            //var config = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            //Logger = LoggingConfiguration.Configuration(config,"exception").CreateLogger();
        }
    }
}
