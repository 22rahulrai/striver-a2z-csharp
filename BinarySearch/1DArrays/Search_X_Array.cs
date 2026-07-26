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
