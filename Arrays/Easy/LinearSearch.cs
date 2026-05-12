/*
 * Problem   : Linear Search in an Array
 * Link      : https://takeuforward.org/plus/dsa/problems/linear-search?source=strivers-a2z-dsa-track
 * Platform  : GeeksforGeeks
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-05-12
 *
  * Approach:
 *   1. Brute force — iterate through the array and return index if target is found, else -1.
 *
  * Complexity: APPROACH 1 Brute Force
 *   Time  : O(n) since we may have to check each element once
 *   Space : O(1)
 *
 * Notes / gotchas:
*   - Return the index of the first occurrence of the target.
 */

using System.ComponentModel;

public class LinearSearch {
    //Brute force approach 
    public static int approach_one(int[] nums, int target) 
    {
        for(int i=0;i<nums.Length;i++){
            if(nums[i] == target){
                return i;
            }
        }
        return -1;
    }

    public static void Test()
    {
        //tuple array
        (int[] input, int target,int expected)[] cases =
        [
            ([2, 3, 4, 5, 3], 3,1),   
            ([2, -4, 4, 0, 10], 6,-1),
            ([1, 3, 5, -4, 1], 1,0),
            ([1, 2, 3, 4, 5], 5,4),
            ([1, 2, 3, 4, 5], 6,-1),
        ];

        int pass = 0, fail = 0;
        foreach (var (input, target,expected) in cases)
        {
            int result = approach_one(input,target);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
