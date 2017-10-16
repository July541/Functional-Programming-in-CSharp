using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FPTest.Iterator
{
    class IteratorFunction
    {
        public void TestIteratorFunction()
        {
            var list = EndlessListFunction();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static IEnumerable<int> EndlessListFunction()
        {
            int val = 0;
            while (true)
                yield return val++;
        }

        public static IEnumerable<int> ThreeNumbers()
        {
            yield return 3;
            yield return 11;
            yield return 27;
        }
    }

    public class ThreeNumbersIterator : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator
    {
        private int _state;
        private int _currnt;
        private readonly int _initialThreadId;

        public ThreeNumbersIterator(int state)
        {
            this._state = state;
            this._initialThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        public bool MoveNext()
        {
            switch (_state)
            {
                case 0:
                    this._state = -1;
                    this._currnt = 3;
                    this._state = 1;
                    return true;
                case 1:
                    this._state = -1;
                    this._currnt = 11;
                    this._state = 2;
                    return true;
                case 2:
                    this._state = -1;
                    this._currnt = 27;
                    this._state = 3;
                    return true;
            }
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            if ((Thread.CurrentThread.ManagedThreadId == this._initialThreadId)
                && (this._state == -2))
            {
                _state = 0;
                return this;
            }
            return new ThreeNumbersIterator(0);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Current => _currnt;
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
