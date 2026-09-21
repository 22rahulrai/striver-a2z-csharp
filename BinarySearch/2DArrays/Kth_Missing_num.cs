/*
 * Problem   : 1539. Kth Missing Positive Number
 * Link      : https://leetcode.com/problems/kth-missing-positive-number/description/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search
 * Date      : 2026-09-17
 *
 * Approach 1: Brute Force
 *   - Try every possible eating speed from 1 to the largest pile.
 *   - For each speed, calculate the total hours needed to eat all
 *     the bananas.
 *   - If Koko can finish within h hours, return that speed.
 *   - This gives the minimum valid eating speed.
 *
 * Approach 2: Binary Search
 *   - The possible eating speed ranges from 1 to the largest pile.
 *   - Use binary search to find the minimum speed that allows Koko
 *     to finish all bananas within h hours.
 *   - If the current speed works, search for a smaller speed.
 *   - Otherwise, search for a larger speed.
 *
 * Complexity:
 *
 *   Approach 1:
 *     Time  : O(n * m)
 *     Space : O(1)
 *
 *   Approach 2:
 *     Time  : O(n log m)
 *     Space : O(1)
 *
 * Notes:
 *   - n = number of banana piles.
 *   - m = maximum number of bananas in a pile.
 *   - The array does not need to be sorted.
 *   - Hours for a pile can be calculated using ceiling division:
 *       (pile + speed - 1) / speed
 *   - Use long for the total hours to avoid integer overflow.
 */

public class Kth_Missing_num
{
    public static int Approach_One(int[] arr, int k)
    {
        int num =1;
        HashSet<int> set = new HashSet<int>(arr);

        while (true)
        {
            if (!set.Contains(num))
            {
                k--;

                if(k == 0)
                    return num;
            }
            num++;
        }
    }

    public static int Approach_Two(int[] arr, int k) //Linear search
    {
        foreach(int n in arr)
        {
            if (n <= k)
            {
                k++;
            }
            else
            {
                break;
            }
        }
        return k;
    }

    public static int Approach_Three(int[] arr,int k) //binart search
    {
        
    }


    public static void Test()
    {
        var testCases = new (int[] input, int h, int expected)[]
        {
            (new int[] { 2, 3, 4, 7, 11 }, 5, 9),
            (new int[] { 30, 11, 23, 4, 20 }, 5, 30),
            (new int[] { 30, 11, 23, 4, 20 }, 6, 23),
            (new int[] { 805306368, 805306368, 805306368 }, 1000000000, 3)
        };

        int pass = 0;
        int fail = 0;

        foreach (var (input, h, expected) in testCases)
        {
            int result = Approach_Two(input, h);

            if (result == expected)
            {
                Console.WriteLine(
                    $"[PASS] Piles: [{string.Join(", ", input)}], " +
                    $"Hours: {h}, Output: {result}, Expected: {expected}"
                );
                pass++;
            }
            else
            {
                Console.WriteLine(
                    $"[FAIL] Piles: [{string.Join(", ", input)}], " +
                    $"Hours: {h}, Output: {result}, Expected: {expected}"
                );
                fail++;
            }
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
