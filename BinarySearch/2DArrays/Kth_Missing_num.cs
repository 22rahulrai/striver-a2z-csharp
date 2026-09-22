/*
 * Problem   : 1539. Kth Missing Positive Number
 * Link      : https://leetcode.com/problems/kth-missing-positive-number/description/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search
 * Date      : 2026-09-17
 *
 * Approach 1: HashSet (Brute Force)
 *   - Put elements in a HashSet.
 *   - Check numbers starting from 1 upwards.
 *   - Decrement k for every missing number.
 *   - Time: O(n + k), Space: O(n)
 *
 * Approach 2: Linear Search ("Pushing Target")
 *   - Iterate through array. If num <= k, push k forward.
 *   - Break when num > k.
 *   - Time: O(n), Space: O(1)
 *
 * Approach 3: Binary Search (Optimal)
 *   - Calculate missing numbers before mid: arr[mid] - (mid + 1).
 *   - Use binary search to find the exact boundary.
 *   - Time: O(log n), Space: O(1)
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

    public static int Approach_Three(int[] arr,int k) //binary search
    {
        int s = 0;
        int e = arr.Length -1;

        while (s <= e)
        {
            int mid = s + (e-s)/2;
            // The number of missing positive integers before index 'mid'
            int missing = arr[mid] - (mid+1);

            if(missing < k)
            {
                s = mid + 1;// Search right
            }
            else
            {
                e = mid - 1;// Search left
            }
        }
        return s+k;
    }

    public static void Test()
    {
        var testCases = new (int[] input, int h, int expected)[]
        {
            (new int[] { 2, 3, 4, 7, 11 }, 5, 9),
            (new int[] { 1, 2, 3, 4 }, 2, 6),
            (new int[] { 1, 2, 3 }, 5, 8),
            (new int[] { 5, 6, 7, 8, 9 }, 9, 14)
        };

        int pass = 0;
        int fail = 0;

        foreach (var (input, h, expected) in testCases)
        {
            int result = Approach_Three(input, h);

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
