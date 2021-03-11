using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DelegatesAndStuff
{
    public class TypesofBuiltInDelegates
    {

        [Fact]
        public void Actions()
        {
            // actions can refer to void methods that take 1-16 arguments.
            // if you need more than 16 arguments, rethink your life.

            Action<string, int> doIt = LogIt;

            doIt("Hi", 500);

            doIt = delegate (string w, int y)
            {
                // some code here.
            };

            doIt("Hi", 1000);

            doIt = (x, y) =>
            {

            };

            doIt("dog", 36);

             
        }
        [Fact]
        public void Funcs()
        {
            Func<int, int, int> mathOp;

            mathOp = Add;
            Assert.Equal(22, mathOp(20, 2));

            mathOp = delegate (int a, int b)
            {
                return a * b;
            };

            Assert.Equal(9, mathOp(3, 3));

            mathOp = (a, b) => a - b;

            Assert.Equal(5, mathOp(10, 5));
        }

        [Fact]
        public void Predicate()
        {
            Predicate<string> doYouLike;


            doYouLike = (topping) =>
            {
                if (topping == "cheese" || topping == "onions")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            Assert.True(doYouLike("cheese"));
            Assert.False(doYouLike("pineapple"));
        }

        public void LogIt(string what, int howManyTimes)
        {

        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
