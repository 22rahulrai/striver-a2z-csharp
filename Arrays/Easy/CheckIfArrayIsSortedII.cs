/*
 * Problem   : Check if Array Is Sorted and Rotated
 * Link      : https://leetcode.com/problems/check-if-array-is-sorted-and-rotated/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-04-24
 *
 * Approach:
 *   1. Brute force — check all n rotations if each is sorted, O(n^2). Skipped.
 *   2. Count violations — a sorted-rotated array can have at most one point
 *      where nums[i] > nums[i+1]. Also check the wrap-around (last vs first).
 *
  * Complexity: APPROACH 1 Brute Force
 *   Time  : O(n2) due to sorting
 *   Space : O(1)
 * Complexity: APPROACH 2 Optimal
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Notes / gotchas:
 *   - Must also check the wrap-around edge: nums[n-1] > nums[0].
 *   - More than one violation means it can't be a valid rotation.
 */

public class CheckIfArrayIsSortedII {
    public bool Check(int[] nums) {
        int count = 0;
        int n = nums.Length;

        for (int i = 0; i < n - 1; i++) {
            if (nums[i] > nums[i + 1]) {
                count++;
            }
        }

        // Important circular check
        if (nums[n - 1] > nums[0]) {
            count++;
        }

        // Return true if there's at most one violation
        return count <= 1;
    }

    public static void Test()
    {
        var solution = new CheckIfArrayIsSortedII();

        (int[] input, bool expected)[] cases =
        [
            ([3, 4, 5, 1, 2], true),
            ([2, 1, 3, 4],   false),
            ([1, 2, 3],      true),
            ([1, 1, 1],      true),
            ([2, 1],         true),
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            bool result = solution.Check(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
