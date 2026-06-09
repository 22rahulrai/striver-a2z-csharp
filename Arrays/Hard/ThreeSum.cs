/*
 * Problem   : 3Sum
 * Link      : https://leetcode.com/problems/3sum/
 * Platform  : LeetCode
 * Difficulty: Hard
 * Topic     : Arrays
 * Date      : 2026-06-09
 *
 * Approach:
 *  1. Brute force
       — Iterate through the array and for each element, check if it is greater than all the elements to its right.
       — If it is, add it to the list of leaders.
 *  2. Optimal Approach
       — Traverse the array from right to left, keeping track of the maximum element seen so far.
       — If the current element is greater than the maximum, it is a leader. Add it to the list and update the maximum.
       — Reverse the list of leaders before returning to maintain the original order.

 *
 * Complexity 
 *
 * Brute Force
 * Time  : O(n^3)
 * Space : O(1)
 *
 * Optimal
 * Time  : O(n)
 * Space : O(1) 
 *
 * Notes / Gotchas:
 *   - The rightmost element is always a leader.
 *   - Leaders are not necessarily unique; there can be multiple leaders in the array.
 */

public class ThreeSum {
    public static IList<IList<int>> Approach_One(int[] arr){ //brute force
        int n = arr.Length;
        
        var res = new List<IList<int>>();
        
        for(int i = 0; i < n; i++){
            for(int j = i+1; j < n; j++){
                for(int k = j + 1; k < n; k++)
                {
                    if(arr[i] + arr[j] + arr[k] == 0)
                    {
                        List<int> temp = new List<int>(){arr[i], arr[j], arr[k]};
                        temp.Sort();

                        if(!res.Any(x => x.SequenceEqual(temp)))
                            res.Add(temp);
                    }
                }
            }
        }
        
        return res;
    }

    public static List<int> Approach_two(int[] arr) 
    {

        int n = arr.Length;

        if (arr == null || n == 0)
            return new List<int>();
        
        List<int> res= new List<int>();
        res.Add(arr[n-1]);
        int max = arr[n-1];

        for(int i = n-2; i >= 0; i--)
        {
            if (arr[i] > max)
            {
                res.Add(arr[i]);
                max = arr[i];
            }
        }

        res.Reverse();

        return res;
    }
    
    public static bool AreEqual(List<int> a, int[] b)
    {
        if (a.Count != b.Length)
            return false;

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        return true;
    }

    public static void Test()
    {
        (int[] input1, List<IList<int>> input2)[] cases =
        [
            ([-1,0,1,2,-1,-4], [[-1,-1,2],[-1,0,1]]),
            ([0,1,1], []),
            ([0,0,0], [[0,0,0]]),
            ([-1,0,1,0], [[-1,0,1],[-1,1,0]]),
        ];

        int pass = 0, fail = 0;
        foreach (var (input1,  expected) in cases)
        {

            IList<IList<int>> result = Approach_One(input1);

            bool isEqual = AreEqual(result, expected);

            string status = isEqual ? "PASS" : "FAIL";

            Console.WriteLine($"[{status}] Result = [{string.Join(", ", result)}] " + $"Expected = [{string.Join(", ", expected)}]");

            if (isEqual) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
