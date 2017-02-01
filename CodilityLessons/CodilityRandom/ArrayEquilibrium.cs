using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest1
{
    public class ArrayEquilibrium
    {

        public int Solution(int[] A)
        {
            int leftSum = 0, rightSum = 0;
            int totalSum = 0;

            totalSum = A.Sum(x => x);

            //return first index of midsplit else return -1
            for (int i = 1; i < A.Length-1; i++)
            {
                leftSum += A[i-1];

                if (i > 1)
                {
                    rightSum = totalSum - A[i];
                    if (rightSum == leftSum) return i;
                }
            }
            return -1;
        }

        [Test]
        public void Test()
        {
            int[] C = {-7,1,5,2,-4,3,1 };
            Assert.AreEqual(3, new ArrayEquilibrium().Solution(C));
        }
    }
}
 