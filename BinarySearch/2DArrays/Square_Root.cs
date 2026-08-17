/*
 * Problem   : Sqrt(x)
 * Link      : https://leetcode.com/problems/sqrtx/description
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Binary Search, Math
 * Date      : 2026-08-16
 *
 * Problem:
 * Given a non-negative integer x, return the square root of x
 * rounded down to the nearest integer. The returned integer should
 * also be non-negative.
 *
 * You must not use any built-in exponent function or operator.
 *
 * Constraints:
 * - 0 <= x <= 2^31 - 1
 *
 *
 * Approaches:
 *
 * 1. Linear Search - Brute Force
 *
 * - Iterate from i = 0 to x.
 * - Check if i * i <= x.
 * - Keep updating the result whenever the condition is true.
 * - When i * i > x, break and return the result.
 *
 * Example:
 *
 *   x = 8
 *
 *   i = 0: 0 * 0 = 0 <= 8 ✓ (res = 0)
 *   i = 1: 1 * 1 = 1 <= 8 ✓ (res = 1)
 *   i = 2: 2 * 2 = 4 <= 8 ✓ (res = 2)
 *   i = 3: 3 * 3 = 9 > 8 ✗ (break)
 *
 *   Result: 2
 *
 * Time  : O(√x)
 * Space : O(1)
 *
 *
 * 2. Binary Search - Optimal
 *
 * - Use two pointers: left = 0, right = x.
 * - Find the middle element and check if mid * mid <= x.
 * - If true, the answer could be mid or greater, search right.
 * - If false, the answer is smaller, search left.
 * - Continue until left > right.
 * - Return right (the largest number whose square is <= x).
 *
 * Example:
 *
 *   x = 8
 *
 *   left = 0, right = 8
 *   mid = 4: 4 * 4 = 16 > 8 (search left) → right = 3
 *
 *   left = 0, right = 3
 *   mid = 1: 1 * 1 = 1 <= 8 (search right) → left = 2
 *
 *   left = 2, right = 3
 *   mid = 2: 2 * 2 = 4 <= 8 (search right) → left = 3
 *
 *   left = 3, right = 3
 *   mid = 3: 3 * 3 = 9 > 8 (search left) → right = 2
 *
 *   left > right, return right = 2
 *
 * Time  : O(log x)
 * Space : O(1)
 *
 *
 * Notes:
 *
 * - The answer is always <= x.
 * - For x = 1, answer is 1.
 * - For x = 0, answer is 0.
 * - Binary Search is the optimal approach.
 * - We return the floor of the square root.
 */


public class Square_Root
{
    public static int Approach_One(int target)
    {
        if(target == 0)
            return 0;
        if(target == 1)
            return 1;

        int res = 0;

        for(int i = 0; i < target; i++)
        {
            if ((long)i * i <= target)
            {
                res = i;
            }
            else
            {
                break;
            }
        }
        return res;
    }

    
    
}
