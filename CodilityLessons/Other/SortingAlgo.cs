using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityLessons
{
    class SortingAlgo
    {
        public List<int> quicksort(List<int> a)
        {
            Random r = new Random();
            List<int> less = new List<int>();
            List<int> greater = new List<int>();
            if (a.Count <= 1)
                return a;
            int pos = r.Next(a.Count);

            int pivot = a[pos];
            a.RemoveAt(pos);
            foreach (int x in a)
            {
                if (x <= pivot)
                {
                    less.Add(x);
                }
                else
                {
                    greater.Add(x);
                }
            }
            return concat(quicksort(less), pivot, quicksort(greater));
        }


        public List<int> concat(List<int> less, int pivot, List<int> greater)
        {
            List<int> sorted = new List<int>(less);
            sorted.Add(pivot);
            foreach (int i in greater)
            {

                sorted.Add(i);
            }

            return sorted;
        }




        public List<int> mergesort(List<int> m)
        {
            List<int> result = new List<int>();
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            if (m.Count <= 1)
                return m;

            int middle = m.Count / 2;
            for (int i = 0; i < middle; i++)
                left.Add(m[i]);
            for (int i = middle; i < m.Count; i++)
                right.Add(m[i]);
            left = mergesort(left);
            right = mergesort(right);
            if (left[left.Count - 1] <= right[0])
                return append(left, right);
            result = merge(left, right);
            return result;
        }

        public List<int> append(List<int> a, List<int> b)
        {
            List<int> result = new List<int>(a);
            foreach (int x in b)
                result.Add(x);
            return result;
        }

        public List<int> merge(List<int> a, List<int> b)
        {
            List<int> s = new List<int>();
            while (a.Count > 0 && b.Count > 0)
            {

                if (a[0] < b[0])

                {
                    s.Add(a[0]);
                    a.RemoveAt(0);
                }
                else
                {
                    s.Add(b[0]);
                    b.RemoveAt(0);
                }
                while (a.Count > 0)

                {
                    s.Add(a[0]);

                    a.RemoveAt(0);
                }
            }

            return s;
        }

        int[] heapSort(int[] numbers, int array_size)
        {
            int i, temp;
            for (i = (array_size / 2) - 1; i >= 0; i--)
                siftDown(numbers, i, array_size);
            for (i = array_size - 1; i >= 1; i--)
            {
                temp = numbers[0];
                numbers[0] = numbers[i];
                numbers[i] = temp;
                siftDown(numbers, 0, i - 1);
            }
            return numbers;
        }

        void siftDown(int[] numbers, int root, int bottom)
        {
            int done, maxChild, temp;
            done = 0;
            while ((root * 2 <= bottom) && (done == 0))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (numbers[root * 2] > numbers[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;
                if (numbers[root] < numbers[maxChild])
                {
                    temp = numbers[root];
                    numbers[root] = numbers[maxChild];
                    numbers[maxChild] = temp;
                    root = maxChild;
                }
                else
                    done = 1;
            }
        }

        public List<int> bubblesort(List<int> a)
        {
            int temp;
            // foreach(int i in a)
            for (int i = 1; i <= a.Count; i++)
                for (int j = 0; j < a.Count - i; j++)
                    if (a[j] > a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
            return a;
        }
    }
}
