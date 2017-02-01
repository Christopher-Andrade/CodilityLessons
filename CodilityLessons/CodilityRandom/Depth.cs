using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest12
{
    public class Solution
    {
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)    
            int p = -1, r = -1, q = -1, maxD = -1;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (q < 0)
                {
                    if (A[i] > A[i + 1])
                    {
                        q = i + 1;
                        p = i;
                    }
                }
                else
                {
                    if (r < 0)
                    {
                        if (A[i] > A[i + 1])
                        {
                            q++;
                        }

                        if (A[i] < A[i + 1])
                        {
                            r = i + 1;
                        }

                        if (A[i] == A[i + 1])
                        {
                            p = q = r = -1;
                        }
                    }
                    else
                    {
                        if (A[i] < A[i + 1])
                        {
                            r++;
                        }
                        else
                        {
                            maxD = Math.Max(maxD, Math.Min(A[p] - A[q], A[r] - A[q]));

                            if (A[i] > A[i + 1])
                            {
                                p = i;
                                q = i + 1;
                                r = -1;
                            }
                            else
                            {
                                p = q = r = -1;
                            }
                        }
                    }
                }
            }

            if (r > 0)
            {
                maxD = Math.Max(maxD, Math.Min(A[p] - A[q], A[r] - A[q]));
            }

            return maxD;
        }



        [Test]
        public void Test()
        {
            int[] C = {0, 1, 3, -2, 0, 1, 0, -3, 2, 3};
            Assert.AreEqual(4, new Solution().solution(C));
        }
    }
}
