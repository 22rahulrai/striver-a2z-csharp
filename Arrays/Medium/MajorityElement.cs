/*
 * Problem   : 169. Majority Element
 * Link      : https://leetcode.com/problems/majority-element/description/
 * Platform  : TUF
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-05-31
 *
* Approaches:
 *
 *   1. Brute Force 
 *      - For each element, count its occurrences in the array.
        - If the count exceeds n/2, return that element.
 *
 *   2. Better Approach using Dictionary
 *      - Use a dictionary to count occurrences of each element.
        - Iterate through the dictionary to find the element with count > n/2.

 *   3. Two Pointers
 *      - This approach is useful conceptually but NOT ideal because:
        - We need original indices
        - After sorting, indices change.
 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(n)
 *
    Notes / Gotchas:
 *      - Array contains only 0,1,2
 *      - Must sort in-place
 *      - Dutch National Flag is optimal
 */

public class MajorityElement {

    public static int Approach_One(int[] arr) {//brute force
        int n = arr.Length;

        for(int i = 0; i < n; i++)
        {
            int count =0;
            for(int j = 0; j < n; j++)
            {
                if (arr[i] == arr[j])
                {
                    count++;
                }
            }

            if(count > (n/2))
            {
                return arr[i];
            }
        }

        return -1;
    }

    public static int Approach_Two(int[] nums) { //better approach using dictionary
        Dictionary<int,int> map = new Dictionary<int,int>();

        foreach(int n in nums){
            if(map.ContainsKey(n)){
                map[n]++;
            }
            else{
                map[n] = 1;
            }
        }

        int target = nums.Length/2;

        foreach(var n in map){
            if(n.Value > target){
                return n.Key;
            }
        }

        return -1;
    }

    


    public static void Test()
    {
        (int[] input, int expected)[] cases =
        [
            ([3, 3, 6, 1],        6),   
            ([3, 3, 0, 99, -40], 99),
            ([-4, -3, 0, 1, -8],  1),   
            ([-5, -2, -8],       -2),   
            ([7],                 7),   
            ([1, 1, 1],           1),   
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int result = Approach_One(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
