using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest
{
    public class Test1
    {
        public int solution(string S)
        {
            int countOpen = 0;
            int countClosed = 0;

            int[] openBCount = new int[S.Length];
            int[] closeBCount = new int[S.Length];

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    countOpen++;
                    openBCount[i] = countOpen;
                }
                else
                {
                    openBCount[i] = countOpen;
                }
            }

            for (int i = S.Length-1; i >= 0; i--)
            {
                if (S[i] == ')')
                {
                    countClosed++;
                    closeBCount[i] = countClosed;
                }
                else
                {
                    closeBCount[i] = countClosed;
                }
            }
            int indexOfBalance = 0;
            int maxCount = 0;
            for (int i = 0; i < openBCount.Length; i++)
            {
                int leftCount = openBCount[i];
                int rightCount = closeBCount[(closeBCount.Count()-1) - i];
                if (leftCount == rightCount)
                {
                    if (maxCount < leftCount)
                    {
                        maxCount = leftCount;
                        //take right index
                        indexOfBalance = (closeBCount.Count() - 1) -i;
                    }
                }
            }

            return indexOfBalance;
        }

        [Test]
        public void TestMethod()
        {
            string arrayb = "(())";
            Assert.AreEqual(2, new Test1().solution(arrayb));
        }

        [Test]
        public void TestMethod2()
        {
            string arrayb = "(())))(";
            
            Assert.AreEqual(4, new Test1().solution(arrayb));
        }

        [Test]
        public void TestMethod3()
        {
            string arrayb = "))";
            Assert.AreEqual(2, new Test1().solution(arrayb));
        }
    }
}

