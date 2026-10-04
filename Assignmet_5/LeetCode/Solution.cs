using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralToOOP.LeetCode
{
    public class Solution
    {
        public int MaxOperations(int[] nums, int k)
        {
            int count = 0;
            int left = 0;
            int right = nums.Length - 1;
            Array.Sort(nums);
            while (left < right)
            {
                if (nums[left] + nums[right] == k)
                {
                    count++;
                    return count;
                }
                else if (nums[left] + nums[right] > k)
                {
                    right--;
                    count++;
                }
                else
                {
                    left++;
                    count++;
                }
            }
            return count;
        }
    }
}
