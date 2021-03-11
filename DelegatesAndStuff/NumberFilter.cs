using System;
using System.Collections.Generic;

namespace DelegatesAndStuff
{

    public delegate bool FilterMethod(int x);
    public class NumberFilter
    {
        public List<int> FilterOutEvens(List<int> numbers)
        {
           // var isOdd = new FilterMethod(IsOdd);
            return Filter(numbers, delegate(int x)
            {
                return x % 2 != 0;
            });
        }

    

        public List<int> FilterOutOdds(List<int> numbers)
        {
            //var tacos = new FilterMethod(IsEven);
            return Filter(numbers, (x) => x % 2 ==0);
        }

        private List<int> Filter(List<int> numbers, Func<int, bool> op)
        {
            var results = new List<int>();
            foreach (var num in numbers)
            {
                if (op(num))
                {
                    results.Add(num);
                }
            }
            return results;
        }

        private  bool IsEven(int num)
        {
            return num % 2 == 0;
        }
        //private bool IsOdd(int num)
        //{
        //    return num % 2 != 0;
        //}
    }
}