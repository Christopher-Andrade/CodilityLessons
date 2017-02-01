using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest1
{
    public class Slice
    {
        public int solution(int[] A)
        {
            int smallestDiff = 20000;
            int diff = 0;

            int[] copy = new int[A.Length+1];

            for (int i = 1; i < copy.Length; i++)
            {
                copy[i] = copy[i - 1] + A[i - 1];
            }


            Array.Sort(copy);

            for (int i = 1; i < copy.Length; i++)
            {
                diff = copy[i] - copy[i - 1];
                if (diff < smallestDiff)
                {
                    smallestDiff = diff;
                }
            }

            return smallestDiff;
        }



        [Test]
        public void Test()
        {
            int[] C = { 2,-4,6,-3,9 };
            Assert.AreEqual(1, new Slice().solution(C));
        }
    }
}
