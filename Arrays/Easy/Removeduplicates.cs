/*
 * Problem   : Remove Duplicates from Sorted Array
 * Link      : https://leetcode.com/problems/remove-duplicates-from-sorted-array/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-05-04
 *
 * Approach:
 *   1. Brute force — use a HashSet to track seen elements, overwrite array in-place, return count.
 *   2. Two-pointer — if array is sorted, use two pointers to overwrite duplicates in-place, return new length.
 *
 * Complexity : Brute | Optimal 
 *      Time  : O(n)  | O(n) 
 *      Space : O(n)  | O(1)
 *
 * Notes / gotchas:
 *   - Initialize result to int.MinValue to handle all-negative arrays.
 */

public class RemoveDuplicates {
    public static int approach_one(int[] arr) {
        HashSet<int> temp = new HashSet<int>();
        int index = 0;
        foreach (int n in arr){
            if(!temp.Contains(n)){
                //added to set 
                temp.Add(n);
                //add to current index
                arr[index] = n ;

                index++;
            }
        }

        return index;
    }

    public static int approach_two(int[] arr) { //optimal
        if(arr.Length == 0 ) return 0;

        int index = 1;

        for(int i =1; i<arr.Length;i++){
            if(arr[i]!=arr[i-1]){
                arr[index++]=arr[i];
            }
        }

        return index;
    }


    public static void Test()
    {
        (int[] input, int expected)[] cases =
        [
            ([3, 3, 6, 1],        3),   
            ([0,0,1,1,1,2,2,3,3,4], 5),
            ([1,1,2,2,2,3,3],  3),   
            ([1,1,1,2,2,3,3,3,3,4,4], 4),    
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int result = approach_two(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
