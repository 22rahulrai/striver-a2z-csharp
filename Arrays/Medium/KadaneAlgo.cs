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
 *          Time  : O(n^2)
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

public class KadaneAlgo {

    public static int ApproachOne(int[] arr) {//brute force
        int n = arr.Length;

        for(int i = 0; i < n; i++)
        {
            int count =0;
            for(int j = 0; j < n; j++)
            {
                if (arr[i] == arr[j])
                {
                    count++;
                }
            }

            if(count > (n/2))
            {
                return arr[i];
            }
        }

        return -1;
    }

    public static int ApproachTwo(int[] nums) { //better approach using dictionary
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
        (int[] input, int expected)[] cases =
        [
            ([7, 0, 0, 1, 7, 7, 2, 7, 7], 7),   
            ([1, 1, 1, 2, 1, 2],          1),
            ([2,2,1,1,1,2,2],             2),   
            ([3,2,3],                     3),   
            ([1, 1, 1],                   1),   
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int result = ApproachThree(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
