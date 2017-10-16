using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.Iterator
{
    class EnumerateElement
    {
    }

    public class EndlessListWithInterfaces : IEnumerable, IEnumerator
    {
        public EndlessListWithInterfaces()
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current => "something";

        public bool MoveNext()
        {
            return true;
        }

        public void Reset()
        {
            
        }
    }
}
