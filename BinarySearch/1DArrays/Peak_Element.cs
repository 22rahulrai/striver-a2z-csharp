/*
 * Problem   : 162. Find Peak Element
 * Link      : https://leetcode.com/problems/find-peak-element/description/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search, 
 * Date      : 2026-08-11
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


public class Peak_Element
{
    public static int Approach_One(int[] nums) // BFS
    {
        int n = nums.Length-1;

        for(int i = 0; i < n; i++)
        {
            bool left = (i == 0) || nums[i]>nums[i-1];
            bool right = (i == n-1) || nums[i]>nums[i+1];

            if(left && right )
                return i;
        }
        return -1;
    }

    public static int Approach_Two(int[] nums) //using binary search
    {
        int n = nums.Length-1;
        int s = 0;
        int e = n;

        while(s < e)
        {
            int mid = s + (e-s)/2;

            if(nums[mid]>nums[mid+1])
                e = mid;
            else
                s = mid + 1;
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
            int result = Approach_Two(input);

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
