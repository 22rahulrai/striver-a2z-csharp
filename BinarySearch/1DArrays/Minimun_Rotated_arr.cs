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
        (int[] input, int target, int []expected)[] cases =
        [
            (new int[] {5,7,7,8,8,10}, 8, new int[] {3,4}),
            (new int[] {5,7,7,8,8,10}, 6, new int[] {-1,-1}),
            (new int[] {}, 0, new int[] {-1,-1}),
            (new int[] {1}, 1, new int[] {0,0}),
            (new int[] {1}, 0, new int[] {-1,-1}),
            (new int[] {2,2}, 2, new int[] {0,1}),
            (new int[] {2,2,2,2}, 2, new int[] {0,3}),
            (new int[] {1,2,3,4,5}, 3, new int[] {2,2}),
            (new int[] {1,2,3,4,5}, 6, new int[] {-1,-1}),
            (new int[] {1,1,2,2,2,3,4}, 2, new int[] {2,4})
        ];

        int pass = 0, fail = 0;

        foreach (var (input, target, expected) in cases)
        {
            int [] result = Approach_One(input, target);
            bool success =
                result[0] == expected[0] &&
                result[1] == expected[1];

            string status = success ? "PASS" : "FAIL";

            Console.WriteLine(
                $"[{status}] Input: [{string.Join(", ", input)}], Target: {target} => [{string.Join(", ", result)}] (Expected: [{string.Join(", ", expected)}])");

            if (success)
                pass++;
            else
                fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
