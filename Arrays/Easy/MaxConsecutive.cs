/*
 * Problem   : Single Number
 * Link      : https://leetcode.com/problems/single-number/description/
 * Platform  : GeeksforGeeks
 * Difficulty: Easy
 * Topic     : Arrays, Bit Manipulation
 * Date      : 2026-05-25
 *
 * Problem Statement:
 *   Given a non-empty array of integers nums, 
 *   every element appears twice except for one. Find that single one.
 *   
 * Approaches:
 *   1. XOR Method
 *   2. HashMap / Dictionary
 *   3. HashSet
 *   4. LINQ GroupBy
 *
 * Complexity: APPROACH 1 (XOR) -- optimal
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Complexity: APPROACH 2 (HashMap / Dictionary)
 *   Time  : O(n)
 *   Space : O(n)
 *
 * Complexity: APPROACH 3 (Hashset)
 *   Time  : O(n)
 *   Space : O(n)
 *
 * Complexity: APPROACH 4 (LINQ)
 *   Time  : O(n)
 *   Space : O(n)
 * Notes / Gotchas:
 *   
 *   
 */

public class MaxConsecutive {
    public static int Approach_One(int[] nums) 
    {
        int n = nums.Length;
        int max = 0;
        for(int i = 0; i < n; i++)
        {
            int c = 0;
            for(int j = i; j < n; j++)
            {
                if(nums[j] == 1)
                    c++;
                else
                    break;
            }
            max = Math.Max(max, c);
        }
    }

    public static int Approach_Two(int[] nums)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        foreach(int n in nums) {
            if(freq.ContainsKey(n))
                freq[n]++;
            else
                freq[n] = 1;
        }

        foreach(var item in freq) {
            if(item.Value == 1)
                return item.Key;
        }

        return -1;
    }

    public static int Approach_Three(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach(int n in nums)
        {
            if (set.Contains(n)) // remove if already exists, else add to set
                set.Remove(n);
            else
                set.Add(n);
        }

        foreach(int n in nums) {
            if(set.Contains(n))
                return n;
        }

        return -1;
    }

    public static int Approach_Four(int[] nums)
    {
        return nums
        .GroupBy(x => x)
        .First(g => g.Count() == 1)
        .Key;
    }

    public static void Test()
    {
        //tuple array
        (int[] input, int expected)[] cases =
        [
            ([2,2,1], 1),   
            ([4,1,2,1,2],4),
            ([3], 3),
            ([8, 8, 7, 7, 6, 6, 1], 1),
        ];

        int pass = 0, fail = 0;
        foreach (var (input,expected) in cases)
        {
            int result = Approach_Four(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
