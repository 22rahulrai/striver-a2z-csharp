/*
 * Problem   : Single Number
 * Link      : https://leetcode.com/problems/single-number/description/
 * Platform  : GeeksforGeeks
 * Difficulty: Easy
 * Topic     : Arrays, Bit Manipulation
 * Date      : 2026-05-25
 *
 * Problem Statement:
 *   Given a non-empty array of integers nums, 
 *   every element appears twice except for one. Find that single one.
 *   
 *
 * Approaches:
 *   1. XOR Method
 *   2. 
 *
 * Complexity: APPROACH 1 (XOR)
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Complexity: APPROACH 2 (XOR)
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Notes / Gotchas:
 *   - Use long while calculating total sum to avoid integer overflow.
 *   - nums.Sum() on int[] can overflow for large inputs.
 */

public class SingleNumber {
    //Brute force approach 
    public static int Approach_One(int[] nums) 
    {
        int res = 0;
        
        foreach(int n in nums){
            res = res ^ n;
        }
        return res;
    }

    // public static int Approach_two(int[] nums)
    // {
    // }

    public static void Test()
    {
        //tuple array
        (int[] input, int expected)[] cases =
        [
            ([2,2,1], 1),   
            ([4,1,2,1,2],4),
            ([3], 3),
            ([8, 8, 7, 7, 6, 6, 1], 1),
        ];

        int pass = 0, fail = 0;
        foreach (var (input,expected) in cases)
        {
            int result = Approach_One(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
