/*
 * Problem   : 153. Find Minimum in Rotated Sorted Array
 * Link      : https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search
 * Date      : 2026-07-30
 *
 * Approaches:
 *
 * 1. Linear Search
 *    - Traverse the array and find the minimum element.
 *    - Time  : O(n)
 *    - Space : O(1)
 *
 * 2. Binary Search
 *    - Compare nums[mid] with nums[e].
 *    - If nums[mid] > nums[e], minimum is on the right.
 *    - Otherwise, mid can be the minimum, so keep mid.
 *    - When s == e, nums[s] is the minimum.
 *    - Time  : O(log n)
 *    - Space : O(1)
 *
 * Notes:
 * - Array is sorted in ascending order before rotation.
 * - All elements are unique.
 * - Use mid = s + (e - s) / 2 to avoid integer overflow.
 */

public class Minimum_Rotated_arr
{
    public static int Approach_One(int[] nums)
    {
        int min = nums[0];

        foreach(var n in nums)
        {
            if(n < min)
            {
                min = n;
            }
        }

        return min;
    }

    public static int Approach_Two(int[] nums)
    {
        int s = 0;
        int l = nums.Length - 1;

        while(s < l)
        {
            int mid = s + (l - s) / 2;

            if(nums[mid] > nums[l])
            {
                s = mid + 1;
            }
            else
            {
                l = mid;
            }
        }

        return nums[s];
    }

    
    public static void Test()
    {
        (int[] input, int expected)[] cases =
        [
            ([3, 4, 5, 1, 2], 1),
            ([4, 5, 6, 7, 0, 1, 2], 0),
            ([11, 13, 15, 17], 11),
            ([1, 2, 3, 4, 5], 1),
            ([1], 1),
            ([2, 1], 1),
            ([1, 2], 1),
            ([5, 1, 2, 3, 4], 1),
            ([2, 3, 4, 5, 1], 1),
            ([6, 7, 8, 9, 1, 2, 3, 4, 5], 1),
            ([4, 5, 6, 7, 8, 1, 2, 3], 1)
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
