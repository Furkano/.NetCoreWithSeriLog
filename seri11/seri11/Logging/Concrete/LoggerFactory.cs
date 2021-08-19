using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seri11.Logging.Concrete
{
    public class LoggerFactory
    {
        private LoggerFactory()
        {

        }
        static readonly object _lock = new object();
        private static MongoSeriLogger _mongoSeriLogger;

        public static MongoSeriLogger MongoLogManager()
        {
            if (_mongoSeriLogger == null)
            {
                lock (_lock)
                {
                    if (_mongoSeriLogger == null)
                    {
                        _mongoSeriLogger = new MongoSeriLogger();
                    }
                }
            }
            return _mongoSeriLogger;
        }
    }
}
