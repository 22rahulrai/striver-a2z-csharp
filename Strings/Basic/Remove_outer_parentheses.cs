/*
 * Problem: 1021. Remove Outermost Parentheses
 * Link: https://leetcode.com/problems/remove-outermost-parentheses/
 * Platform: LeetCode
 * Difficulty: Easy
 * Topic: String, Stack
 * Date: 2026-09-01
 *
 * A valid parentheses string splits uniquely into primitive pieces -
 * a primitive is non-empty and cannot be split further.
 * Task: drop the outermost '(' and ')' of every primitive.
 *
 * Approach 1: Balance Counter + Substring
 * - Walk the string keeping a balance: +1 on '(', -1 on ')'.
 * - balance == 0 marks the end of a primitive.
 * - Append that primitive without its first and last character:
 *   s.Substring(start + 1, i - start - 1)
 * - Move start past the primitive and continue.
 *
 * Approach 2: Balance Counter, Single Pass
 * - Same balance, but decide per character instead of per primitive.
 * - On '(': append only if balance > 0 (before incrementing),
 *   so the opening paren of a primitive is skipped.
 * - On ')': decrement first, then append only if balance > 0,
 *   so the closing paren of a primitive is skipped.
 *
 * Complexity:
 * Approach 1: Time: O(n), Space: O(n)
 * Approach 2: Time: O(n), Space: O(n)
 *
 * Notes:
 * - n = length of s.
 * - Input is guaranteed to be a valid parentheses string,
 *   so balance never goes negative and ends at 0.
 * - Space is O(n) for the output; extra space beyond it is O(1).
 * - No stack needed - a single int counter is enough.
 * - StringBuilder avoids O(n^2) string concatenation.
 */

using System.Text;

public class Remove_outer_parentheses
{
    public static string Approach_One(String s)
    {
        StringBuilder ans = new StringBuilder();
        int start =0, balance =0;

        for(int i=0;i<s.Length;i++){
            if(s[i] == '('){
                balance++;
            }
            else{
                balance--;
            }

            if(balance == 0){
                ans.Append(s.Substring(start+1,i-start-1)); //remove first'(' and last')'
                start = i + 1;
            }
        }

        return ans.ToString();
    }

    public static string Approach_Two(string s) {
        StringBuilder ans = new StringBuilder();
        int  balance =0;

        for(int i=0;i<s.Length;i++){
            if(s[i] == '('){
                if(balance > 0){
                    ans.Append(s[i]);
                }
                balance++;
            }
            else{
                balance--;
                if(balance >0){
                    ans.Append(s[i]);
                }
            }
        }
        return ans.ToString();
    }

    public static string Apporach_Three(string s)
    {
        StringBuilder ans = new StringBuilder();
        Stack<int> st = new Stack<int>();



        for(int i=0;i<s.Length;i++){
            if(s[i] == '('){
                
            }
            else{
                balance--;
                if(balance >0){
                    ans.Append(s[i]);
                }
            }
        }
        return ans.ToString();
    }


    public static void Test()
    {
        (string input, string expected)[] cases =
        [
            ("(()())(())",         "()()()"),
            ("(()())(())(()(()))", "()()()()(())"),
            ("()()",               ""),
            ("()",                 ""),
            ("(((())))",           "((()))"),
            ("()(())",             "()"),
            ("((()))(())()",       "(())()")
        ];

        int pass = 0, fail = 0;

        foreach (var (input, expected) in cases)
        {
            string result = Approach_Two(input);

            string status = result == expected ? "PASS" : "FAIL";

            Console.WriteLine(
                $"[{status}] Input: \"{input}\" " +
                $"=> \"{result}\" (Expected: \"{expected}\")"
            );

            if (result == expected)
                pass++;
            else
                fail++;
        }

        Console.WriteLine($"\n{pass} passed, {fail} failed.");
    }

}
