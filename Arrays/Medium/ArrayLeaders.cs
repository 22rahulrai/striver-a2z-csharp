/*
 * Problem   : Array Leaders
 * Link      : https://www.geeksforgeeks.org/problems/leaders-in-an-array-1587115620
 * Platform  : geeksforgeeks
 * Difficulty: Medium
 * Topic     : Arrays
 * Date      : 2026-06-07
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

public class ArrayLeaders {
    public static List<int> Approach_One(int[] arr){
        int n = arr.Length;
        
        List<int> res= new List<int>();
        
        for(int i = 0; i < n; i++){
            bool isLeader = true;
            for(int j = i+1; j < n; j++){
                if(arr[i] < arr[j]){
                    isLeader = false;
                    break;
                }
            }
            if(isLeader)
                res.Add(arr[i]);
        }
        
        return res;
    }

    public static List<int> Approach_two(int[] arr) 
    {

        int n = arr.Length;
        
        List<int> res= new List<int>();
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

    public static List<int> Approach_three(int[] a, int [] b)
    {
        List<int> res = new List<int>();

        int n = a.Length;
        int m = b.Length;

        int i = 0, j = 0;

        while(i < n && j < m)
        {
            // Skip duplicates in a
            if(i > 0 && a[i] == a[i - 1])
            {
                i++;
                continue;
            }
            // skip duplicates in b
            if(j > 0 && b[j] == b[j - 1])
            {
                j++;
                continue;
            }

            if (a[i] < b[j])
            {
                res.Add(a[i++]);
            }
            else if(a[i] > b[j])
            {
                res.Add(b[j++]);
            }
            else
            {
                res.Add(a[i]);
                i++;
                j++;
            }
        }
        // Add remaining elements from a
        while(i < n)
        {
            if(i == 0 || a[i] != a[i-1])
            {
                res.Add(a[i]);
            }
            i++;
        }
        // Add remaining elements from a
        while(j < m)
        {
            if(j == 0 || b[j] != b[j-1])
            {
                res.Add(b[j]);
            }
            j++;
        }

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
        (int[] input1, int []expected)[] cases =
        [
            ([16, 17, 4, 3, 5, 2], [17, 5, 2]),
            ([1, 2, 3, 4, 0], [4, 0]),
            ([7, 10, 4, 10, 6, 5, 2], [10, 6, 5, 2]),
            ([1, 2, 3], [3]),
            ([1], [1])
        ];

        int pass = 0, fail = 0;
        foreach (var (input1,  expected) in cases)
        {

            List<int> result = Approach_One(input1);

            bool isEqual = AreEqual(result, expected);

            string status = isEqual ? "PASS" : "FAIL";

            Console.WriteLine($"[{status}] Result = [{string.Join(", ", result)}] " + $"Expected = [{string.Join(", ", expected)}]");

            if (isEqual) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
