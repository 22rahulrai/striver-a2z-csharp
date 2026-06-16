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
 *      - Iterate through all possible subarrays and calculate their sums.
 *
 *   2. Better Approach 
 *      - 

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

public class KadaneAlgo {

    public static int ApproachOne(int[] nums) {//brute force
        int n = nums.Length;
        int max = int.MinValue;

        for(int i = 0;i < n; i++){
            for(int j = i;j < n; j++){
                int sum = 0;
                for(int k = i;k <= j;k++){
                    sum += nums[k];
                }
                max = Math.Max(max,sum);   
            }
        }
        return max;
    }

    public static int ApproachTwo(int[] nums) {
        int n = nums.Length;
        int max = int.MinValue;

        for(int i = 0;i < n; i++){
            int sum = 0;
            for(int j = i;j < n; j++){
                sum += nums[j];   
                max = Math.Max(max,sum);
            }
        }
        return max;
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
