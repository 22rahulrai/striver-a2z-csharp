/*
 * Problem   : 283. Move Zeroes
 * Link      : https://leetcode.com/problems/move-zeroes/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Arrays, Two Pointers
 * Date      : 2026-05-07
 *
 * Approaches:
 *
 *   1. Brute Force (Extra Array)
 *      - Store all non-zero elements in temp array
 *      - Copy temp back to original array
 *
 *   2. Overwrite Method (better)
 *      - Shift non-zero elements forward
 *      - Fill remaining positions with zeroes
 *
 *   3. Swap Method (Optimal Two Pointers)
 *      - Maintain pointer for next non-zero position
 *      - Swap current non-zero element into correct place
 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n)
 *          Space : O(n)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(1)
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

public class MoveZeroes {
    //Brute force approach 
    public static void approach_one(int[] nums) 
    {
        int n = nums.Length;

        int []temp = new int[n];
        int index =0;
        foreach(int i in nums){
            if(i != 0){
                temp[index++] = i;
            }
                
        }

        for(int i=0;i<n;i++){
            nums[i] = temp[i];
        }
    }


    public static void approach_two(int[] nums) {
        int n = nums.Length;
        int s=0;

        for(int i=0;i<n;i++){
            if(nums[i]!=0){
                nums[s++] = nums[i];
            }
        }

        for(int i=s; i<n;i++){
            nums[i]=0;
        }
    }

    public static void approach_three(int[] nums) {
        int n = nums.Length;
        int s=0;

        for(int i=0;i<n;i++){
            if(nums[i]!=0){
                if(i != s) {
                    // int temp = nums[i];
                    // nums[i] = nums[s];
                    // nums[s] = temp;

                    // using tuple 
                    (nums[i],nums[s]) = (nums[s],nums[i]) ;
                }
                s++;
            }
        }
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
