using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulArrays
{
    class Program
    {
        static void FindBeautifulArrays(int[] nums, out int max, out int count)
        {
            Dictionary<int, int[]> solutions = new Dictionary<int, int[]>();

            max = Sum(nums, 0, nums.Length);
            count = 0;
            for (int length = nums.Length - 1; length > 0; --length)
            {
                int start = 0;
                int sum = Sum(nums, start, start + length);
                for (start = 1; start <= nums.Length - length; ++start)
                {

                }
            }
        }

        static int Sum(int[] array, int start, int end)
        {
            int sum = 0;
            for (int i = start; i <= end; ++i)
                sum += array[i];
            return sum;
        }

        static void Main(string[] args)
        {
            String line;
            int length;
            int[] nums;

            line = Console.ReadLine();
            length = Convert.ToInt32(line);
            nums = new int[length];

            for (int i = 0; i < length; ++i)
            {
                line = Console.ReadLine();
                nums[i] = Convert.ToInt32(line);
            }

            int max;
            int solutions;
            FindBeautifulArrays(nums, out max, out solutions);

            Console.WriteLine(max);
            Console.WriteLine(solutions);
        }
    }
}
