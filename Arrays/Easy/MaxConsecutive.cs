/*
 * Problem   : Max Consecutive Ones
 * Link      : https://leetcode.com/problems/max-consecutive-ones
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Arrays, Bit Manipulation
 * Date      : 2026-05-25
 *
 * Problem Statement:
 *   Given a non-empty array of integers nums, 
 *   every element appears twice except for one. Find that single one.
 *   
 * Approaches:
 *   1. Brute Force
 *   2. Optimal solution
 *   3. LINQ GroupBy
 *
 * Complexity: APPROACH 1 (XOR) -- optimal
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Complexity: APPROACH 2 (HashMap / Dictionary)
 *   Time  : O(n)
 *   Space : O(n)
 *
 * Complexity: APPROACH 3 (Hashset)
 *   Time  : O(n)
 *   Space : O(n)
 *
 * Complexity: APPROACH 4 (LINQ)
 *   Time  : O(n)
 *   Space : O(n)
 * Notes / Gotchas:
 *   
 *   
 */

public class MaxConsecutive {
    public static int Approach_One(int[] nums) 
    {
        int n = nums.Length;
        int max = 0;
        for(int i = 0; i < n; i++)
        {
            int c = 0;
            for(int j = i; j < n; j++)
            {
                if(nums[j] == 1)
                    c++;
                else
                    break;
            }
            max = Math.Max(max, c);
        }
        return max;
    }

    public static int Approach_Two(int[] nums)
    {
        int max = 0;
        int c = 0;

        foreach(int n in nums){
            if(n == 1)
                c++;
            else
                c = 0;

            max = Math.Max(max, c);
        }
        return max;
    }

    public static int Approach_Three(int[] nums)
    {
        return string.Join("",nums)
            .Split('0')
            .Max(s => s.Length);
    }

    public static void Test()
    {
        //tuple array
        (int[] input, int expected)[] cases =
        [
            ([1,1,0,1,1,1], 3),   
            ([1,0,1,1,0,1],2),
            ([0,0,0], 0),
            ([1,1,1], 3)
        ];

        int pass = 0, fail = 0;
        foreach (var (input,expected) in cases)
        {
            int result = Approach_Three(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
