using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons7
{
    public class Solution
    {
        public int solution(int[] A)
        {
            int maxDepthCount = 0;
            int highestPointLeft = A[0];
            int poolWidth = 0;
            int highestPointRight = A[0];
            int bottom = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                int currentRockHeight = A[i];
                //Assign left wall
                if (currentRockHeight >= highestPointLeft)
                {
                    if (poolWidth > 0)
                    {
                        //Calculate depth
                        maxDepthCount = Math.Max(maxDepthCount, CalculateDepthOfCurrentPool(highestPointLeft, currentRockHeight, bottom));
                    }
                    bottom = currentRockHeight;
                    poolWidth = 0;
                    highestPointLeft = currentRockHeight;
                    highestPointRight = currentRockHeight;
                }

                //Descending from left high into possible pool
                else if (currentRockHeight < highestPointLeft)
                {
                    bottom = Math.Min(bottom, currentRockHeight);

                    //Mini pool 
                    if (currentRockHeight > bottom)
                    {
                        maxDepthCount = Math.Max(maxDepthCount, CalculateDepthOfCurrentPool(highestPointLeft, currentRockHeight, bottom));
                    }

                    if (currentRockHeight > highestPointRight) highestPointRight = currentRockHeight;
                    poolWidth++;
                }

            }

            return maxDepthCount;
        }

        private int CalculateDepthOfCurrentPool(int leftPoint, int currentRockHeight, int bottom)
        {
            int calculatedDepth = Math.Min(leftPoint, currentRockHeight) - bottom;
            return calculatedDepth;
        }
    }

    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod()
        {
            int[] s = new int[]{1,3,2,1,2,1,5,3,3,4,2};
            Assert.AreEqual(2, new Solution().solution(s));
        }

        [Test]
        public void TestMethod2()
        {
            int[] s = new int[] { 1000000000 };
            Assert.AreEqual(0, new Solution().solution(s));
        }

        [Test]
        public void TestMethod3()
        {
            int[] s = new int[] { 5,4,3,2,1 };
            Assert.AreEqual(0, new Solution().solution(s));
        }

        [Test]
        public void TestMethod4()
        {
            int[] s = new int[] { 1,2,3,4,5 };
            Assert.AreEqual(0, new Solution().solution(s));
        }

        [Test]
        public void TestMethod5()
        {
            int[] s = new int[] { 1, 2, 3, 2, 3, 1,4,6,8,9,1,6 };
            Assert.AreEqual(5, new Solution().solution(s));
        }

        [Test]
        public void TestMethod6()
        {
            int[] s = new int[] { 9,1,1,1,1,1,1,1,1,1,9};
            Assert.AreEqual(8, new Solution().solution(s));
        }

        [Test]
        public void TestMethod7()
        {
            int[] s = new int[] { 2,1,2,1,2,1,2,1,2,1,2,1,2};
            Assert.AreEqual(1, new Solution().solution(s));
        }

        [Test]
        public void TestMethod8()
        {
            int[] s = new int[] { 5,4,3,2,1,2,3,4,5,1,6,1,7 };
            Assert.AreEqual(5, new Solution().solution(s));
        }

        [Test]
        public void TestMethod9()
        {
            int[] s = new int[] { 1,9,3,9,1 };
            Assert.AreEqual(6, new Solution().solution(s));
        }
    }
}
