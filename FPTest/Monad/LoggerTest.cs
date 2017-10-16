using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTest.Monad
{
    /// <summary>
    /// For test only
    /// </summary>
    class Order
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }

    public class LoggerTest
    {
        public void TestLogger()
        {
            var orders = new List<Order>()
            {
                new Order() {Date = new DateTime(2017, 10, 16), Value = 36.5m},
                new Order() {Date = new DateTime(2017, 10, 15), Value = 42.3m},
                new Order() {Date = new DateTime(2017, 10, 16), Value = 22.3m}
            };

            var average = orders.ToLogger("Starting with a list of {0} orders", orders.Count)
                .Bind(l => l.Where(o => o.Date >= new DateTime(2017, 10, 16)).ToLogger(
                    "Got list with {0} items, filtering... ", l.Count))
                    .Bind(l => l.Average(o => o.Value)
                .ToLogger("Calculating average for list remaining with {0} items", l.Count()));

            Console.WriteLine("Result: " + average.Value);
            Console.WriteLine("----------Log Output: ");
            Console.Write(average.LogOutput());
        }
    }
}
