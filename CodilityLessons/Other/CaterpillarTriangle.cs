using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityLessons
{
    public class Solution
    {
        int funcCount = 0;
        public int solution(int[] A)
        {

            A = A.OrderBy(x => x).ToArray();
            int n = A.Length;
            if (n < 2) return 0;
            // Initialize count of triangles
            int count = 0;

            // Fix the first element.  We need to run till n-3 as
            // the other two elements are selected from arr[i+1...n-1]
            for (int p = 0; p < n - 2; p++)
            {
             
                // Initialize index of the rightmost third element
                int r = p + 2;

                // Fix the second element
                for (int q = p + 1; q < n; q++)
                {
                    /* Find the rightmost element which is smaller
                       than the sum of two fixed elements
                       The important thing to note here is, we use
                       the previous value of k. If value of arr[i] +
                       arr[j-1] was greater than arr[k], then arr[i] +
                       arr[j] must be greater than k, because the
                       array is sorted. */
                    while (r < n && A[p] + A[q] > A[r])
                        r++;

                    /* Total number of possible triangles that can be
                       formed with the two fixed elements is k - j - 1.
                       The two fixed elements are arr[i] and arr[j].  All
                       elements between arr[j+1] to arr[k-1] can form a
                       triangle with arr[i] and arr[j]. One is subtracted
                       from k because k is incremented one extra in above
                       while loop. k will always be greater than j. If j
                       becomes equal to k, then above loop will increment
                       k, because arr[k] + arr[i] is always/ greater than
                       arr[k] */
                    count += r - q - 1;
                }
            }
            return count;
            //in sorted array, we know 0 <= P < Q < R < N
            //in sorted array Q+R > P   and P+R > Q
            //All we need to prove is P+Q > R and biggest chance to do this is adjacent numbers as they provide largest P and Q out of series





            //int n = A.Length;
            //if (n < 2) return 0;

            //if (n == 3) return IsTriangle(A[0], A[1], A[2]) ? 1 : 0;
            //int counter = 0;
            //int begin = 0, mid = 1, end = 2;

            //for (begin = 0; begin < n - 2; begin++)
            //{
            //    //Place middle = to begin
            //    mid = begin + 1;
            //    end = mid + 1;
            //    while ((end < n - 1) || (mid < n - 2 && mid < end && mid + 1 < end))
            //    {
            //        //Check end can move
            //        if (end < n - 1)
            //        {
            //            if (IsTriangle(A[begin], A[mid], A[end])) counter++;
            //            end++;
            //        }
            //        else if (mid < n - 2 && mid < end && mid + 1 < end)
            //        {
            //            if (IsTriangle(A[begin], A[mid], A[end])) counter++;
            //            mid++;
            //            end = mid + 1;
            //        }
            //    }
            //    if (IsTriangle(A[begin], A[mid], A[end])) counter++;
            //}
            //Console.WriteLine(funcCount);
            //return counter;


        }

        private bool IsTriangle(long p, long q, long r)
        {
            funcCount++;
            Console.WriteLine($" Conditional check {p} {q}  {r}");
            bool result =  p + q > r && q + r > p && r + p > q;
            if (result) Console.WriteLine(" Triangle found");
            return result;
        }
    }


    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod()
        {
            int[] array = {10, 2, 5, 1, 8, 12};
            Assert.AreEqual(4, new Solution().solution(array));

        }

        [Test]
        public void TestMethod2()
        {
            int[] array = { 1000000000, 1000000000, 1000000000 };
            Assert.AreEqual(1, new Solution().solution(array));
        }

        [Test]
        public void TestMethod4()
        {
            int[] array = { 1000000000, 1000000000, 1000000000, 1 };
            Assert.AreEqual(4, new Solution().solution(array));
        }

        [Test]
        public void TestMethod3()
        {
            int[] array = { 1,2,3 };
            Assert.AreEqual(0, new Solution().solution(array));
        }
    }
}
