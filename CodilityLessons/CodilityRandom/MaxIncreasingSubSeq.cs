using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest1
{
    public class MaxIncreasingSubSeq
    {
        public int CalcMaxSubSeq(int[] A )
        {
            int[] totalUpto = new int[A.Length];
            int[] pathTo = new int[A.Length];

            Array.Copy(A, totalUpto, A.Length);

            //set paths to default at element
            for (int i = 0; i < pathTo.Length; i++)
            {
                pathTo[i] = i;
            }


            //Loop through all ele
            for (int i = 0; i < A.Length; i++)
            {
                //Search for increasing elements before.
                for (int j = 0; j < i; j++)
                {
                    int valI = 0, valJ = 0;
                    valI = A[i];
                    valJ = A[j];
                    if (A[i] > A[j])
                    {
                        //Compare current seq max to prev seq max. take largest
                        int totalUptoPrev = totalUpto[j] + A[i];
                        int totalForThisSeries = A[i] + A[j];
                        if (totalUptoPrev >= totalForThisSeries && totalUptoPrev >= totalUpto[i])
                        {
                            pathTo[i] = j;
                        }
                        //biggest between current series and including prev series
                        int maxSumForSeq = Math.Max(totalUptoPrev, totalForThisSeries);
                        //biggest between current prev max and this max
                        totalUpto[i] = Math.Max(totalUpto[i], maxSumForSeq);

                    }
                }
            }
            StringBuilder b = new StringBuilder();
            int max = totalUpto.Max();
            int x = Array.IndexOf(totalUpto, max);
            if (x < 1) return -1;
            b.Append($"Index {x} Value {A[x]}");
            do
            {
                x = pathTo[x];
                b.Append($"Index {x} Value {A[x]}");
            } while (x != pathTo[x]);

            Console.WriteLine($"Path: {b}");

            return max;
        }

        [Test]
        public void Success2()
        {
            int[] array = { 9, 4, 2, -1, 3, 9, 7, 3, 17, 6, 3, 1, 80, 7, 4, 2, 5, 2, 110 };
            Assert.AreEqual(221, new MaxIncreasingSubSeq().CalcMaxSubSeq(array));
        }

        [Test]
        public void Success()
        {
            int[] array = { 1,2,3,4,1 };
            Assert.AreEqual(10, new MaxIncreasingSubSeq().CalcMaxSubSeq(array));
        }
    }
}
