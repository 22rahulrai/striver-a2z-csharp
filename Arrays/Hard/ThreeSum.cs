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
 * Time  : O(nÂ²)
 * Space : O(n)
 *
 * Optimal Two Pointer
 * Time  : O(nÂ²)
 * Space : O(1)
 *
 * Notes / Gotchas:
 *   - Sorting enables duplicate removal efficiently.
 *   - Two Pointer approach is the standard interview solution.
 *   - LeetCode expects the O(nÂ²) solution.

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

        var res = new List<IList<int>>();
        // HashSet<string> unique = new(); // support only .Net 9 or later
        HashSet<string> unique = new HashSet<string>();
        
        for(int i = 0; i < n; i++){
            HashSet<int> seen = new HashSet<int>();
            for(int j = i+1; j < n; j++)
            {
                int third = -(arr[i] + arr[j]);
                if (seen.Contains(third))
                {
                    int[] triplet = new int[] { arr[i], arr[j], third};

                    Array.Sort(triplet);
                    string key = $"{triplet[0]},{triplet[1]},{triplet[2]}";

                    if(unique.Add(key)) // returns false if key already exists
                    {
                        res.Add(new List<int>(triplet));
                    }
                    
                }
                seen.Add(arr[j]);
            }
        }
        return res;
    }
    
    public static IList<IList<int>> Approach_Three(int[] arr) // optimal two pointer
    {
        int n = arr.Length;
        Array.Sort(arr);
        var res = new List<IList<int>>();

        for (int i = 0; i < n - 2; i++)
        {
            if (i > 0 && arr[i] == arr[i - 1]) continue;
            if (arr[i] > 0) break;

            int lo = i + 1, hi = n - 1;
            while (lo < hi)
            {
                int sum = arr[i] + arr[lo] + arr[hi];
                if (sum == 0)
                {
                    res.Add(new List<int> { arr[i], arr[lo], arr[hi] });
                    while (lo < hi && arr[lo] == arr[lo + 1]) lo++;
                    while (lo < hi && arr[hi] == arr[hi - 1]) hi--;
                    lo++; hi--;
                }
                else if (sum < 0) lo++;
                else hi--;
            }
        }
        return res;
    }

    public static bool AreEqual(IList<IList<int>> a, IList<IList<int>> b)
    {
        if (a.Count != b.Count)
            return false;

        static string Key(IList<int> t) => string.Join(",", t.OrderBy(x => x));
        var sa = a.Select(Key).OrderBy(x => x).ToList();
