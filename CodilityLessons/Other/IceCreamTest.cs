using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodilityLessons5
{
    struct IceCream : IComparable
    {
        public int OriginalIndex { get; set; }
    //    public string Flavor { get; set; }
        public int Price { get; set; }

        public int CompareTo(object obj)
        {
            return this.Price.CompareTo(((IceCream) obj).Price);
        }
        
    }

    public class IceCreamTest
    {
        
        public int[] ReturnIndexes(int total, int[] array)
        {
            IceCream[] iceCreamArray = new IceCream[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                iceCreamArray[i] = new IceCream() {Price = array[i], OriginalIndex = i};
            }

            iceCreamArray = iceCreamArray.OrderBy(x => x.Price).ToArray();
            List<int> answerList = new List<int>();
            for (int i = 0; i < iceCreamArray.Length; i++)
            {
                IceCream iceC = iceCreamArray[i];
                if (iceC.Price < total)
                {
                    int compliment = total - iceC.Price;
                    int startingIndex = i == iceCreamArray.Length - 1 ? i : i + 1;
                    int indexFound = Array.BinarySearch<IceCream>(iceCreamArray, startingIndex, iceCreamArray.Length- i -1,
                        new IceCream() {Price = compliment});
                    if (indexFound > -1 && indexFound < iceCreamArray.Length && iceCreamArray[i].Price == compliment)
                    {
                        //Get original index and return
                        answerList.Add(iceCreamArray[i].OriginalIndex);
                        answerList.Add(iceCreamArray[indexFound].OriginalIndex);
                    } 
                }
            }
          
            answerList.Sort();
            return answerList.ToArray();
        }
    }


    [TestFixture]
    public class CaterpillarTriangle
    {
        [Test]
        public void TestMethod()
        {
            int[] arrayb = { 2,7,13,5,4,13,5 };
                int[] arrayc = { 3, 6 };
                Assert.AreEqual(arrayc, new IceCreamTest().ReturnIndexes(10, arrayb));
        }
    }
}
