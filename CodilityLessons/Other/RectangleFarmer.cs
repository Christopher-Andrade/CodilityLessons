using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons9
{
    public class Solution
    {
        public int solution(int[] A, int X)
        {
            int n = A.Length;
            if (A.Length < 4) return 0;
            Dictionary<int, int> fenceCount = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                if (fenceCount.ContainsKey(A[i]))
                {
                    fenceCount[A[i]]++;
                }
                else
                {
                    fenceCount.Add(A[i], 1);
                }
            
            }
            int maxPens = 0;

            List<int> usableFences = new List<int>();

            foreach (var fence in fenceCount)
            {
                //Discard
                if (fence.Value < 2)
                {
                    break;
                }
                else if (fence.Value < 4)
                {
                    usableFences.Add(fence.Key);
                }
                //square
                else if (fence.Value >= 4)
                {
                    usableFences.Add(fence.Key);
                    if (fence.Key * fence.Key >= X)
                    {
                        maxPens++;
                    }
                }
            }

            usableFences.Sort();
            int noOfFences = usableFences.Count;
            bool foundProduct = false;
            for (int i = 0; i < noOfFences; i++)
            {
                int begin = i +1;
                int end = noOfFences - 1;
                foundProduct = false;  
                while (begin <= end)
                {
                    int mid = (begin + end) / 2;
                    if (usableFences[mid] * usableFences[i] >= X)
                    {
                        end = mid - 1;
                      //  foundProduct = true;
                    }
                    else
                    {
                        begin = mid + 1;
                    }
                }

                int temp = noOfFences - (end + 1);
            //    if (foundProduct) temp= noOfFences - (end + 1);
                maxPens += temp;
            }


            return maxPens > 1000000000 ? -1 : maxPens;
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void Test1()
        {
            int[] array = new int[] {1,2,5,1,1,2,3,5,1};
            Assert.AreEqual(2, new Solution().solution(array, 5));
        }

        [Test]
        public void Test2()
        {
            int[] array = new int[] { 1, 2, 5 };
            Assert.AreEqual(0, new Solution().solution(array, 6));
        }



        [Test]
        public void Test3()
        {
            int[] array = new int[] { };
            Assert.AreEqual(0, new Solution().solution(array, 7));
        }


        [Test]
        public void Test4()
        {
            int[] array = new int[] { 1 };
            Assert.AreEqual(0, new Solution().solution(array, 1));
        }

        [Test]
        public void Test5()
        {
            int[] array = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Assert.AreEqual(1, new Solution().solution(array, 5));
        }


        [Test]
        public void Test6()
        {
            int[] array = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Assert.AreEqual(1, new Solution().solution(array, 25));
        }


    }
}
