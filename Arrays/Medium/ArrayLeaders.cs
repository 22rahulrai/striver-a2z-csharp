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
 * Time  : O(n^2)
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

public class ArrayLeaders {
    public static List<int> Approach_One(int[] arr){ //brute force
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

            List<int> result = Approach_two(input1);
