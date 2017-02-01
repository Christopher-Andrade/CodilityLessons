using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest1
{
    public class Negabinary
    {
        public int[] ConvertIntToBinary(int x)
        {
            string binary = Convert.ToString(x, 2).PadLeft(8,'0');
            return binary.Select(c => Convert.ToInt32(c.ToString())).ToArray();
        }

        public int ConvertBinaryToInt(int[] binary)
        {
                int ans = 0;
            int i = 0;
            for (int j = binary.Length-1; j >= 0; j--)
            {
                ans += binary[j] * ((int)Math.Pow(2, i));
                i++;
            }
            return ans; 
        }


        //if a/b =c remainder d THEN bc + d = a

        //146 to negative base 3
        //146 / -3 = -48 rem  2
        //48 / -3 = 16 rem 0
        //16 / -3 = -5 rem 1
        //-5 / -3 = -2 rem 1
        //2 / -3 = 0 remainder 2
       
        public string ConvertIntToNegaBinaryMethod1(int x)
        {
            string result = string.Empty;
            int rem = 0;
            while (x != 0)
            {
                rem = x % -2;
             
                x = x / -2;

                if (rem < 0)
                {
                    rem += 2;
                    x += 1;
                }
                result = rem.ToString() + result;
            }
            return result;
        }



        [Test]
        public void Success()
        {
            int[] array = {0, 0, 1, 1, 0, 1, 1, 0};
            Assert.AreEqual(array, new Negabinary().ConvertIntToBinary(54));
        }

        [Test]
        public void Success2()
        {
            int[] array = { 0, 0, 1, 1, 0, 1, 1, 0 };
            Assert.AreEqual(54, new Negabinary().ConvertBinaryToInt(array));
        }

        [Test]
        public void Success3()
        {
            int[] array = { 1,0,0,1,0,1,0 };
            Assert.AreEqual(array, new Negabinary().ConvertIntToNegaBinaryMethod1(54));
        }

        [Test]
        public void Success4()
        {
            int[] array = { 1, 0, 0, 1, 0, 1, 0 };
        //    Assert.AreEqual(array, new Negabinary().ConvertIntToNegaBinaryMethod2(54));
        }
    }


}
