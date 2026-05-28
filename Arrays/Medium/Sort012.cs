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
 *   3. Two Pointers
 *      - This approach is useful conceptually but NOT ideal because:
        - We need original indices
        - After sorting, indices change.
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
 *          Time  : O(nlogn) due to sorting
 *          Space : O(1)
 *
    Notes / Gotchas:
        - Exactly one valid answer exists
        - Cannot use same element twice
        - Dictionary approach is optimal
        - Sorting changes original indices
 */


public class Sort012 {
    //Brute force approach 
    public static int[] approach_one(int[] nums, int target) 
    {
        int n= nums.Length;
        int x = 0, y = 0;

        foreach(int j in nums)
        {
            if(nums[j] == 0)
            {
                x++;
            }
            else if(nums[j] == 1)
            {
                y++;
            }
        }

        int i ;

        for(i=0;i<x;i++)
        {
            nums[i] = 0;
        }

        for(i=x;i<x+y;i++)
        {
            nums[i] = 1;
        }

        for(i=x+y;i<n;i++)
        {
            nums[i] = 2;
        }

        return new int[]{};
    }


    public static int[] approach_two(int[] nums,int target) {
        int n = nums.Length;

        Dictionary<int,int> map = new Dictionary<int, int>();

        for(int i = 0; i < n; i++){
            int find = target - nums[i];




    }

    public static int[] approach_three(int[] nums,int target)
    {
        int n = nums.Length;

        Array.Sort(nums);

        int left = 0, right = n - 1;

        while(left < right)
        {
            int sum = nums[left] + nums[right];

            if(sum == target)
            {
                return new int[]{left,right};
            }
            else if(sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return new int[]{};
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
        (int[] input, int target,int []expected)[] cases =
        [
            (new int[]{2,7,11,15}, 9, new int[]{0,1}),
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
