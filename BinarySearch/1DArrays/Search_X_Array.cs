/*
 * Problem   : 704. Binary Search
 * Link      : https://leetcode.com/problems/binary-search/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Array, Binary Search
 * Date      : 2026-07-26
 *
 * Approaches:
 *   1. Binary Search (Optimal)
 *      - Applicable only for sorted arrays.
 *      - Repeatedly divide the search space in half.
 *
 * Complexity:
 *   Approach 1:
 *      Time  : O(log n)
 *      Space : O(1)
 *
 * Notes / Gotchas:
 *   - Binary Search requires the array to be sorted.
 *   - Use mid = low + (high - low) / 2 to avoid integer overflow.
 */

public class Search_X_Array {

    public static int Approach_One(int[] nums, int target) {

        int l = 0;
        int h = nums.Length - 1;

        while(l <= h){
            int mid = l + (h-l)/2;

            if(nums[mid] == target)
                return mid;
            else if(nums[mid] > target)
                h = mid - 1;
            else
                l = mid + 1;
        }

        return -1;
    }

    public static void Test()
    {
        //tuple array
        (int[] input, int target,int expected)[] cases =
        [
            ([-1,0,3,5,9,12], 9, 4),
            ([-1,0,3,5,9,12], 2, -1),
            ([1,2,3,4,5], 1, 0),
            ([1,2,3,4,5], 5, 4),
            ([1,2,3,4,5], 6, -1)
        ];

        int pass = 0, fail = 0;
        foreach (var (input, target,expected) in cases)
        {
            int result = Approach_One(input,target);
