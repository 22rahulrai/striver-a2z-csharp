/*
 * Problem   : 75. Sort Colors
 * Link      : https://leetcode.com/problems/sort-colors/description/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Arrays, Two Pointers
 * Date      : 2026-05-28
 *
 * Approaches:
 *
 *   1. Brute Force 
 *      - Count the number of 0s, 1s, and 2s in the array.
        - Then overwrite the original array with the counted numbers in order.
 *
 *   2. Dutch National Flag Algorithm
 *      - Use 3 pointers:
 *          low  -> next position of 0
 *          mid  -> current element
 *          high -> next position of 2

 *
 *   3. Two Pointers
 *      - This approach is useful conceptually but NOT ideal because:
        - We need original indices
        - After sorting, indices change.
 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(n)
 *
    Notes / Gotchas:
 *      - Array contains only 0,1,2
 *      - Must sort in-place
 *      - Dutch National Flag is optimal
 */


public class Sort012 {
    public static int[] approach_one(int[] nums) 
    {
        int n = nums.Length;

        int zero = 0;
        int one = 0;

        foreach(int num in nums)
        {
            if(num == 0)
                zero++;

            else if(num == 1)
                one++;
        }

        int i ;

            // Fill 0s
        for(i = 0; i < zero; i++)
        {
            nums[i] = 0;
        }

        // Fill 1s
        for(i = zero; i < zero + one; i++)
        {
            nums[i] = 1;
        }

        // Fill 2s
        for(i = zero + one; i < n; i++)
        {
            nums[i] = 2;
        }

        return nums;
    }


    public static int[] approach_two(int[] nums) {
        int n = nums.Length;

        int low=0,mid =0, high=n-1;

        while(mid <= high){
            if(nums[mid] == 0){
                // int temp = nums[low];
                // nums[low] = nums[mid];
                // nums[mid] = temp;
                (nums[low],nums[mid]) = (nums[mid],nums[low]);  
                low++;
                mid++;
            }

            else if(nums[mid] == 2){
                // int temp = nums[high];
                // nums[high] = nums[mid];
                // nums[mid] = temp;
                (nums[high],nums[mid]) = (nums[mid],nums[high]);
                high--;
            }
            else{
                mid++;
            }
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
            (new int[]{2,7,11,15}, new int[]{0,1}),
            (new int[]{3,2,4}, 6, new int[]{1,2}),
            (new int[]{3,3}, 6, new int[]{0,1}),
            (new int[]{1,5,3,7}, 8, new int[]{1,2}),
            (new int[]{10,20,35,40}, 75, new int[]{2,3})
        ];

        int pass = 0, fail = 0;
        foreach (var (input, target,expected) in cases)
        {

            int []result = approach_two(input,target); // test optimal

            bool isEqual = AreEqual(result, expected);

            string status = isEqual ? "PASS" : "FAIL";

            Console.WriteLine($"[{status}] → [{string.Join(", ", result)}] (expected [{string.Join(", ", expected)}])");

            if (isEqual) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
