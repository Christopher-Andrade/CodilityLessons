using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest
{
    public class Test3
    {
        public int solution(int[] A)
        {
            int ans = 0;

            return ans;
        }

        [Test]
        public void TestMethod()
        {
            int[] arrayb = { 1, -2, 0, 9, -1, -2 };
            Assert.AreEqual(8, new Test3().solution(arrayb));
        }
    }
}