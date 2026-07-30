/*
 * Problem   : 35. Search Insert Position
 * Link      : https://leetcode.com/problems/search-insert-position/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Array, Binary Search
 * Date      : 2026-07-30
 *
 * Approach:
 *   1. Binary Search
 *      - If target exists, return its index.
 *      - Otherwise, return the index where it should be inserted
 *        to keep the array sorted.
 *
 * Complexity:
 *   Time  : O(log n)
 *   Space : O(1)
 *
 * Notes:
 *   - Array is sorted in ascending order.
 *   - Use mid = low + (high - low) / 2 to avoid integer overflow.
 */

public class Search_Insert_Position
{
    public static int Approach_One(int[] nums, int target)
    {
        int s = 0;
        int e = nums.Length - 1;

        while (s <= e)
        {
            int mid = s + (e - s) / 2;

            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                e = mid - 1;
            }
            else
            {
                s = mid + 1;
            }
        }

        // s is the correct insertion position
        return s;
    }

    public static void Test()
    {
        (int[] input, int target, int expected)[] cases =
        [
            ([1,3,5,6], 5, 2),
            ([1,3,5,6], 2, 1),
            ([1,3,5,6], 7, 4),
            ([1,3,5,6], 0, 0),
            ([1], 0, 0),
            ([1], 1, 0),
            ([1], 2, 1),
            ([1,2,3,4,5], 4, 3),
            ([1,2,3,4,5], 6, 5)
        ];

        int pass = 0, fail = 0;

        foreach (var (input, target, expected) in cases)
        {
            int result = Approach_One(input, target);
