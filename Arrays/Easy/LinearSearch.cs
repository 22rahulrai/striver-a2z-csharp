/*
 * Problem   : Second Largest Element in an Array
 * Link      : https://www.geeksforgeeks.org/problems/second-largest3735/1
 * Platform  : GeeksforGeeks
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-04-29
 *
 * Approach:
 *   1. Brute force — sort the array and second largest is the second last unique element.
 *   2. 
 *
  * Complexity: APPROACH 1 Brute Force
 *   Time  : O(n log n) due to sorting
 *   Space : O(1)
 * Complexity: APPROACH 2 Optimal
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Notes / gotchas:
 *   - Initialize result to int.MinValue to handle all-negative arrays.
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
