/*
 * Problem   : 540. Single Element in a Sorted Array
 * Link      : https://leetcode.com/problems/single-element-in-a-sorted-array/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search, Bit Manipulation
 * Date      : 2026-07-30
 *
 * Approaches:
 *
 * 1. HashMap
 *    - Store the frequency of each element.
 *    - Return the element with frequency 1.
 *    - Time  : O(n)
 *    - Space : O(n)
 *
 * 2. XOR
 *    - Every paired element cancels out.
 *    - The remaining value is the single element.
 *    - Time  : O(n)
 *    - Space : O(1)
 *
 * 3. Linear Search
 *    - Check adjacent elements to find the unpaired element.
 *    - Time  : O(n)
 *    - Space : O(1)
 *
 * 4. Binary Search
 *    - Before the single element, pairs start at even indices.
 *    - After the single element, this pattern is shifted.
 *    - Use this pattern to eliminate half of the search space.
 *    - Time  : O(log n)
 *    - Space : O(1)
 *
 * Notes:
 * - Array is sorted.
 * - Every element appears exactly twice except one element.
 * - The array contains an odd number of elements.
 * - For the optimal solution, binary search is used.
 */


public class Single_Sorted_arr
{
    public static int Approach_One(int[] nums) //using Dictionary
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach(var n in nums)
        {
            if(map.ContainsKey(n))
                map[n]++;
            else
                map[n] = 1;
        }

        foreach(var pair in map)
        {
            if(pair.Value == 1)
            {
                return pair.Key;
            }
        }
        return -1;
    }

    public static int Approach_Two(int[] nums) //using Xor
    {
        int result = 0;

        foreach(var n in nums)
        {
            result ^= n;
        }

        return result; 
    }

    public static int Approach_Three(int[] nums) //using Linear Search
    {
        int i = 0;
        while( i < nums.Length - 1)
        {
            if(nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }

        return nums[nums.Length - 1];
    }

    
    
}
