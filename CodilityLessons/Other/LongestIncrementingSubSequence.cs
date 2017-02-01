using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityLessons
{
    class LongestIncrementingSubSequence
    {
        int mymax = 1;

        public int _lis(int[] arr, int n)
        {
            int res, max_ending_here = 1; // length of LIS ending with arr[n-1]

            /* Recursively get all LIS ending with arr[0], arr[1] ... ar[n-2]. If 
               arr[i-1] is smaller than arr[n-1], and max ending with arr[n-1] needs
               to be updated, then update it */
            for (int i = 1; i < n; i++)
            {
                res = _lis(arr, i);
                if (arr[i - 1] < arr[n - 1] && res + 1 > max_ending_here)
                    max_ending_here = res + 1;
            }

            // Compare max_ending_here with the overall max. And update the
            // overall max if needed
            if (mymax < max_ending_here)
                mymax = max_ending_here;

            // Return length of LIS ending with arr[n-1]
            return max_ending_here;
        }

        // The wrapper function for _lis()
        public int lis(int[] arr)
        {
            // The function _lis() stores its result in max
          //  _lis(arr, arr.length);

            // returns max
            return mymax;
        }

    }
}
