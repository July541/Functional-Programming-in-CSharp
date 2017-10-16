using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.Generic
{
    class GenericFunctions
    {
        static void Apply<T>(IEnumerable<T> seqEnumerable, Action<T> action)
        {
            foreach (var item in seqEnumerable)
            {
                action(item);
            }
        }

        public void TestGenericFunctions()
        {
            var values = new List<int>()
            {
                1, 3, 4, 5, 7
            };
            Apply(values, v => Console.WriteLine("Value : {0}", v));
        }
    }
}
