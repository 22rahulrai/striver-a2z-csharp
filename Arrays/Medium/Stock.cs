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
 *      - For each element, count its occurrences in the array.
        - If the count exceeds n/2, return that element.
 *
 *   2. Better Approach using Dictionary
 *      - Use a dictionary to count occurrences of each element.
        - Iterate through the dictionary to find the element with count > n/2.

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
 *          Time  : O(n^2)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(n)
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(1)
    Notes / Gotchas:
 *      - The majority element is the element that appears more than n/2 times in the array.
 */

public class Stock {

    public static int Approach_One(int[] arr) {//brute force
        int n = arr.Length;
        int maxProfit =0;

        for(int i = 0; i < n; i++)
        {
            int profit = 0;
            for(int j = i+1; j < n; j++)
            {
                if (arr[j] > arr[i])
                    profit = arr[j] - arr[i];

                maxProfit = Math.Max(maxProfit, profit);
            }
        }

        return maxProfit;
    }

    public static int Approach_Two(int[] nums) { //better approach using dictionary
        Dictionary<int,int> map = new Dictionary<int,int>();

        foreach(int n in nums){
            if(map.ContainsKey(n)){
                map[n]++;
            }
            else{
                map[n] = 1;
            }
        }

        int target = nums.Length/2;

        foreach(var n in map){
            if(n.Value > target){
                return n.Key;
            }
        }

        return -1;
    }

    public static int Approach_Three(int[] nums) { //better approach using dictionary
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
            ([7,1,5,3,6,4], 5),   
            ([7,6,4,3,1],          0),
            ([2,2,1,1,1,2,2],             2),   
            ([3,2,3],                     3),   
            ([1, 1, 1],                   1),   
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int result = Approach_One(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
