/*
 * Problem   : Union of two sorted arrays
 * Link      : https://www.geeksforgeeks.org/problems/union-of-two-sorted-arrays
 * Platform  : geeksforgeeks
 * Difficulty: Medium
 * Topic     : Arrays
 * Date      : 2026-05-24
 *
 * Approach:
 *  1. Brute force
       — Use a list to store unique elements from both arrays
       — Check for duplicates before adding to the list
 *  2. HashSet
       — Use a HashSet to store unique elements from both arrays
       — Convert the HashSet to a list and sort it before returning
    3. Two pointers (Optimal)
       — Use two pointers to traverse both sorted arrays simultaneously
       — Add unique elements to the result list while traversing
       — Handle duplicates by skipping over them in both arrays
 *
 * Complexity 
 *
 * Brute Force
 * Time  : O((n+m)^2)
 * Space : O(n+m)
 *
 * HashSet
 * Time  : O((n+m) log(n+m))
 * Space : O(n+m)
 *
 * Two Pointer (Optimal)
 * Time  : O(n+m)
 * Space : O(n+m) 
 *
 *
 */

public class UnionArrays {
    public static List<int> Approach_one(int[] a, int [] b){
        // Brute force 
        // TC : O((n+m)2) // Space : O(n+m)
        List<int> res = new List<int>();
        
        int n = a.Length;
        int m = b.Length;
        
        for(int i=0;i<n;i++){
            if(!res.Contains(a[i])){
                res.Add(a[i]);
            }
        }
        
        for(int i=0;i<m;i++){
            if(!res.Contains(b[i])){
                res.Add(b[i]);
            }
        }
        
        res.Sort();
        return res;
    }

    public static List<int> Approach_two(int[] a, int [] b) 
    {

        HashSet<int> set = new HashSet<int>();
        foreach(int num in a)
        {
            set.Add(num);
        }
        foreach(int num in b)
        {
            set.Add(num);
        }

        List<int> res = set.ToList();
        res.Sort();

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
        (int[] input1, int[] input2, int []expected)[] cases =
        [
            (new int[]{1, 2, 3, 4, 5}, new int[]{1, 2, 7}, new int[]{1, 2, 3, 4, 5, 7}),
            (new int[]{3, 4, 6, 7, 9, 9}, new int[]{1, 5, 7, 8, 8}, new int[]{1, 3, 4, 5, 6, 7, 8, 9}),
            (new int[]{2, 2, 3, 4, 5}, new int[]{1, 1, 2, 3, 4}, new int[]{1, 2, 3, 4, 5}),
            (new int[]{1, 1, 1, 1, 1}, new int[]{2, 2, 2, 2, 2}, new int[]{1,2})
        ];

        int pass = 0, fail = 0;
        foreach (var (input1, input2, expected) in cases)
        {

            List<int> result = Approach_two(input1, input2);

            bool isEqual = AreEqual(result, expected);

            string status = isEqual ? "PASS" : "FAIL";

            Console.WriteLine($"[{status}] Result = [{string.Join(", ", result)}] " + $"Expected = [{string.Join(", ", expected)}]");

            if (isEqual) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
