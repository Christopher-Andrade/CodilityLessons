using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons.CodilityTest1
{

    public class LongestCommonSubsequenceInStrings
    {
        private string  a = "spanking";
        private string b = "amputation";

        private List<string> list = new List<string>();
        private readonly Dictionary<string, string> memo = new Dictionary<string, string>();
        private int count = 0;
        public string LCSR(string a, string b)
        {
            return LCSR(a, b, 0 , 0);
        }

        private string LCSR(string a, string b, int aIndex, int bIndex)
        {
            string key = aIndex + ":" + bIndex;
            if (memo.ContainsKey(key)) return memo[key];
              Console.WriteLine($" Word A: {a} Word B {b} AIndex {aIndex} BIndex {bIndex}");
            list.Add($" Word A: {a} Word B {b} AIndex {aIndex} BIndex {bIndex}");
            count++;
            string maxString = string.Empty;

            //define base case
            if (aIndex == a.Length)
            {
                Console.WriteLine("Returning no match");
                memo.Add(key, "");
                return "";
            }
            else if (bIndex == b.Length)
            {
                    Console.WriteLine("Returning no match");
                memo.Add(key, "");
                return "";
            }
            else
            {
                //Skip over a[i]
                string option1 = LCSR(a, b, aIndex + 1, bIndex);
                //Skip over b[i]
                string option2 = LCSR(a, b, aIndex, bIndex + 1);
                //skip over both
                string option3 = LCSR(a, b, aIndex + 1, bIndex + 1);
                if (a[aIndex] == b[bIndex])
                {
                    option3 = a[aIndex] + option3;
                }
                //Find LONGEST common subsequence. Return max string length
                maxString = option1.Length > option2.Length ? option1 : option2;
                maxString = maxString.Length > option3.Length ? maxString : option3;
                Console.WriteLine($"Returning maxString {maxString}");

                
            }
            //  foreach (var s in list)
            //  {
            //     // Console.WriteLine(s);
            //  }
            memo.Add(key, maxString);

            return maxString;

        }

        public string LCSDP(string a, string b)
        {
            string maxString = string.Empty;
            string[,] dp = new string[a.Length + 1, b.Length + 1];
            int count = 0;
            int i = 0;
            int j = 0;
            for (i = a.Length; i >= 0; i--)
            {
                for (j = b.Length; j >= 0; j--)
                {
                    //define base case
                    if (i == a.Length)
                    {
                        dp[i, j] = "";
                    }
                    else if (j == b.Length)
                    {
                        dp[i, j] = "";
                    }
                    else
                    {
                        count++;
                        //Skip over a[i]
                        string option1 = dp[i, j + 1];
                        //Skip over b[i]
                        string option2 = dp[i + 1, j];
                        //skip over both
                        string option3 = dp[i + 1, j + 1];
                        if (a[i] == b[j])
                        {
                            option3 = a[i] + option3;
                        }
                        //Find LONGEST common subsequence. Return max string length
                        maxString = option1.Length > option2.Length ? option1 : option2;
                        maxString = maxString.Length > option3.Length ? maxString : option3;
                        dp[i, j] = maxString;
                    }
                }
                }
            // dp[i, j] = common;
            Console.WriteLine($"Count {count}");
                return dp[0,0];
            }

        public class MyCollection : ObservableCollection<string[,]>
        {
            public MyCollection(): base()
            {
                
            }
        }


        [Test]
        public void Success()
        {
            Assert.AreEqual("pain", new LongestCommonSubsequenceInStrings().LCSR(a, b));
        }

        [Test]
        public void Success2()
        {
            Assert.AreEqual("pain", new LongestCommonSubsequenceInStrings().LCSDP(a, b));
        }
    }
}
