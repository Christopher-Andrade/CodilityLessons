using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodilityLessons5;
using NUnit.Framework;

namespace CodilityLessons5
{
    public class Solution
    {
        //return length of longest pass, else -1
        public int solution(string S)
        {
            string[] stringArray = S.Split(' ');
            int count = -1;
            foreach (var str in stringArray)
            {
                if (IsValidPass(str))
                {
                    count = Math.Max(count, str.Length);
                }
            }
            return count;
        }

        private bool IsValidPass(string s)
        {
            //Only azAZ09
            //regex
            if (!Regex.IsMatch(s, @"^[a-zA-Z0-9]+$")) return false;
        

            //odd numbers
            List<char> numbers = s.Where<char>(Char.IsNumber).ToList();
            if (numbers.Count % 2 == 0) return false;

            //even letters
            List<char> letters = s.Where<char>(Char.IsLetter).ToList();
            if (letters.Count > 0 && letters.Count % 2 != 0) return false;

            return true;
        }
    }
}

[TestFixture]
public class CaterpillarTriangle
{
    [Test]
    public void TestMethod()
    {
        string s = "test 5 a0A pass007 ?xy1";
        Assert.AreEqual(7, new Solution().solution(s));
    }
}


