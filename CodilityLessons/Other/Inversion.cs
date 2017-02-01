using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons8
{
    struct NumStash : IComparable
    {
        public int Value { get; set; }

        public int Index { get; set; }
        public int CompareTo(object obj)
        {
            return this.Value.CompareTo(((NumStash) obj).Value);
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            int n = A.Length;

            return (int)invCount(A);

        }

        public long invCount(int[] arr)
        {
            if (arr.Length < 2) return 0;

            int m = arr.Length / 2;
            int[] left = new int[m];
            int[] right = new int[m];
            Array.Copy(arr, 0, left, 0, m);
            Array.Copy(arr, m, right, 0, m);

            return invCount(left) + invCount(right) + MergeSort(arr, left, right);
        }


        public int MergeSort(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, count = 0;

            while (i < left.Length || j < right.Length)
            {
                if (i == left.Length)
                {
                    array[i + j] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    array[i + j] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    array[i + j] = left[i];
                    i++;
                }
                else
                {
                    array[i + j] = right[j];
                    count += left.Length - 1;
                    j++;
                }

            }

            return count;
        }
    }

    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod1()
        {
            int[] aray = new int[] { -1, 6, 3, 4, 7, 4 };
            Assert.AreEqual(4, new Solution().solution(aray));
        }
    }
}
