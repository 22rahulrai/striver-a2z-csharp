/*
 * Problem   : Floor in a Sorted Array
 * Topic     : Binary Search
 * Difficulty: Easy
 * Date      : 2026-07-26
 *
 * Definition:
 *   Floor of x = the largest element in the array that is less than or equal to x.
 *   Returns the index of the floor element.
 *   If no floor exists, returns -1.
 *
 * Approach:
 *   1. Binary Search
 *      - If arr[mid] <= x, it can be the answer.
 *      - Store it and search on the right for a larger valid element.
 *      - Otherwise, search on the left.
 *
 * Complexity:
 *   Time  : O(log n)
 *   Space : O(1)
 *
 * Notes:
 *   - Array must be sorted.
 *   - Use mid = low + (high - low) / 2 to avoid integer overflow.
 */
