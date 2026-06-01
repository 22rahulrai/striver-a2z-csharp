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

 *   3. Optimal Approach 
 *      - Use Boyer-Moore Voting Algorithm:
        - Initialize a candidate and count.
        - Iterate through the array:
            - If count is 0, set candidate to current element.
            - If current element is the candidate, increment count; otherwise, decrement count.
        - The candidate at the end will be the majority element.
 *
 * Complexity:
 *
 *      Approach 1:
 *          Time  : O(n^2)
 *          Space : O(1)
 *
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(n)
 *      Approach 2:
 *          Time  : O(n)
 *          Space : O(1)
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

    public static int Approach_Three(int[] nums) { //better approach using dictionary
        int n = nums.Length;
        int candidate = -1;
        int count = 0;

        foreach(int num in nums){
            if(count == 0)
            {
                candidate = num;
            }

            if(num == candidate)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return candidate;
    }



    


    public static void Test()
    {
        (int[] input, int expected)[] cases =
        [
            ([7, 0, 0, 1, 7, 7, 2, 7, 7],        7),   
            ([1, 1, 1, 2, 1, 2], 1),
            ([2,2,1,1,1,2,2],  2),   
            ([3,2,3],       3),   
            ([1, 1, 1],           1),   
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int result = Approach_Three(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
