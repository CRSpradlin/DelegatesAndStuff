using System;
using System.Collections.Generic;

namespace DelegatesAndStuff
{
    //creating a delegate that matches the IsOdd and IsEven signitures
    //so we can pass this as kind-of a function pointer
    public delegate bool FilterMethod(int x);
    //on line 28, don't need to specifiy the delegate type because it is already defined here

    public class NumberFilter
    {
        public NumberFilter()
        {
        }

        public List<int> FilterOutOdds(List<int> numbers)
        {
            //return Filter(numbers, IsOdd);
            return Filter(numbers, delegate (int x)
            {
                return x % 2 == 0;
            });
        }

        public List<int> FilterOutEvens(List<int> numbers)
        {
            //return Filter(numbers, IsEven);
            return Filter(numbers, theNumber => theNumber % 2 != 0 );
        }

        // We can also do the code below because a Predicate always returns a boolean and we specify what it takes in.
        // In this case, it is an integer parameter.
        // private List<int> Filter(List<int> numbers, Predicate<int> op)
        private List<int> Filter(List<int> numbers, FilterMethod op)
        {
            var results = new List<int>();
            foreach (var number in numbers)
            {
                if (op(number))
                {
                    results.Add(number);
                }
            }
            return results;
        }

        //private bool IsOdd(int number)
        //{
        //    return number % 2 == 0;
        //}

        //private bool IsEven(int number)
        //{
        //    return number % 2 != 0;
        //}
    }
}