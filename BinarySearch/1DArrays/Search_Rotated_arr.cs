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
 *
 * Complexity:
 *   Time  : O(log n)
 *   Space : O(1)
 *
 * Notes:
 *   - Array is sorted in ascending order.
 *   - Use mid = low + (high - low) / 2 to avoid integer overflow.
 */

public class Search_Rotated_arr
{
// ============================================================
// Approach One: Linear Search
// Time: O(n)
// Space: O(1)
// ============================================================
    public static int Approach_One(int[] nums, int target) // Linear Search
    {
        foreach(int n in nums)
        {
            if(n == target)
                return Array.IndexOf(nums, n);
        }
        return -1;
    }

// ============================================================ 
// 
// Approach Two: Find Pivot + Binary Search 
//  Time: O(log n) 
//  Space: O(1) 
// ============================================================
    public static int Approach_Two(int[] nums, int target) // Using Pivot and Binary Search
    {
        int pivot = FindPivot(nums);

        if(target >=nums[pivot] && target <= nums[nums.Length-1]) //right half
        {
            return BinarySearch(nums, pivot, nums.Length-1, target);
        }
        else //left half
        {
            return BinarySearch(nums, 0, pivot-1, target);
        }
        
        return -1;
    }

    public static int BinarySearch(int[] nums, int s, int e, int target)
    {
        while(s <= e)
        {
            int mid = s + (e-s)/2;

            if(nums[mid] == target)
                return mid;
            else if(nums[mid] < target)
                s = mid + 1;
            else
                e = mid - 1;
        }
        return -1;
    }

    public static int FindPivot(int[] nums)
    {
        int s=0;
        int e = nums.Length - 1;

        while (s <= e)
        {
            int mid = (s+e)/2;

            if (nums[mid] < nums[e])
            {
                s=mid+1;
            }
            else
            {
                e=mid-1;
            }
        }
        return s;
    }

    public static int Approach_Three(int []nums, int target)
    {
        int s  = 0;
        int e = nums.Length - 1;

        while (s <= e)
        {
            int mid = s + (e-s)/2;

            if(nums[mid]== target)
                return mid;
            else if (nums[s] <= nums[mid])
            {
                if(target >= nums[s] && target < nums[mid])
                {
