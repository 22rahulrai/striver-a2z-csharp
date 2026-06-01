/*
 * Problem   : 121. Best Time to Buy and Sell Stock
 * Link      : https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
 * Platform  : TUF
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-06-01
 *
* Approaches:
 *
 *   1. Brute Force 
 *      - Use two nested loops to check every possible pair of buy and sell days.
        - Calculate profit for each pair and keep track of the maximum profit.
 *
 *   2. Better Approach 
 *     - Track the minimum price seen so far and calculate potential profit at each step.
        - Update maximum profit accordingly.

 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n^2)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(1)

    Notes / Gotchas:
        - Buy must happen before sell.
        - Only one transaction is allowed.
        - If no profit is possible, return 0.
        - Track minimum price seen so far.
 */

public class Stock {

    public static int ApproachOne(int[] arr) {//brute force
        int n = arr.Length;
        int maxProfit =0;

        for(int i = 0; i < n; i++)
        {
            int profit = 0;
            for(int j = i+1; j < n; j++)
            {
                profit = arr[j] - arr[i];
                maxProfit = Math.Max(maxProfit, profit);
            }
        }

        return maxProfit;
    }

    public static int ApproachTwo(int[] nums) {
        int n = nums.Length;
        int min = nums[0], maxProfit = 0;

        // for(int i = 1; i < n; i++)
        // {
        //     if (nums[i] < min)
        //     {
        //         min = nums[i];
        //     }
        //     else
        //     {
        //         int profit = nums[i] - min;
        //         maxProfit = Math.Max(maxProfit, profit);
        //     }
        // } 

        // simplified version of above code
        for(int i = 1; i < n; i++)
        {
            min = Math.Min(min, nums[i]);
            maxProfit = Math.Max(maxProfit, nums[i] - min);
        }
        return maxProfit;
    }

    public static int Approach_Three(int[] nums) {
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
        (int[] input, int expected)[] cases =
        [
            ([7,1,5,3,6,4],5),   
            ([7,6,4,3,1],  0),
            ([1,2,3,4,5],  4),   
            ([5],          0),   
            ([9,2,7,1,8],  7),   
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int result = ApproachTwo(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
