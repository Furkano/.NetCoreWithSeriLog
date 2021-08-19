using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seri11.Logging.Concrete
{
    public abstract class LoggingConfiguration
    {
        protected abstract Logger GetLogger();

        public Logger InstanceLogger()
        {
            return default(Logger);
        }
    }
}
