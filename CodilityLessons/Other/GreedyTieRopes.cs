using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons2
{
    class Solution
    {
        public int solution(int K, int[] A)
        {
            int n = A.Length;

            int count = 0;
            int prevLength = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] >= K || prevLength + A[i] >= K)
                {
                    count++;
                    prevLength = 0;
                }
                else
                {
                    prevLength += A[i];
                }
            }

            return count;
        }
    }

    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod()
        {
            int[] array = {1, 2, 3, 4, 1, 1, 3};
            Assert.AreEqual(3, new Solution().solution(4, array));

        }
    }
}
