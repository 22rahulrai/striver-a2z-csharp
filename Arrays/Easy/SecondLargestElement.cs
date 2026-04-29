/*
 * Problem   : Second Largest Element in an Array
 * Link      : https://www.geeksforgeeks.org/problems/second-largest3735/1
 * Platform  : GeeksforGeeks
 * Difficulty: Easy
 * Topic     : Arrays
 * Date      : 2026-04-29
 *
 * Approach:
 *   1. Brute force — sort the array and second largest is the second last unique element.
 *   2. 
 *
  * Complexity: APPROACH 1 Brute Force
 *   Time  : O(n log n) due to sorting
 *   Space : O(1)
 * Complexity: APPROACH 2 Optimal
 *   Time  : O(n)
 *   Space : O(1)
 *
 * Notes / gotchas:
 *   - Initialize result to int.MinValue to handle all-negative arrays.
 */

using System.ComponentModel;

public class SecondLargestElement {
    //Brute force approach 
    public static int approach_one(int[] arr) 
    {
        int n = arr.Length;
        if(n < 2) return -1; // Not enough elements for second largest

        Array.Sort(arr);
        int largest = arr[n-1];

        for (int i = n-2 ; i>=0; i--)
        {
            if(arr[i]!= largest)
            {
                return arr[i];
            }
        }
        return -1;
    }


    public static int approach_two(int[] arr) {
        // int largest  = -1;
        // int second_largest = -1;

        //If input changes (e.g., includes 0 or negative numbers) 
        int largest  = int.MinValue;
        int second_largest = int.MinValue;

        
        foreach(int n in arr){
            if(n>largest){
                second_largest = largest;
                largest = n;
            }
            else if(n<largest && n>second_largest){
                second_largest = n;
            }
        }
        
        return second_largest == int.MinValue ? -1 : second_largest;
    }


    public static void Test()
    {
        //tuple array
        (int[] input, int expected)[] cases =
        [
            ([12, 35, 1, 10, 34, 1], 34),   
            ( [10, 5, 10], 5),
            ([10, 10, 10], -1),   
            ([7], -1),   
            ([-5, -2, -8], -5),   
        ];

        int pass = 0, fail = 0;
        foreach (var (input, expected) in cases)
        {
            int result = approach_two(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] Input: [{string.Join(", ", input)}] => {result} (expected {expected})");
            if (result == expected) pass++; else fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }
}
