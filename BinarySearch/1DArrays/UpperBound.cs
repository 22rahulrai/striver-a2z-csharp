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
            else{
                first = mid + 1;
            }
        }
        return ans;
    }

    public static void Test()
    {
        //tuple array
        (int[] input, int target,int expected)[] cases =
        [
            ([1, 2, 8, 10, 10, 12, 19], 5, 2),
            ([1, 2, 8, 10, 10, 12, 19], 11, 5),
            ([1, 2, 8, 10, 10, 12, 19], 0, 0),
            ([1, 2, 8, 10, 10, 12, 19], 20, 7),
            ([1, 2, 3, 4, 5], 1, 1),
            ([1, 2, 3, 4, 5], 5, 5),
            ([1, 2, 3, 4, 5], 3, 3)
        ];

        int pass = 0, fail = 0;
        foreach (var (input, target,expected) in cases)
        {
            int result = Approach_One(input,target);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) 
                pass++;
            else 
                fail++;
        }
