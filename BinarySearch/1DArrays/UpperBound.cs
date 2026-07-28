/*
 * Problem   : Upper Bound in a Sorted Array
 * Topic     : Binary Search
 * Difficulty: Easy
 * Date      : 2026-07-26
 *
 * Definition:
 *   Upper Bound of x = the index of the first element
 *   that is strictly greater than x.
 *   If no such element exists, returns arr.Length.
 *
 * Approach:
 *   1. Binary Search
 *      - If arr[mid] > x, it can be the answer.
 *      - Store it and continue searching on the left.
 *      - Otherwise, search on the right.
 *
 * Complexity:
 *   Time  : O(log n)
 *   Space : O(1)
 *
 * Notes:
 *   - Array must be sorted.
 *   - Use mid = first + (last - first) / 2 to avoid overflow.
 */
public class UpperBound {

    public static int Approach_One(int[] arr, int x) {

        int first = 0;
        int last = arr.Length - 1;
        int ans = -1;
        
        while(first <= last){
            int mid = first + (last-first)/2;
            
            if(arr[mid] > x){
                ans = mid;
                last = mid - 1;
            }
