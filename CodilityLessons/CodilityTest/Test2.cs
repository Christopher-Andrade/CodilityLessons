using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest
{
    public class Test2
    {
        public int[] solution(int[] A)
        {
            int num = 0;

            if (A.Length == 0) return new int[] {0};

           
                num = ConvertBinaryToInt(A);
                //If num positive
                if (num < 0)
                {
                    num = Math.Abs(num);
                }
                //if num negative
                else
                {
                    num = num * -1;
                }
            

            return ConvertIntToBinaryNeg2(num);
        }

        public int[] ConvertIntToBinaryNeg2(int x)
        {
            string result = string.Empty;
            int numRes = x;
            while (numRes != 0)
            {
                var remainder = numRes % -2;

                numRes = numRes / -2;

                if (remainder < 0)
                {
                    remainder += 2;
                    numRes += 1;
                }
                result = remainder.ToString() + result;
            }
            int[] myInts = Array.ConvertAll(result.ToArray(), s => int.Parse(s.ToString()));
        
            return myInts;
        }

        public int ConvertBinaryToInt(int[] binary)
        {
            int ans = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                ans += binary[i] * ((int)Math.Pow(-2, i));
            }
            return ans;
        }

        //[Test]
        //public void TestMethod()
        //{
        //  int[] arrayb = { 1,0,0,1,1 };
        //    Assert.AreEqual(9, new Test2().ConvertBinaryToInt(arrayb));
        //    int[] arrayc = { 1,0,0,1,1,1 };
        //    Assert.AreEqual(-23, new Test2().ConvertBinaryToInt(arrayc));

        //}


        [Test]
        public void TestMethod2()
        {
            int[] arrayb = { 1,0,0,1,1 };
            int[] arrayc = { 1,1,0,1 };

            Assert.AreEqual(arrayc, new Test2().solution(arrayb));
        }

        [Test]
        public void TestMethod4()
        {
            int[] arrayb = {  };
            int[] arrayc = { 0};

            Assert.AreEqual(arrayc, new Test2().solution(arrayb));
        }


        [Test]
        public void TestMethod3()
        {
            int[] arrayb = { 1, 0, 0, 1, 1, 1 };
            int[] arrayc = {1,1,0,1,0,1,1 };

            Assert.AreEqual(arrayc, new Test2().solution(arrayb));
        }
    }
}