using System;

namespace Non_decreasing_Array
{
    class Program
    {
        static void Main()
        {
            int[] nums1 = new int[] { 4, 2, 3 }; //true
            int[] nums2 = new int[] { 3, 4, 2, 3 }; //false
            int[] nums3 = new int[] { -1, 4, 2, 3 }; //true
            int[] nums4 = new int[] { 5, 7, 1, 8 }; //true
            int[] nums5 = new int[] { 5, 1, 1, 1, 1 };
            int[] nums6 = new int[] { 5, 1, 6, 6, 6 };
            Program program = new Program();
            bool possible = program.CheckPossibility(nums1);
            Console.WriteLine(possible);
        }



        public bool CheckPossibility(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
                return true;
            if(!HasExactlyOneDecreasingSegment(nums))
            {
                return false;
            }

            return true;
        }
        public bool HasExactlyOneDecreasingSegment(int[] nums)
        {
            bool AlreadyChangedAValue = false;

            if (nums[0] > nums[1])
            {
                nums[0] = nums[1];
                AlreadyChangedAValue = true;
            }
            if (nums[nums.Length - 1] < nums[nums.Length - 2])
            {
                if (AlreadyChangedAValue)
                    return false;

                nums[nums.Length - 1] = nums[nums.Length - 2];
                AlreadyChangedAValue = true;
            }
            for (int i = 1; i < nums.Length - 1; i++)
            {
                int previousNumber = nums[i - 1];
                int currentNumber = nums[i];
                int nextNumber = nums[i + 1];

                if(previousNumber > currentNumber || currentNumber > nextNumber)
                {
                    if (AlreadyChangedAValue)
                        return false;
                    if (nextNumber > currentNumber && !(AlreadyChangedAValue))
                    {
                        nums[i] = nextNumber;
                        AlreadyChangedAValue = true;
                    }
                    if (previousNumber > nextNumber && !(AlreadyChangedAValue))
                    {
                        if (nums[i - 1] > nums[i])
                            nums[i - 1] = currentNumber;
                        else
                            nums[i + 1] = currentNumber;
                        AlreadyChangedAValue = true;
                    }
                    if (currentNumber > nextNumber && !(AlreadyChangedAValue))
                    {
                        nums[i] = nextNumber;
                        AlreadyChangedAValue = true;
                    }
                    i--;
                }
            }
            return true;
        }
    }
}
