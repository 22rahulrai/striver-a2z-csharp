/*
 * Problem: 1283. Find the Smallest Divisor Given a Threshold
 * Link: https://leetcode.com/problems/find-the-smallest-divisor-given-a-threshold/
 * Platform: LeetCode
 * Difficulty: Medium
 * Topic: Array, Binary Search
 * Date: 2026-08-29
 *
 * Approach 1: Brute Force
 * - Try every possible divisor from 1 to the largest number.
 * - For each divisor, calculate the sum of:
 *   ceil(nums[i] / divisor)
 * - If the sum is less than or equal to the threshold,
 *   return that divisor.
 * - Since divisors are checked from smallest to largest,
 *   the first valid divisor is the answer.
 *
 * Approach 2: Binary Search
 * - The possible divisor ranges from 1 to the largest number.
 * - Use binary search to find the smallest divisor that makes
 *   the total sum less than or equal to the threshold.
 * - If the current divisor works:
 *   sum <= threshold -> try a smaller divisor.
 * - If the current divisor does not work:
 *   sum > threshold -> need a larger divisor.
 *
 * Complexity:
 * Approach 1: Time: O(n * m), Space: O(1)
 * Approach 2: Time: O(n log m), Space: O(1)
 *
 * Notes:
 * - n = number of elements in nums.
 * - m = maximum value in nums.
 * - The array does not need to be sorted.
 * - For each number, we need ceiling division:
 *   (num + divisor - 1) / divisor
 * - Use long for the sum to avoid integer overflow.
 */

public class Find_Divisor
{
    public static int Approach_One(int[] nums, int threshold)
    {
        int max = 0;
        foreach (int n in nums)
        {
            max = Math.Max(n, max);
        }

        for (int d = 1; d <= max; d++)
        {
            long sum = 0;
            foreach (int n in nums)
            {
                sum += (n + d - 1) / d;

                if (sum > threshold)
                    break;
            }
            if (sum <= threshold)
                return d;
        }
        return -1;
    }

    public static int Approach_Two(int[] nums, int threshold) //binary search
    {
        int max = 0;
        foreach(int num in nums){
            max = Math.Max(max,num);
        }

        int s =1, e=max;

        while(s < e){
            int mid = s + (e-s)/2;
            int sum = 0;

            foreach(int num in nums){
                sum += (num + mid -1)/mid;
            }

            if(sum<=threshold){
                e = mid;
            }
            else{
                s = mid + 1;
            }   
        }

        return s;
    }

    public static long Findhr(int[] arr, int h)
    {
        long totalhr = 0;

        foreach (int bananas in arr)
        {
            totalhr += (bananas + h - 1) / h;
        }

        return totalhr;
    }

    public static void Test()
    {
        var testCases = new (int[] input, int h, int expected)[]
        {
            (new int[] { 1, 2, 5, 9 }, 6, 5),
            (new int[] { 2, 3, 5, 7, 11 }, 11, 3),
            (new int[] { 44, 22, 33, 11, 1 }, 5, 44),
            (new int[] { 19 }, 5, 4),
            ( new int[] { 1000000, 1000000 }, 2, 1000000 )
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
