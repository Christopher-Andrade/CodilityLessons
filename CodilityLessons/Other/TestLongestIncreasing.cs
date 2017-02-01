using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons
{
    public class TestLongestIncreasing
    {
        static Dictionary<int, int> memo = new Dictionary<int, int>();
        public int FibNth(int n)
        {
            Console.WriteLine($"Called with: {n}");
            int[] f = new int[n + 1];
            f[0] = 0;
            f[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n];
           // int res = FibNth(n - 1) + FibNth(n - 2);
          //  memo.Add(n, res);
           // Console.WriteLine($"Returning: {res}");
         //   return res;

        }


        public int CountLongestIncreasingDP(int[] array)
        {
            int[] dp = new int[array.Length + 1];
          //  int max = 0;

            //init values
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            for (int i = 1; i < array.Length; i++)
            {
                int max = array[i] < array[i - 1] ? 1 : 0;
                dp[i] = dp[i] + max;
            }

            return array[array.Length];
        }
        

        public int CountLongestIncreasingSubSeq(int[] array)
        {
            return CountLongestIncreasingR(array, array.Length);
        }

        private int CountLongestIncreasingR(int[] array, int startIndex)
        {
            //Console.WriteLine($"Array: {string.Join(",", array)} StartIndex {startIndex}");
            int max = 1;
            int res = 0, maxendingHere = 1;

            for (int i = 1; i < startIndex; i++)
            {
                res = CountLongestIncreasingR(array, i);
                if (array[i-1] < array[startIndex - 1] && res + 1 > maxendingHere)
                {
                    maxendingHere = res + 1;
                }
            }
            if (max < maxendingHere) max = maxendingHere;
           // Console.WriteLine($"Returning {maxendingHere}");
            return maxendingHere;
        }

        [Test]
        public void Fib()
        {
          //  int[] arr = { 10, 22, 11 };
            Assert.AreEqual(8, new TestLongestIncreasing().FibNth(10));
        }


        [Test]
        public void Success()
        {
            int[] arr = {10, 22, 11};
            Assert.AreEqual(2, new TestLongestIncreasing().CountLongestIncreasingDP(arr));
        }
    }
}