/*
 * Problem   : 875. Koko Eating Bananas
 * Link      : https://leetcode.com/problems/koko-eating-bananas/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Array, Binary Search
 * Date      : 2026-08-18
 *
 * Approach 1: Brute Force
 *   - Try every possible eating speed from 1 to the largest pile.
 *   - For each speed, calculate the total hours needed to eat all
 *     the bananas.
 *   - If Koko can finish within h hours, return that speed.
 *   - This gives the minimum valid eating speed.
 *
 * Approach 2: Binary Search
 *   - The possible eating speed ranges from 1 to the largest pile.
 *   - Use binary search to find the minimum speed that allows Koko
 *     to finish all bananas within h hours.
 *   - If the current speed works, search for a smaller speed.
 *   - Otherwise, search for a larger speed.
 *
 * Complexity:
 *
 *   Approach 1:
 *     Time  : O(n * m)
 *     Space : O(1)
 *
 *   Approach 2:
 *     Time  : O(n log m)
 *     Space : O(1)
 *
 * Notes:
 *   - n = number of banana piles.
 *   - m = maximum number of bananas in a pile.
 *   - The array does not need to be sorted.
 *   - Hours for a pile can be calculated using ceiling division:
 *       (pile + speed - 1) / speed
 *   - Use long for the total hours to avoid integer overflow.
 */

public class Koko_Banana
{
    public static int Approach_One(int[] nums, int h)
    {
        int n = nums.Max();

        for(int i = 1; i<=n;i++){
            int hr = 0;

            foreach(int num in nums){
                hr = hr + (num+i-1)/i;
            }

            if(hr<=h){
                return i;
            }
        }

        return n;
    }

    public static int Approach_Two(int[] arr, int target) //binary search
    {
        int c = 0;
        
        foreach(int n in arr){
            if(n < target){
                continue;
            }
            if(n == target){
                c++;
            }
            else{
                break;
            }
        }
        return c;
    }
    public static int FindFirst(int[] nums,int target){
        int s = 0;
        int l = nums.Length-1;

        int first = -1;
        while(s<=l){
            int mid = s + (l -s)/2;

            if(nums[mid]==target){
                first = mid;
                l=mid -1;
            }
            else if(nums[mid]>target){
                l = mid -1;
            }
            else{
                s =mid+1;
            }
        }

        return first;
    }

    public static int FindLast(int[] nums,int target){
        int s = 0;
        int l = nums.Length-1;

        int last  = -1;
    
        while(s <= l){
            int mid = s + (l -s)/2;

            if(nums[mid]==target){
                last = mid;
                s = mid + 1;
            }
            else if(nums[mid] > target){
                l = mid - 1;
            }
            else{
                s = mid + 1;
            }
        }

        return last;
    }

    public static void Test()
    {
        (int[] input, int target, int expected)[] cases =
        [
            (new int[] {1, 1, 2, 2, 2, 2, 3}, 2, 4),
            (new int[] {1, 1, 1, 1, 1, 2, 3}, 1, 5),
            (new int[] {1, 2, 2, 2, 3, 4}, 2, 3),
            (new int[] {1, 2, 3, 4, 5, 5, 5}, 5, 3),
            (new int[] {8, 9, 10, 12, 12, 12}, 12, 3)
        ];

        int pass = 0, fail = 0;

        foreach (var (input, target, expected) in cases)
        {
            int result = Approach_One(input, target);

            string status = result == expected  ? "PASS" : "FAIL";

            Console.WriteLine(
                $"[{status}] Input: [{string.Join(", ", input)}], Target: {target} => [{string.Join(", ", result)}] (Expected: [{string.Join(", ", expected)}])");

            if (result == expected)
                pass++;
            else
                fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
