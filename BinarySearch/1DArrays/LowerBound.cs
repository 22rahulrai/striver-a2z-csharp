/*
 * Problem   : Floor in a Sorted Array
 * Topic     : Binary Search
 * Difficulty: Easy
 * Date      : 2026-08-04
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

public class LowerBound {

    public static int Approach_One(int[] arr, int x) {

        int first = 0;
        int last = arr.Length - 1;
        int ans = -1;
        
        while(first <= last){
            int mid = first + (last-first)/2;
            
            if(arr[mid] <= x){
                ans = mid;
                first = mid + 1;
            }
            else{
                last = mid - 1;
            }
        }
        return ans;
    }

    public static void Test()
    {
        //tuple array
        (int[] input, int target,int expected)[] cases =
        [
            ([1, 2, 8, 10, 10, 12, 19], 5, 1),
            ([1, 2, 8, 10, 10, 12, 19], 11, 4),
            ([1, 2, 8, 10, 10, 12, 19], 0, -1),
            ([1, 2, 8, 10, 10, 12, 19], 20, 6),
            ([1,2,3,4,5], 1, 0)
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

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
