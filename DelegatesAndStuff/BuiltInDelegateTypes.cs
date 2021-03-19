using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DelegatesAndStuff
{
    public class BuiltInDelegateTypes
    {
        private readonly ITestOutputHelper output;

        public BuiltInDelegateTypes(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ActionTypes()
        {
            //Adds console outputs within test results
            output.WriteLine("Chris was here");

            // Action Types are abuilt-in delegate type for methods that return void
            // AND take 0 - 16 arguments
            Action doIt;

            doIt = () => output.WriteLine("Did it!");

            // The action code is only invoked when told to do so.
            doIt();

            Action<int, string> doItMultipleTimes;
            doItMultipleTimes = (times, message) =>
            {
                for (var t = 0; t < times; t++)
                {
                    output.WriteLine(message);
                }
            };

            doItMultipleTimes(10, "I just did it multiple times!!!");
        }

        [Fact]
        public void FuncTypes()
        {
            // Funcs are built-in delegate type for methods that:
            // - return something
            // - AND take up to 16 arguments

            // All the arguments go first, the last item is the return type
            Func<string, int> getLengthOf = (s) => s.Length;

            Func<int, int, int> mathOp;
            mathOp = (a, b) => a + b;
            Assert.Equal(4, mathOp(2, 2));

            mathOp = (a, b) => a * b;
            Assert.Equal(9, mathOp(3, 3));
            Assert.Equal(9, getLengthOf("Solo, Han"));

            var calculator = new Dictionary<char, Func<int, int, int>>()
            {
                {'+', (a,b) => a + b },
                {'-', (a,b) => a - b },
                {'*', (a,b) => a * b },
                {'/', (a,b) => a / b }
            };

            var product = calculator['*'](5, 5);
            Assert.Equal(25, product);
        }
    }
}
