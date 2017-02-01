using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons6
{
    class Solution
    {
        const int OCCUPIED = 1;
        const int BARREL = 2;
        const int EMPTY = 0;
        const int DWARF = 3;
        public int solution(int N, string S, string T)
        {
            List<string> barrels = new List<string>();
            List<string> occupied = new List<string>();
         //   int maxdwarfs = -1;

           if (!string.IsNullOrEmpty(S))
            {
                barrels = S.Split(' ').ToList();
            }

            if (!string.IsNullOrEmpty(T))
            {
                occupied = T.Split(' ').ToList();
            }

            int[,] raft = new int[N, N];

            foreach (var b in barrels)
            {
                int[] barrelPosition = ExtractXandY(b);
                raft[barrelPosition[0], barrelPosition[1]] = BARREL;
            }

            foreach (var o in occupied)
            {
                int[] dwarfPosition = ExtractXandY(o);
                raft[dwarfPosition[0], dwarfPosition[1]] = OCCUPIED;
            }

            int midPoint = N/2;

            int osTL = OpenSeatsInQuadrants(0, midPoint, 0, midPoint, raft);
            int osTR = OpenSeatsInQuadrants(midPoint, N , 0, midPoint, raft);
            int osBL = OpenSeatsInQuadrants(0, midPoint , midPoint, N, raft);
            int osBR = OpenSeatsInQuadrants(midPoint, N, midPoint, N, raft);

            int dTL = DwarfCountInQuadrants(0, midPoint, 0, midPoint, raft);
            int dTR = DwarfCountInQuadrants(midPoint, N, 0, midPoint, raft);
            int dBL = DwarfCountInQuadrants(0, midPoint, midPoint, N, raft);
            int dBR = DwarfCountInQuadrants(midPoint, N, midPoint, N, raft);

            int answer = -1;

         //   int maxCapacity = N * N;
            int maxSeats = osTL + osTR + osBL + osBR;
            if (maxSeats != (N * N) - barrels.Count - occupied.Count) throw new ApplicationException("Wrong logic");


            //problem of two halves
            int maxDwarfInSegmentA = MaxDwarvesPerSegment(osTL, osBR, dTL, dBR);
            if (maxDwarfInSegmentA == -1) return -1;

            int maxDwarfInSegmentB = MaxDwarvesPerSegment(osBL, osTR, dBL, dTR);
            if (maxDwarfInSegmentB == -1) return -1;

            return maxDwarfInSegmentA + maxDwarfInSegmentB;
        }

        private int MaxDwarvesPerSegment(int maxSpacesL, int maxSpacesR, int dLeft, int dRight)
        {
            //Cant do any more
            if (maxSpacesR == 0 && maxSpacesL == 0 && dLeft == dRight) return 0;
            int minNoDwarves = Math.Min(dRight, dLeft);

            if (dLeft == minNoDwarves)
            {
                if (maxSpacesL < dRight - dLeft) return -1;
            }
            if (dRight == minNoDwarves)
            {
                if (maxSpacesR < dLeft - dRight) return -1;
            }

            int goal = Math.Min(maxSpacesL + dLeft, dRight + maxSpacesR);
            return (goal - dLeft) + (goal - dRight);

        }

        private int OpenSeatsInQuadrants(int leftPos, int rightPos, int topPos, int botPos, int[,] matrix)
        {
            int maxSeats = 0;

            for (int i = leftPos; i < rightPos; i++)
            {
                for (int j = topPos; j < botPos; j++)
                {
                    if (matrix[j,i ] == EMPTY) maxSeats++;
                }
            }
            return maxSeats;
        }

        private int DwarfCountInQuadrants(int leftPos, int rightPos, int topPos, int botPos, int[,] matrix)
        {
            int maxSeats = 0;

            for (int i = leftPos; i < rightPos; i++)
            {
                for (int j = topPos; j < botPos; j++)
                {
                    if (matrix[j, i] == OCCUPIED) maxSeats++;
                }
            }
            return maxSeats;
        }

        private int[] ExtractXandY(string b)
        {
            int row = Convert.ToInt32(string.Concat(b.Where<char>(char.IsNumber)));
            int seat = TextToNumber(b.Single<char>(char.IsLetter).ToString()) ;
            //Adjust for zero based index array
            return new int[] { row-1, seat-1};
        }

        static int TextToNumber(string text)
        {
            return text
                .Select(c => c - 'A' + 1)
                .Aggregate((sum, next) => sum * 26 + next);
        }
    }

    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod1()
        {
            string s = "1B 1C 4B 1D 2A";
            string t = "3B 2D";
            Assert.AreEqual(6, new Solution().solution(4, s, t));
        }

        [Test]
        public void TestMethod2()
        {
            string s = "";
            string t = "";
            Assert.AreEqual(16, new Solution().solution(4, s, t));
        }

        [Test]
        public void TestMethod3()
        {
            string s = "1A 1B 1C 1D 3A 3B 3C 3D";
            string t = "2A 2B 2C 2D 4A 4B 4C 4D";
            Assert.AreEqual(0, new Solution().solution(4, s, t));
        }


        [Test]
        public void TestMethod4()
        {
            string s = ""; //"1A 1B 1C 1D 3A 3B 3C 3D";
            string t = "2A 2B 2C 2D 4A 4B 4C 4D 1A 1B 1C 1D 3A 3B 3C 3D";
            Assert.AreEqual(0, new Solution().solution(4, s, t));
        }

        [Test]
        public void TestMethod5()
        {
            string s = "C1 C2 C3 C4 D1 D2 D3 D4";
            string t = "";
            Assert.AreEqual(0, new Solution().solution(4, s, t));
        }

        [Test]
        public void TestMethod7()
        {
            string s = "1A 1B 1C 1D 3A 3B 3C 3D";
            string t = "2A 2B 2C 2D 4A 4B 4C 4D";
            Assert.AreEqual(0, new Solution().solution(4, s, t));
        }
        [Test]
        public void TestMethod8()
        {
            string s = "";
            string t = "";
            Assert.AreEqual(4, new Solution().solution(2, s, t));
        }

        [Test]
        public void TestMethod9()
        {
            string s = "";
            string t = "A1";
            Assert.AreEqual(3, new Solution().solution(2, s, t));
        }
    }
}
