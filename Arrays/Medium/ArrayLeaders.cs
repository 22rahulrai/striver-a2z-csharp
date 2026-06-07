/*
 * Problem   : Array Leaders
 * Link      : https://www.geeksforgeeks.org/problems/leaders-in-an-array-1587115620
 * Platform  : geeksforgeeks
 * Difficulty: Medium
 * Topic     : Arrays
 * Date      : 2026-06-07
 *
 * Approach:
 *  1. Brute force
       — Iterate through the array and for each element, check if it is greater than all the elements to its right.
       — If it is, add it to the list of leaders.
 *  2. Optimal Approach
       — Traverse the array from right to left, keeping track of the maximum element seen so far.
       — If the current element is greater than the maximum, it is a leader. Add it to the list and update the maximum.
       — Reverse the list of leaders before returning to maintain the original order.

 *
 * Complexity 
 *
 * Brute Force
 * Time  : O(n^2)
 * Space : O(1)
 *
 * Optimal
 * Time  : O(n)
 * Space : O(1) 
 *
