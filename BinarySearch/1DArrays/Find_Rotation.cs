/*
 * Problem   : 540. Single Element in a Sorted Array
 * Link      : https://leetcode.com/problems/single-element-in-a-sorted-array/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search, Bit Manipulation
 * Date      : 2026-08-10
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


public class Find_Rotation
{
    public static int Approach_One(int[] nums)
    {
        int min = nums[0];
        int minIndex = 0;

        for(int i = 0; i < nums.Length-1; i++)
        {
            if (nums[i] < min)
            {
                min = nums[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static int Approach_Two(int[] nums) 
    {
        for(int i = 0; i < nums.Length-1; i++)
        {
            if(nums[i]>nums[i+1])
                return i + 1;
        }
        return 0;

        
        
    }

    public static int Approach_Three(int[] nums) 
    {
        int s = 0;
        int e = nums.Length -1;

        while(s < e)
        {
            int mid = s + (e-s)/2;

            if(nums[mid] > nums[e])
                s =  mid + 1;
            else
                e = mid;
        }
        return s;
    }

    public static void Test()
    {
        (int[] input, int expected)[] cases =
        [
            ([1, 1, 2, 3, 3, 4, 4, 8, 8], 2),
            ([3, 3, 7, 7, 10, 11, 11], 10),
            ([1], 1),
            ([1, 1, 2], 2),
            ([1, 2, 2], 1),
            ([1, 1, 2, 2, 3], 3),
            ([1, 1, 2, 2, 3, 3, 4], 4),
            ([1, 1, 2, 2, 3, 3, 4, 4, 5], 5),
            ([1, 1, 2, 2, 3, 4, 4, 5, 5], 3),
            ([1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6], 4),
            ([1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6], 6)
        ];

        int pass = 0, fail = 0;

        foreach (var (input, expected) in cases)
        {
            int result = Approach_Five(input);

            string status = result == expected ? "PASS" : "FAIL";

            Console.WriteLine(
                $"[{status}] Input: [{string.Join(", ", input)}] " +
                $"=> {result} (Expected: {expected})"
            );
            if (result == expected)
                pass++;
            else
                fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
    
}
