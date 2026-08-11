/*
 * Problem   : 540. Single Element in a Sorted Array
 * Link      : https://leetcode.com/problems/single-element-in-a-sorted-array/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search, Bit Manipulation
 * Date      : 2026-07-30
 *
 * Approaches:
 *
 * 1. HashMap
 *    - Store the frequency of each element.
 *    - Return the element with frequency 1.
 *    - Time  : O(n)
 *    - Space : O(n)
 *
 * 2. XOR
 *    - Every paired element cancels out.
 *    - The remaining value is the single element.
 *    - Time  : O(n)
 *    - Space : O(1)
 *
 * 3. Linear Search
 *    - Check adjacent elements to find the unpaired element.
 *    - Time  : O(n)
 *    - Space : O(1)
 *
 * 4. Binary Search
 *    - Before the single element, pairs start at even indices.
 *    - After the single element, this pattern is shifted.
 *    - Use this pattern to eliminate half of the search space.
 *    - Time  : O(log n)
 *    - Space : O(1)
 *
 * Notes:
 * - Array is sorted.
 * - Every element appears exactly twice except one element.
 * - The array contains an odd number of elements.
 * - For the optimal solution, binary search is used.
 */
