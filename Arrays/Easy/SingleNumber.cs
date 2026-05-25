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
 *   2. 
 *
 * Complexity: APPROACH 1 (XOR)
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Complexity: APPROACH 2 (XOR)
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Notes / Gotchas:
 *   
 *   
 */

public class SingleNumber {
    public static int Approach_One(int[] nums) 
    {
        int res = 0;
        
        foreach(int n in nums){
            res = res ^ n;
        }
        return res;
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

        return 0;
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
            int result = Approach_Three(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
