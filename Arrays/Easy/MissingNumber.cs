/*
 * Problem   : Missing Number
 * Link      : https://www.geeksforgeeks.org/problems/missing-number-in-array1416/1
 * Platform  : GeeksforGeeks
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-04-29
 *
 * Problem Statement:
 *   Given an array of size n-1 containing distinct numbers
 *   from 1 to n, find the missing number.
 *
 * Approaches:
 *   1. Sum Formula
 *   2. XOR Method
 *
 * Complexity: APPROACH 1 (Sum Formula)
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

public class MissingNumber {
    //Brute force approach 
    public static int approach_one(int[] nums) 
    {
        int n = nums.Length+1;

        long totalsum = (long) n*(n+1)/2;
        long sum = 0;
        foreach(var i in nums)
        {
            sum += i;
        }

        return (int)(totalsum - sum);
        //  using LINQ
        // return (int)(totalsum - nums.Sum(x => (long)x));
    }

    // public static int approach_two(int[] nums)
    // {
    //     int n = nums.Length+1;
    // }

    public static void Test()
    {
        //tuple array
        (int[] input, int expected)[] cases =
        [
            ([1, 2, 3, 5], 4),   
            ([8, 2, 4, 5, 3, 7, 1],6),
            ([1, 2, 4, 5], 3),
            ([2, 3, 4, 5], 1),
        ];

        int pass = 0, fail = 0;
        foreach (var (input,expected) in cases)
        {
            int result = approach_one(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
