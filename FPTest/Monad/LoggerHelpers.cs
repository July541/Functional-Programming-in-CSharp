using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.Monad
{
    public static class LoggerHelpers
    {
        public static Logger<T> ToLogger<T>(this T val)
        {
            return new Logger<T>(val);
        }

        public static Logger<T> ToLogger<T>(this T val, string message)
        {
            return new Logger<T>(val, message);
        }

        public static Logger<T> ToLogger<T>(this T val, string format, params object[] args)
        {
            return new Logger<T>(val, string.Format(format, args));
        }
    }
}
