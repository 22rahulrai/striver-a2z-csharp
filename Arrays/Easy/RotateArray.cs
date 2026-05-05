/*
 * Problem   : 189. Rotate Array
 * Link      : https://leetcode.com/problems/rotate-array/
 * Platform  : LeetCode
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-05-06
 *
 * Approach:
 *  1. Brute force
       — Place each element at (i + k) % n in a new array
 *  2. Reverse Method (Optimal)
 *      - Reverse entire array
 *      - Reverse first k elements
 *      - Reverse remaining n-k elements
 *
 * Complexity : Brute | Optimal 
 *      Time  : O(n)  | O(n) 
 *      Space : O(n)  | O(1)
 *
 * Notes / gotchas:
 *   - Always do k = k % n (important when k > n)
 */

public class RotateArray {
    public static void approach_one(int[] nums, int k) {
        int n = nums.Length;
        k = k % n;

        int[] temp = new int[n];
        for(int i =0; i<n; i++){
            temp[(i + k) % n] = nums[i];
        }
// i	nums[i]	   new index = (i+3)%7
// 0	     1	           3
// 1	     2	           4
// 2	     3	           5
// 3	     4	           6
// 4	     5	           0
// 5	     6	           1
// 6	     7	           2
        for(int i=0; i<n; i++){
            nums[i] = temp[i];
        }
    }

    public static void approach_two(int[] nums, int k) {
        int n = nums.Length;
        k = k % n;

        reverse(nums, 0, n - 1); // Step 1: Reverse the entire array
        reverse(nums, 0, k - 1); // Step 2: Reverse the first k elements
        reverse(nums, k, n - 1); // Step 3: Reverse the remaining        
    }

    public static void reverse(int[] arr, int start, int end){
        while(start<end){
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++;
            end--;
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
        (int[] input, int k, int []expected)[] cases =
        [
            (new int[]{1,2,3,4,5,6,7}, 3, new int[]{5,6,7,1,2,3,4}),
            (new int[]{-1,-100,3,99}, 2, new int[]{3,99,-1,-100}),
            (new int[]{1}, 0, new int[]{1}),
            (new int[]{1,2}, 3, new int[]{2,1}), // k > n case    
        ];

        int pass = 0, fail = 0;
        foreach (var (input, k, expected) in cases)
        {
            int[] arr = (int[])input.Clone(); 

            approach_two(arr, k); // test optimal

            bool isEqual = AreEqual(arr, expected);

            string status = isEqual ? "PASS" : "FAIL";

            Console.WriteLine($"[{status}] k={k} → [{string.Join(", ", arr)}] (expected [{string.Join(", ", expected)}])");

            if (isEqual) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
