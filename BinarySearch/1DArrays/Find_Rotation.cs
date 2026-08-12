/*
 * Problem   : Find Kth Rotation
 * Link      : https://www.geeksforgeeks.org/problems/rotation4723/1
 * Platform  : GeeksForGeeks
 * Difficulty: Easy
 * Topic     : Array, Binary Search
 * Date      : 2026-08-12
 *
 * Problem:
 * Given a sorted and rotated array, find the number of times
 * the array has been rotated.
 *
 * The number of rotations is equal to the index of the
 * minimum element in the array.
 *
 *
 * Approaches:
 *
 * 1. Find Minimum Element - Linear Search
 *
 * - Traverse the complete array.
 * - Find the minimum element.
 * - The index of the minimum element represents the number
 *   of rotations.
 *
 * Example:
 *
 *   [4, 5, 1, 2, 3]
 *
 *   Minimum element = 1
 *   Index = 2
 *
 *   Therefore, the array was rotated 2 times.
 *
 * Time  : O(n)
 * Space : O(1)
 *
 *
 * 2. Find Rotation Point - Linear Search
 *
 * - In a sorted and rotated array, the rotation point is
 *   where nums[i] > nums[i + 1].
 * - The element after this point is the minimum element.
 * - Therefore, return i + 1.
 * - If no such point exists, the array is not rotated,
 *   so return 0.
 *
 * Example:
 *
 *   [4, 5, 1, 2, 3]
 *
 *   5 > 1
 *
 *   Rotation point = 1
 *   Minimum element index = 2
 *
 * Time  : O(n)
 * Space : O(1)
 *
 *
 * 3. Binary Search
 *
 * - The array consists of two sorted parts.
 * - Compare nums[mid] with nums[end].
 * - If nums[mid] > nums[end], the minimum element must
 *   be on the right side.
 * - Otherwise, the minimum element is at mid or on the
 *   left side.
 * - Continue until start == end.
 * - The final index is the index of the minimum element,
 *   which is the number of rotations.
 *
 * Time  : O(log n)
 * Space : O(1)
 *
 *
 * Notes:
 *
 * - The array is sorted and rotated.
 * - All elements are distinct.
 * - The number of rotations is equal to the index of the
 *   minimum element.
 * - A completely sorted array has 0 rotations.
 * - The optimal approach is Binary Search.
 */


public class Find_Rotation
{
    public static int Approach_One(int[] nums)
    {
        int min = nums[0];
        int minIndex = 0;

        for(int i = 0; i < nums.Length-1; i++)
        {
            if (nums[i] < min)
            {
                min = nums[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static int Approach_Two(int[] nums) 
    {
        for(int i = 0; i < nums.Length-1; i++)
        {
            if(nums[i]>nums[i+1])
                return i + 1;
        }
        return 0;

        
        
    }

    public static int Approach_Three(int[] nums) 
    {
        int s = 0;
        int e = nums.Length -1;

        while(s < e)
        {
            int mid = s + (e-s)/2;

            if(nums[mid] > nums[e])
                s =  mid + 1;
            else
                e = mid;
        }
        return s;
    }

    public static void Test()
    {
        (int[] input, int expected)[] cases =
        [
            ([1, 1, 2, 3, 3, 4, 4, 8, 8], 2),
            ([3, 3, 7, 7, 10, 11, 11], 10),
            ([1], 1),
            ([1, 1, 2], 2),
            ([1, 2, 2], 1),
            ([1, 1, 2, 2, 3], 3),
            ([1, 1, 2, 2, 3, 3, 4], 4),
            ([1, 1, 2, 2, 3, 3, 4, 4, 5], 5),
            ([1, 1, 2, 2, 3, 4, 4, 5, 5], 3),
            ([1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 6], 4),
            ([1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6], 6)
        ];

        int pass = 0, fail = 0;

        foreach (var (input, expected) in cases)
        {
            int result = Approach_Five(input);

            string status = result == expected ? "PASS" : "FAIL";

            Console.WriteLine(
                $"[{status}] Input: [{string.Join(", ", input)}] " +
                $"=> {result} (Expected: {expected})"
            );
            if (result == expected)
                pass++;
            else
                fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
    
}
