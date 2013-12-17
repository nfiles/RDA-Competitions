using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautifulArrays
{
    class Program
    {
        class Subset
        {
            public int Start { get; set; }
            public int Length { get; set; }

            public Subset(int start, int length)
            {
                this.Start = start;
                this.Length = length;
            }

            public static int Sum(int[] array, Subset subset)
            {
                int sum = 0;
                int end = subset.Start + subset.Length - 1;
                for (int i = subset.Start; i <= end; ++i)
                    sum += array[i];
                return sum;
            }
            public static bool Compare(int[] array, Subset a, Subset b)
            {
                // valid entries
                if (a == null || b == null)
                    return false;

                // same object
                if (ReferenceEquals(a, b))
                    return true;

                // equal lengths
                if (a.Length != b.Length)
                    return false;

                // positive lengths
                if (a.Length < 0)
                    return false;

                // subsets both fit in original array
                if (array.Length < a.Start + a.Length || array.Length < b.Start + b.Length)
                    return false;

                // elements match
                for (int i = 0; i < a.Length; ++i)
                    if (array[a.Start + i] != array[b.Start + i])
                        return false;

                // all good
                return true;
            }
        }

        static void FindBeautifulArrays(int[] nums, out int max, out int count, out List<Subset> solutions)
        {
            // all compared subsets, keyed by their maximum value
            Dictionary<int, List<Subset>> subsets = new Dictionary<int, List<Subset>>();

            // first 'max' value
            Subset subset = new Subset(0, nums.Length);
            max = Subset.Sum(nums, subset);
            count = 0;
            subsets[max] = new List<Subset>();
            subsets[max].Add(subset);

            // all possible set lengths
            for (int length = nums.Length - 1; length > 0; --length)
            {
                // start index of each subset
                int start = 0;
                // last possible start index
                int last = nums.Length - length;
                // sum of subset
                int sum;
                for (start = 0; start <= last; ++start)
                {
                    subset = new Subset(start, length);
                    sum = Subset.Sum(nums, subset);
                    if (sum >= max)
                    {
                        // haven't encountered this sum yet. Create new list.
                        if (sum > max)
                        {
                            max = sum;
                            subsets[max] = new List<Subset>();
                        }

                        // compare for duplicate subsets
                        if (!subsets[max].Any(each => Subset.Compare(nums, each, subset)))
                            subsets[max].Add(subset);
                    }
                }
            }

            // set 'out' parameters
            count = subsets[max].Count;
            solutions = subsets[max];
        }

        static void Main(string[] args)
        {
            String line;
            int length;
            int[] nums;

            // array length
            line = Console.ReadLine();
            length = Convert.ToInt32(line);
            nums = new int[length];

            // numbers in array
            for (int i = 0; i < length; ++i)
            {
                line = Console.ReadLine();
                nums[i] = Convert.ToInt32(line);
            }
            
            int max;
            int count;
            List<Subset> solutions;
            FindBeautifulArrays(nums, out max, out count, out solutions);

            Console.WriteLine(max);
            Console.WriteLine(count);
        }
    }
}
