namespace UnknownAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        #region Search Algorithms

        /*
             Time Complexity: O(sqrt(n))
             Space Complexity: O(1)
         */
        public static int JumpSearch(int[] arr, int x)
        {
            int length = arr.Length;
            int jump = (int)Math.Sqrt(length);
            int prev = 0;

            for (int i = 0; i < length; i += jump)
            {
                if (arr[i] == x)
                {
                    return i;
                }

                if (arr[i] > x)
                {
                    break;
                }

                prev = i;
            }

            while (prev < (length - 1) && arr[prev] < x)
            {
                prev++;
            }

            if (arr[prev] == x)
                return prev;

            return -1;
        }

        static int InterpolationSearch(int[] arr, int n, int x)
        {
            int low = 0;
            int high = n - 1;

            while (low <= high && x >= arr[low] && x <= arr[high])
            {
                if (low == high)
                {
                    if (arr[low] == x)
                        return low;
                    return -1;
                }

                int pos = low + (int)(((float)(high - low) / (arr[high] - arr[low])) * (x - arr[low]));

                if (arr[pos] == x)
                    return pos;

                if (arr[pos] < x)
                    low = pos + 1;
                else
                    high = pos - 1;
            }

            return -1;
        }

        static int ExponentialSearch(List<int> arr, int x)
        {
            int n = arr.Count;

            if (n == 0)
                return -1;

            // Find range for binary search by repeatedly doubling i
            int i = 1;
            while (i < n && arr[i] < x)
                i *= 2;

            // Perform binary search on the range [i/2, min(i, n-1)]
            int left = i / 2;
            int right = Math.Min(i, n - 1);

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == x) return mid;
                else if (arr[mid] < x) left = mid + 1;
                else right = mid - 1;
            }

            return -1;
        }

        public static int FibonacciSearch(int[] arr, int x)
        {
            int n = arr.Length;
            if (n == 0)
            {
                return -1;
            }

            // Initialize Fibonacci numbers 
            int fib1 = 0, fib2 = 1, fib3 = fib1 + fib2;

            // Find the smallest Fibonacci number greater than or equal to n 
            while (fib3 < n)
            {
                fib1 = fib2;
                fib2 = fib3;
                fib3 = fib1 + fib2;
            }

            // Initialize variables for the current and previous split points 
            int offset = -1;
            while (fib3 > 1)
            {
                int i = Math.Min(offset + fib2, n - 1);

                // If x is greater than the value at index i, move the split point to the right 
                if (arr[i] < x)
                {
                    fib3 = fib2;
                    fib2 = fib1;
                    fib1 = fib3 - fib2;
                    offset = i;
                }

                // If x is less than the value at index i, move the split point to the left 
                else if (arr[i] > x)
                {
                    fib3 = fib1;
                    fib2 = fib2 - fib1;
                    fib1 = fib3 - fib2;
                }

                // If x is equal to the value at index i, return the index 
                else
                {
                    return i;
                }
            }

            // If x is not found in the array, return -1 
            if (fib2 == 1 && arr[offset + 1] == x)
            {
                return offset + 1;
            }
            else
            {
                return -1;
            }
        }

        #endregion
    }
}
