using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.Monad
{
    public class Logger<T>
    {
        private readonly List<string> _outputLines;

        public T Value { get; private set; }

        public Logger(T val, List<string> outputLines)
        {
            this.Value = val;
            this._outputLines = outputLines;
        }

        public Logger(T val, string message)
            : this(val, new List<string>{message})
        {
            
        }

        public Logger(T val)
            : this(val, new List<string>())
        {
            
        }

        public string LogOutput()
        {
            var sb = new StringBuilder();
            foreach (var item in _outputLines)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }

        public Logger<R> Bind<R>(Func<T, Logger<R>> g)
        {
            var r = g(Value);
            _outputLines.AddRange(r._outputLines);
            return new Logger<R>(r.Value, _outputLines);
        }
    }
}
