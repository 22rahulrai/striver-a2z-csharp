/*
 * Problem   : Largest Element in an Array
 * Link      : https://takeuforward.org/plus/dsa/problems/largest-element
 * Platform  : TUF
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-04-28
 *
 * Approach:
 *   1. Linear scan — track max as we iterate, return at end.
 *   2. Built-in — use LINQ's Max() for one-liner.
 *
 * Complexity:
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Notes / gotchas:
 *   - Initialize result to int.MinValue to handle all-negative arrays.
 */

public class LargestElement {
    public static int approach_one(int[] arr) {
        int res = int.MinValue;
        foreach ( int num in arr ) {
            if ( num > res ) {
                res = num;
            }
        }

        return res;
    }

    public static int approach_two(int[] arr) {
        return arr.Max();
    }


    public static void Test()
    {
        (int[] input, int expected)[] cases =
        [
            ([3, 3, 6, 1],        6),   
            ([3, 3, 0, 99, -40], 99),
            ([-4, -3, 0, 1, -8],  1),   
            ([-5, -2, -8],       -2),   
            ([7],                 7),   
            ([1, 1, 1],           1),   
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
