/*
 * Problem   : 81. Search in Rotated Sorted Array 2
 * Link      : https://leetcode.com/problems/search-in-rotated-sorted-array/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search
 * Date      : 2026-09-03
 *
 * Approaches:
 *
 *   1. Linear Search
 *      - Traverse the array and check each element.
 *
 *      Time  : O(n)
 *      Space : O(1)
 *
 *   2. Pivot + Binary Search
 *      - Find the smallest element (pivot).
 *      - The pivot divides the array into two sorted halves.
 *      - Apply Binary Search on the appropriate half.
 *
 *      Time  : O(log n)
 *      Space : O(1)
 *
 *   3. One-Pass Binary Search (Optimal)
 *      - Find mid and determine which half is sorted.
 *      - If the left half is sorted:
 *          - Check whether target lies in the left half.
 *          - If yes, search left; otherwise search right.
 *      - Otherwise, the right half is sorted:
 *          - Check whether target lies in the right half.
 *          - If yes, search right; otherwise search left.
 *
 *      Time  : O(log n)
 *      Space : O(1)

        Rotated Sorted Array
                 ↓
          Find mid
                 ↓
       Is left half sorted?
          /            \
        Yes             No
         ↓               ↓
   Left is sorted    Right is sorted
         ↓               ↓
 Is target in left?  Is target in right?
    /      \           /       \
  Yes      No        Yes       No
   ↓        ↓         ↓         ↓
 e=mid-1  s=mid+1   s=mid+1   e=mid-1

 *
 * Notes / Gotchas:
 *   - The array was originally sorted in ascending order and then rotated.
 *   - There are no duplicate elements.
 *   - At least one half of the array is always sorted.
 *   - Use mid = low + (high - low) / 2 to avoid integer overflow.
 */

public class Search_Rotated_arr2
{
    public static bool Approach_One(int[] nums, int target) // Linear Search
    {
        foreach (int n in nums)
        {
            if (n == target)
                return true;
        }
        return false;
    }

    public static bool Approach_Two(int[] nums, int target) // Using Pivot and Binary Search
    {
        if(nums == null || nums.Length ==0) return false;
        int pivot = FindPivot(nums);

        //right half
        if (target >= nums[pivot] && target <= nums[nums.Length - 1])
        {
            return BinarySearch(nums, pivot, nums.Length - 1, target);
        }

        //left half
        return BinarySearch(nums, 0, pivot - 1, target);
    }

    public static bool BinarySearch(int[] nums, int s, int e, int target)
    {
        while (s <= e)
        {
            int mid = s + (e - s) / 2;

            if (nums[mid] == target)
                return true;
            else if (nums[mid] < target)
                s = mid + 1;
            else
                e = mid - 1;
        }
        return false;
    }

    public static int FindPivot(int[] nums)
    {
        int s = 0;
        int e = nums.Length - 1;

        while (s < e)
        {
            int mid = s + (e - s) / 2;

            if (nums[mid] > nums[e])
            {
                s = mid + 1;
            }
            else if(nums[mid]<nums[e])
            {
                e = mid;
            }
            else
            {
                e--;
            }
        }
        return s;
    }

    

    public static void Test()
    {


        (int[] input, int target, bool expected)[] cases =
        [
            ([2, 5, 6, 0, 0, 1, 2], 0, true),
            ([2, 5, 6, 0, 0, 1, 2], 3, false),

            ([1], 0, false),
            ([1], 1, true),

            ([1, 0, 1, 1, 1], 0, true),
            ([1, 0, 1, 1, 1], 1, true),
            ([1, 0, 1, 1, 1], 2, false),

            ([1, 1, 1, 1, 1], 1, true),
            ([1, 1, 1, 1, 1], 2, false),

            ([1, 1, 3, 1], 3, true),
            ([1, 1, 3, 1], 2, false),

            ([3, 1, 1, 1, 2, 3, 3], 2, true),
            ([3, 1, 1, 1, 2, 3, 3], 4, false),

            ([4, 5, 6, 7, 0, 1, 2], 0, true),
            ([4, 5, 6, 7, 0, 1, 2], 3, false),
            ([4, 5, 6, 7, 0, 1, 2], 5, true),
            ([4, 5, 6, 7, 0, 1, 2], 7, true),

            ([6, 7, 0, 1, 2, 4, 5], 6, true),
            ([6, 7, 0, 1, 2, 4, 5], 7, true),
            ([6, 7, 0, 1, 2, 4, 5], 0, true),
            ([6, 7, 0, 1, 2, 4, 5], 4, true),
            ([6, 7, 0, 1, 2, 4, 5], 5, true),

            // Duplicate-heavy cases — important for #81
            ([2, 2, 2, 0, 2, 2], 0, true),
            ([2, 2, 2, 0, 2, 2], 3, false),
            ([2, 2, 2, 2, 0, 2], 0, true),
            ([2, 2, 2, 2, 2, 2], 3, false),

            // Target at boundaries
            ([1, 1, 1, 2, 1], 2, true),
            ([1, 1, 1, 2, 1], 1, true),
            ([1, 1, 1, 2, 1], 3, false)
        ];

        int pass = 0, fail = 0;

        foreach (var (input, target, expected) in cases)
        {
            bool result = Approach_Three(input, target);
            string status = result == expected ? "PASS" : "FAIL";

            Console.WriteLine(
                $"[{status}] Input: [{string.Join(", ", input)}], Target: {target} => {result} (Expected: {expected})");

            if (result == expected)
                pass++;
            else
                fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
