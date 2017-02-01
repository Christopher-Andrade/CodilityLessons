using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodilityLessons;
using NUnit.Framework;

namespace CodilityLessons10
{
    class  Socks
    {
        public int Color { get; set; }

        public int Count { get; set; }

        public int PairsFromSocks
        {
            get
            {
                if (this.Count < 2) return 0;
                if (this.Count % 2 == 0)
                {
                    return this.Count / 2;
                }
                else
                {
                    return (this.Count - 1) / 2;
                }

            }
        }
    }

    public class Solution
    {

        public int solution(int K, int[] C, int[] D)
        {
            List<Socks> cleanSocks = new List<Socks>();
            List<Socks> dirtySocks = new List<Socks>();

            int maxSockPairs = 0;

            cleanSocks = C.GroupBy(x => x).Select(x => new Socks {Color = x.Key, Count = x.Count()}).ToList();
            dirtySocks = D.GroupBy(x => x).Select(x => new Socks { Color = x.Key, Count = x.Count() }).ToList();

            //All pairs matched for colour and removed when matched
            for (int i = 0; i < cleanSocks.Count; i++)
            {
                if (cleanSocks[i].Count % 2 == 0)
                {
                    maxSockPairs += cleanSocks[i].PairsFromSocks;
                    cleanSocks[i].Count = 0;
                }
                else
                {
                    //odd number 
                    if (cleanSocks[i].Count > 1)
                    {
                        int temp = cleanSocks[i].PairsFromSocks;
                        maxSockPairs += temp;
                        cleanSocks[i].Count = 1;
                    }
                }
            }

            if (K == 0) return maxSockPairs;

            int spaceLeft = K;
            //Find max mates for clean socks
            foreach (var cleanSock in cleanSocks.Where(x => x.Count > 0))
            {
                if (spaceLeft == 0) break;
                foreach (var dirtySock in dirtySocks)
                {
                    if (spaceLeft == 0) break;
                    if (cleanSock.Color == dirtySock.Color && dirtySock.Count > 0)
                    {
                        spaceLeft--;
                        maxSockPairs += 1;
                        dirtySock.Count -= 1;
                    }
                }
            }

            //Dirty socks can be washed and paired
            if (spaceLeft > 2)
            {
                foreach (var dirtyS in dirtySocks.Where(x => x.Count > 1))
                { 
                    if (spaceLeft < 2) break;
                    //All pairs matched for colour
                        if (dirtyS.Count <= spaceLeft)
                        {
                            int pairs = dirtyS.PairsFromSocks;
                            spaceLeft -= pairs * 2;
                            maxSockPairs += pairs;
                            dirtyS.Count -= pairs * 2;
                        }
                        else
                        {
                        //Enough space for sets
                            if (spaceLeft % 2 == 0)
                            {
                                dirtyS.Count -= spaceLeft;
                                maxSockPairs += spaceLeft / 2;
                                spaceLeft = 0;
                            }
                            else
                            {
                                dirtyS.Count = 1;
                                maxSockPairs += spaceLeft / 2;
                                spaceLeft = 1;
                            }
                        }

                    }
            }
            return maxSockPairs;
        }

        [Test]
        public void Test()
        {
            int[] C = {1,2,1,1};
            int[] D = {1,4,3,2,4 };
            Assert.AreEqual(3, new Solution().solution(2,C,D));
        }

        [Test]
        public void Test2()
        {
            int[] C = { 1,1 };
            int[] D = { 2,2,2,2,2,2 };
            Assert.AreEqual(4, new Solution().solution(6, C, D));
        }

        [Test]
        public void Test3()
        {
            int[] C = { 2,2,2,2,2,2,2 };
            int[] D = {1, 1,2 };
            Assert.AreEqual(4, new Solution().solution(2, C, D));
        }

        [Test]
        public void Test4()
        {
            int[] C = { 1,1,1,1,1,1};
            int[] D = { 1,1,1,1,1,1 };
            Assert.AreEqual(5, new Solution().solution(4, C, D));
        }

        [Test]
        public void Test5()
        {
            int[] C = { 1,2,3,4,5,6 };
            int[] D = { 7,8,9,10 };
            Assert.AreEqual(0, new Solution().solution(2, C, D));
        }

        [Test]
        public void Test6()
        {
            int[] C = { 1, 2, 3, 4, 5, 6 };
            int[] D = {1,2,2,1,3,3 };
            Assert.AreEqual(3, new Solution().solution(6, C, D));
        }

        [Test]
        public void Test7()
        {
            int[] C = { 1, 2, 3, 4, 5, 6, 6 };
            int[] D = {7,8,9 };
            Assert.AreEqual(1, new Solution().solution(0, C, D));
        }

        [Test]
        public void Test8()
        {
            int[] C = { 1,1,2,2 };
            int[] D = { 2,2,1,1 };
            Assert.AreEqual(2, new Solution().solution(0, C, D));
        }
    }
}
