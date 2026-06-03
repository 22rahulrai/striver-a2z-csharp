/*
 * Problem   : 53. Maximum Subarray
 * Link      : https://leetcode.com/problems/maximum-subarray/description/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Arrays, Kadane's Algorithm
 * Date      : 2026-06-2
 *
* Approaches:
 *
 *   1. Brute Force 
 *      - Try buying on every day.
 *      - Check all future days as selling days.
 *      - Track maximum profit.
 *
 *   2. Better Approach using Dictionary
 *      - Maintain minimum stock price seen so far.
 *      - For each day calculate:
 *           profit = currentPrice - minimumPriceSeen
 *      - Update maximum profit.

 *   3. Optimal Approach 
 *      - Use Boyer-Moore Voting Algorithm:
        - Initialize a candidate and count.
        - Iterate through the array:
            - If count is 0, set candidate to current element.
            - If current element is the candidate, increment count; otherwise, decrement count.
        - The candidate at the end will be the majority element.
 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n^3)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(1)
 *      Approach 3:
 *          Time  : O(n)
 *          Space : O(1)
    Notes / Gotchas:
 *      - The majority element is the element that appears more than n/2 times in the array.
 */

public class PowerofTwo {

    public static bool ApproachOne(int n) {
        if(n <= 0)
            return false;
        
        if( (n& n-1) == 0)
            return true;

        return false;
    }

    public static int ApproachThree(int[] nums) { //better approach using dictionary
        int n = nums.Length;
        int candidate = -1;
        int count = 0;

        foreach(int num in nums){
            if(count == 0)
            {
                candidate = num;
            }

            if(num == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return candidate;
    }

    public static void Test()
    {
        (int input, bool expected)[] cases =
        [
            (1, true),
            (16, true),   
            (3, false),   
            (4, true),   
            (5, false),
            (0, false),   
            (-2, false),   
            (1024, true),   
            (1023, false),
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            bool result = ApproachOne(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
