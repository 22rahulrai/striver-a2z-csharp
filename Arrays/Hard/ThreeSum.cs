/*
 * Problem   : 3Sum
 * Link      : https://leetcode.com/problems/3sum/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Arrays, Two Pointers, Sorting
 * Date      : 2026-06-09
 *
 * Approach:
 * 1. Brute Force
 *    - Generate all possible triplets using three nested loops.
 *    - Check if their sum equals zero.
 *    - Sort each triplet and avoid duplicates.
 * 2. HashSet Based
 *    - Fix one element.
 *    - Use HashSet to solve the remaining 2-Sum problem.
 *    - Store sorted triplets in a set to remove duplicates.
 *
 * 3. Optimal Two Pointer
 *    - Sort the array.
 *    - Fix one element and use two pointers.
 *    - Skip duplicates while traversing.
 *
 *
 * Complexity 
 *
 * Brute Force
 * Time  : O(n^3)
 * Space : O(1)
 *
 * HashSet
 * Time  : O(nÂ²)
 * Space : O(n)
 *
 * Optimal Two Pointer
 * Time  : O(nÂ²)
 * Space : O(1)
 *
 * Notes / Gotchas:
 *   - Sorting enables duplicate removal efficiently.
 *   - Two Pointer approach is the standard interview solution.
