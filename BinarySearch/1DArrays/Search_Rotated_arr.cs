/*
 * Problem   : 33. Search in Rotated Sorted Array
 * Link      : https://leetcode.com/problems/search-insert-position/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Array, Binary Search
 * Date      : 2026-07-30
 *
 * Approach:
 *   1. Binary Search
 *      - If target exists, return its index.
 *      - Otherwise, return the index where it should be inserted
 *        to keep the array sorted.
    3. 
            Rotated Sorted Array
                 â†“
             Find mid
                 â†“
       Is left half sorted?
          /            \
        Yes             No
         â†“               â†“
   Left is sorted    Right is sorted
         â†“               â†“
 Is target in left?  Is target in right?
    /      \           /       \
  Yes      No        Yes       No
   â†“        â†“         â†“         â†“
 e=mid-1  s=mid+1   s=mid+1   e=mid-1
