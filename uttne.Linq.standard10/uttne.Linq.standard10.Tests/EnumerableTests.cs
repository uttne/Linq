using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace uttne.Linq.standard10.Tests
{
    public class EnumerableTests
    {
        [Fact]
        public void PutInTest()
        {
            var source = new List<string>()
            {
                "aaaa",
                "bbbb",
                "cccc",
                "dddd",
                "eeee",
                "ffff",
            };

            var result = source.PutIn("gggg").ToList();

            var target = new List<string>()
            {
                "aaaa",
                "bbbb",
                "cccc",
                "dddd",
                "eeee",
                "ffff",
                "gggg",
            };

            Xunit.Assert.Equal(target,result);
        }
    }
}
