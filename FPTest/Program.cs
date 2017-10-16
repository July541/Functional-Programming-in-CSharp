using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPTest.Generic;
using FPTest.Monad;
using static FPTest.TestUtil.Test;

namespace FPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var g1 = new GenericFunctions();
            //g1.TestGenericFunctions();
            TEST(g1.TestGenericFunctions);
            
            var g2 = new LoggerTest();
            TEST(g2.TestLogger);
        }

    }
}
