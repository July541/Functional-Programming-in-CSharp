using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.Generic
{
    class GenericClass
    {
        public static void ListTest()
        {
            var intItem = new ListItem<int>(10);

            var secondItem = intItem.Prepend(20);

            // It can't be compiled
            //var thirdItem = intItem.Prepend("string");
        }
    }

    class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }

        private ListItem(T value, ListItem<T> next)
            : this(value)
        {
            this._next = next;
        }

        public T Value { get; }
        private ListItem<T> _next;

        public ListItem<T> Prepend(T value)
        {
            return new ListItem<T>(value, this);
        }
    }
}
