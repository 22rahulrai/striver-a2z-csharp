/*
 * Problem   : 1. Two Sum
 * Link      : https://leetcode.com/problems/two-sum/description/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Arrays, Two Pointers
 * Date      : 2026-05-27
 *
 * Approaches:
 *
 *   1. Brute Force 
 *      - use to nested loops to check all pairs
 *
 *   2. Dictionary 
 *      We store numbers we have already seen in a dictionary.
        For every number:
        complement = target - current number
        Then check:
        Have we already seen this complement?

 *
 *   3. Swap Method (Optimal Two Pointers)
 *      - Maintain pointer for next non-zero position
 *      - Swap current non-zero element into correct place
 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n^2)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(n)
 *
 *      Approach 3:
 *          Time  : O(n)
 *          Space : O(1)
 *
 * Notes / Gotchas:
 *   - Problem requires in-place modification
 *   - Maintain relative order of non-zero elements
 *   - Overwrite method avoids unnecessary swaps
 *   - Tuple swapping used in C# for cleaner syntax
 */

using System.ComponentModel;

public class TwoSum {
    //Brute force approach 
    public static int[] approach_one(int[] nums, int target) 
    {
        int n= nums.Length;

        for(int i=0;i<n;i++){
            for(int j=i+1;j<n;j++){
                if(nums[i]+nums[j]==target){
                    return new int[]{i,j};
                }
            }
        }

        return new int[]{};
    }


    public static int[] approach_two(int[] nums,int target) {
        int n = nums.Length;

        Dictionary<int,int> map = new Dictionary<int, int>();

        for(int i = 0; i < n; i++){
            int find = target - nums[i];
            if(map.ContainsKey(find)){
                return new int[]{map[find],i};
            }
            map[nums[i]] = i;
        }

        return new int[]{};
    }

    public static void approach_three(int[] nums)
    {
        
    }




    public static bool AreEqual(int[] a, int[] b) {
        if (a.Length != b.Length) return false;

        for(int i = 0; i < a.Length; i++){
            if(a[i] != b[i]) return false;
        }
        return true;
    }

    public static void Test()
    {
        (int[] input, int []expected)[] cases =
        [
            (new int[]{0,1,0,3,12},  new int[]{1,3,12,0,0}),
            (new int[]{1,0,1},  new int[]{1,1,0}),
            (new int[]{1 ,0 ,2 ,3 ,0 ,4 ,0 ,1}, new int[]{1 ,2 ,3 ,4 ,1 ,0 ,0 ,0}),
            (new int[]{1,2,0,1,0,4,0}, new int[]{1,2,1,4,0,0,0}),
            (new int[]{0},  new int[]{0}),
            (new int[]{2,1},  new int[]{2,1}),
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int[] arr = (int[])input.Clone(); 

            approach_two(arr); // test optimal

            bool isEqual = AreEqual(arr, expected);

            string status = isEqual ? "PASS" : "FAIL";

            Console.WriteLine($"[{status}] → [{string.Join(", ", arr)}] (expected [{string.Join(", ", expected)}])");

            if (isEqual) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
