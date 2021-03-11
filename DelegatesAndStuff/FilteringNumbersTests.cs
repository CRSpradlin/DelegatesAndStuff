using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DelegatesAndStuff
{
    public class FilteringNumbersTests
    {
        [Fact]
        public void CanFilterOutEvens()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var numberFilter = new NumberFilter();

            List<int> result = numberFilter.FilterOutEvens(numbers);

            Assert.Equal(new List<int> { 1, 3, 5, 7, 9 }, result);
        }

        [Fact]
        public void CanFilterOutOdds()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var numberFilter = new NumberFilter();

            List<int> result = numberFilter.FilterOutOdds(numbers);

            Assert.Equal(new List<int> { 2,4,6,8 }, result);
        }
    }
}
