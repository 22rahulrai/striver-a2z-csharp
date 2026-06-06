/*
 * Problem   : 2149. Rearrange Array Elements by Sign
 * Link      : https://leetcode.com/problems/rearrange-array-elements-by-sign/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Arrays, Two Pointers
 * Date      : 2026-06-06
 *
 * Approaches:
 *
 *   1. Separate Positive & Negative Arrays
 *      - Store positive and negative numbers separately.
 *      - Rebuild the array by alternating elements.
 *
 *   2. Direct Placement (Optimal)
 *      - Create answer array.
 *      - Place positives at even indices.
 *      - Place negatives at odd indices.
 *
 *   3. LINQ Approach
 *      - Extract positive and negative numbers using Where().
 *      - Merge them alternately.
 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n)
 *          Space : O(n)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(n)
 *
 *      Approach 3:
 *          Time  : O(n)
 *          Space : O(n)
 *
 * Notes / Gotchas:
 *   - Relative order must be preserved.
 *      - Result must start with a positive number.
 *      - Number of positive and negative elements is equal.
 */

using System.ComponentModel;

public class RearrangeArrayElementsBySign {
    public static int[] Approach_One(int[] nums) 
    {
        int n = nums.Length;

        int [] pos = new int[n/2];
        int [] neg = new int[n/2];

        int i =0, j=0;
        foreach(int arr in nums){
            if(arr > 0){
                pos[i++] = arr;
            }
            else{
                neg[j++] = arr;
            }
        }
        i = 0;
        j = 0;
        for(int k=0;k<n;k++){
            if(k % 2 == 0)
                nums[k] = pos[i++];
            else
                nums[k] = neg[j++];
            
        }
        return nums;
    }


    public static int[] Approach_Two(int[] nums) {
        int n = nums.Length;

        int []ans = new int[n];

        int pos =0, neg=1;
        foreach(int arr in nums){
            if(arr > 0){
                ans[pos] = arr;
                pos +=2;
            }
            else{
                ans[neg] = arr;
                neg +=2;
            }
        }
        return ans;
    }

    public static int[] Approach_Three(int[] nums) {
        int[] pos = nums.Where(x => x > 0).ToArray();
        int[] neg = nums.Where(x => x < 0).ToArray();

        int p = 0, n = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(i % 2 == 0)
                nums[i] = pos[p++];
            else
                nums[i] = neg[n++];
        }
        return nums; 
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
            ([3,1,-2,-5,2,-4], [3,-2,1,-5,2,-4]),
            ([-1,1], [1,-1]),
            ([1,2,-3,-4], [1,-3,2,-4]),
            ([-5,-2,5,2], [5,-5,2,-2]),
            ([1,-1,1,-1], [1,-1,1,-1])
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int [] result = Approach_Three(input); 

            bool isEqual = AreEqual(result, expected);

            string status = isEqual ? "PASS" : "FAIL";

            Console.WriteLine($"[{status}] → [{string.Join(", ", result)}] (expected [{string.Join(", ", expected)}])");

            if (isEqual) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
