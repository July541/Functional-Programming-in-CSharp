using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.TestUtil
{
    class Test
    {
        public static void TEST(Action action)
        {
            PrintStartLine(action.Method.ToString());
            action();
            PrintEndLine(action.Method.ToString());
        }

        static void PrintStartLine(string funcName)
        {
            Console.WriteLine("-----------------------{0} start -----------------------", funcName);
        }

        static void PrintEndLine(string funcName)
        {
            Console.WriteLine("------------------------{0} end ------------------------\n", funcName);
        }
    }
}
