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
 * Complexity : Brute      | Better 
 *      Time  : O((n+m)2)  | O((n + m) log(n + m))
 *      Space : O(n+m)     | O(n+m)
 *
 * Notes / gotchas:
 *   - Always do k = k % n (important when k > n)
 */

public class UnionArrays {
    public static List<int> approach_one(int[] a, int [] b){
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

    public static List<int> approach_two(int[] a, int [] b) 
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

    // public static List<int> approach_three(int[] a, int [] b)
    // {

    // }

    public static bool AreEqual(int[] a, int[] b) {
        if (a.Length != b.Length) return false;

        for(int i = 0; i < a.Length; i++){
            if(a[i] != b[i]) return false;
        }
        return true;
    }

    // public static void Test()
    // {
    //     (int[] input1, int[] input2, int []expected)[] cases =
    //     [
    //         (new int[]{1,2,3,4,5,6,7}, 3, new int[]{5,6,7,1,2,3,4}),
    //         (new int[]{-1,-100,3,99}, 2, new int[]{3,99,-1,-100}),
    //         (new int[]{1}, 0, new int[]{1}),
    //         (new int[]{1,2}, 3, new int[]{2,1}), // k > n case    
    //     ];

    //     int pass = 0, fail = 0;
    //     foreach (var (input1, k, expected) in cases)
    //     {
    //         int[] arr = (int[])input.Clone(); 

    //         approach_two(arr, k); // test optimal

    //         bool isEqual = AreEqual(arr, expected);

    //         string status = isEqual ? "PASS" : "FAIL";

    //         Console.WriteLine($"[{status}] k={k} → [{string.Join(", ", arr)}] (expected [{string.Join(", ", expected)}])");

    //         if (isEqual) pass++; else fail++;
    //     }

    //     Console.WriteLine($"\n{pass} passed, {fail} failed.");
    // }
}
