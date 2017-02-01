using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons4
{
    public class Solution
    {
        public int solution(int[] A)
        {
            int[] dp = Enumerable.Repeat(int.MinValue, A.Length).ToArray();

            dp[0] = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                //Get max from prev index
                int max = dp[i - 1];

                for (int dice = 1; dice <=6 && i - dice >= 0; dice++)
                {
                    int previousEntryByDiceSub = dp[i - dice];
                    max = Math.Max(previousEntryByDiceSub, max);
                    dice++;
                }

                dp[i] = max + A[i];
            }
            return dp[A.Length - 1];
        }

    }

    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod()
        {
            int[] arrayb = {1, -2, 0, 9, -1, -2};
            Assert.AreEqual(8, new Solution().solution(arrayb));
        }

      
    }
}
