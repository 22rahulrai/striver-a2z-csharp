/*
 * Problem   : 231. Power of Two
 * Link      : https://leetcode.com/problems/power-of-two/description/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Bit Manipulation, Recursion
 * Date      : 2026-06-3
 *
* Approaches:
 *
 *   
 *
 *   1. Brute Force 
 *      - Start with 1 (2^0) and keep multiplying by 2 until you reach or exceed n.
 *      - If you reach n, it's a power of two; if you exceed n, it's not.

 *   2. Bit Manuplation 
 *      - A number that is a power of two has exactly one bit set in its binary representation.

 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(logn)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(1)
 *          Space : O(1)
 *      Approach 3:
 *          Time  : O(1)
 *          Space : O(1)

    Notes / Gotchas:
 *      - A number that is a power of two has exactly one bit set in its binary representation.
 */

using System.Numerics;

public class PowerofTwo {

    public static bool ApproachOne(int n) {
        if(n <= 0)
            return false;

        long power = 1;

        while(power < n)
        {
            power *= 2;
        }

        return power == n;
    }

    public static bool ApproachTwo(int n)
    {
        if(n <= 0)
            return false;
        
        if( (n& n-1) == 0)
            return true;

        return false;
    }

    public static bool ApproachThree(int n)
    {
        return n >0 && BitOperations.PopCount((uint)n) == 1;
    }

    public static void Test()
    {
        (int input, bool expected)[] cases =
        [
            (1,    true),
            (16,   true),   
            (3,    false),   
            (4,    true),   
            (5,    false),
            (0,    false),   
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
