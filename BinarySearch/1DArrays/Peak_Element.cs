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
 * 1. Linear Search
 *
 * - A peak element is an element that is strictly greater than its neighbors.
 *
 * - For the first element, only the right neighbor needs to be checked.
 *
 * - For the last element, only the left neighbor needs to be checked.
 *
 * - Since nums[-1] and nums[n] are considered negative infinity,
 *   an edge element can also be a peak.
 *
 * - Scan the array from left to right and return the first peak found.
 *
 * - Time  : O(n)
 * - Space : O(1)
 *
 *
 * 2. Binary Search
 *
 * - Compare nums[mid] with nums[mid + 1].
 *
 * - If nums[mid] > nums[mid + 1], we are on a descending slope.
 *   Therefore, a peak must exist at mid or somewhere to its left.
 *
 * - Otherwise, we are on an ascending slope.
 *   Therefore, a peak must exist somewhere to the right of mid.
 *
 * - This allows us to discard half of the search space at every step.
 *
 * - When start == end, that index is guaranteed to be a peak.
 *
 * - Time  : O(log n)
 * - Space : O(1)
 *
 * Notes:
 * - The array is not necessarily sorted.
 * - Adjacent elements are not equal.
 * - There can be multiple peak elements.
 * - We only need to return the index of any peak element.
 * - nums[-1] and nums[n] are considered negative infinity.
 * - For the optimal solution, binary search is used.
 *
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
            ([1, 2, 3, 1], 2),
            ([1, 2, 1, 3, 5, 6, 4], 5),
            ([1], 0),
            ([1, 2], 1),
            ([2, 1], 0),
            ([1, 2, 3], 2),
            ([3, 2, 1], 0),
            ([1, 3, 2], 1),
            ([1, 2, 3, 4, 5], 4),
            ([5, 4, 3, 2, 1], 0),
            ([1, 3, 2, 4, 3], 1)
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
