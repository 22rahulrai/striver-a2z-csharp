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
