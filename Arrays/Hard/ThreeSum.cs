/*
 * Problem   : 3Sum
 * Link      : https://leetcode.com/problems/3sum/
 * Platform  : LeetCode
 * Difficulty: Medium
 * Topic     : Arrays, Two Pointers, Sorting
 * Date      : 2026-06-09
 *
 * Approach:
 * 1. Brute Force
 *    - Generate all possible triplets using three nested loops.
 *    - Check if their sum equals zero.
 *    - Sort each triplet and avoid duplicates.
 * 2. HashSet Based
 *    - Fix one element.
 *    - Use HashSet to solve the remaining 2-Sum problem.
 *    - Store sorted triplets in a set to remove duplicates.
 *
 * 3. Optimal Two Pointer
 *    - Sort the array.
 *    - Fix one element and use two pointers.
 *    - Skip duplicates while traversing.
 *
 *
 * Complexity 
 *
 * Brute Force
 * Time  : O(n^3)
 * Space : O(1)
 *
 * HashSet
 * Time  : O(n²)
 * Space : O(n)
 *
 * Optimal Two Pointer
 * Time  : O(n²)
 * Space : O(1)
 *
 * Notes / Gotchas:
 *   - Sorting enables duplicate removal efficiently.
 *   - Two Pointer approach is the standard interview solution.
 *   - LeetCode expects the O(n²) solution.

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

    public static IList<IList<int>> Approach_Two(int[] arr) 
    {
        int n = arr.Length;
        // HashSet<string> unique = new(); // support only .Net 9 or later
        HashSet<string> unique = new HashSet<string>();
        
        for(int i = 0; i < n; i++){
            HashSet<int> seen = new HashSet<int>();
            for(int j = i+1; j < n; j++)
            {
                int third = -(arr[i] + arr[j]);
                if (seen.Contains(third))
                {
                    
                }
                seen.Add(arr[j]);
            }
        }
        
        return res;

    }
    
    public static bool AreEqual(IList<IList<int>> a, IList<IList<int>> b)
    {
        if (a.Count != b.Count)
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
        (int[] input1, List<IList<int>> expected)[] cases =
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
