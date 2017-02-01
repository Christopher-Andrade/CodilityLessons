using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons3
{
    public class Solution
    {
        public int solution(int[] A, int[] B)
        {

            if (A.Length < 1 || A.Length == 1) return 0;

            int en = -1;
            int segmentCountThatDoesntOverlap = 0;

            for (int seg = 0; seg < A.Length; seg++)
            {
                Console.WriteLine($"Segment: {seg}, Start Of Seg: {A[seg]} En: {en}");

                if (A[seg] > en)
                {
                    //Increase count
                    segmentCountThatDoesntOverlap++;
                    //set EN to The end index of current segment
                    en = B[seg];
                }
            }
            return segmentCountThatDoesntOverlap;


        }
    }

    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod()
        {
            int[] array = {1, 3, 7, 9, 9};
            int[] arrayb = {5, 6, 8, 9, 10};
            Assert.AreEqual(3, new Solution().solution(array, arrayb));
        }

        [Test]
        public void TestMethod2()
        {
            int[] array = {  };
            int[] arrayb = {  };
            Assert.AreEqual(0, new Solution().solution(array, arrayb));
        }

        [Test]
        public void TestMethod3()
        {
            int[] array = {1 };
            int[] arrayb = { 5};
            Assert.AreEqual(0, new Solution().solution(array, arrayb));
        }
    }
}
