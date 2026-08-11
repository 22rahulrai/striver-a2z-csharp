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


public class Single_Sorted_arr
{
    public static int Approach_One(int[] nums) //using Dictionary
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach(var n in nums)
        {
            if(map.ContainsKey(n))
                map[n]++;
            else
                map[n] = 1;
        }

        foreach(var pair in map)
        {
            if(pair.Value == 1)
            {
                return pair.Key;
            }
        }
        return -1;
    }

    public static int Approach_Two(int[] nums) //using Xor
    {
        int result = 0;

        foreach(var n in nums)
        {
            result ^= n;
        }

        return result; 
    }

    public static int Approach_Three(int[] nums) //using Linear Search
    {
        int i = 0;
        while( i < nums.Length - 1)
        {
            if(nums[i] != nums[i + 1])
            {
                return nums[i];
            }
        }

        return nums[nums.Length - 1];
    }

    public static int Approach_Four(int[] nums) //using Binary Search
    {
        int n = nums.Length;

        if(n == 1)
            return nums[0];

        if(nums[0] != nums[1])
            return nums[0];
        
        if(nums[n-1] != nums[n-2])
            return nums[n-1];
        
        int s = 0;
        int e = nums.Length - 2;

        while(s <= e)
        {
            int mid = s + (e-s)/2;

            if(nums[mid] != nums[mid-1] && nums[mid] != nums[mid+1])
                return nums[mid];

            if((mid % 2 == 0 && nums[mid] == nums[mid+1]) || (mid % 2 == 1 && nums[mid] == nums[mid - 1]))
            {
                s = mid + 1;
            }
            else
            {
                e = mid - 1;
            } 
        }

        return - 1;
    }

    public static int Approach_Five(int[] nums) //using Binary Search
    {
        int n = nums.Length;

        if(n == 1)
            return nums[0];

        if(nums[0] != nums[1])
            return nums[0];
        
        if(nums[n-1] != nums[n-2])
            return nums[n-1];
        
        int s = 0;
        int e = nums.Length - 2;

        while(s <= e)
        {
            int mid = s + (e-s)/2;
            // make mid even
            if (mid % 2 == 1)
            {
                mid --;
            }

            if(nums[mid] == nums[mid+1])
            {
                s = mid + 2;
            }
            else
            {
                e = mid;
            } 
        }

        return nums[s];
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
