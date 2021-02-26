using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.February.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/26/2021 5:27:31 PM
    /// @source : https://leetcode.com/explore/challenge/card/february-leetcoding-challenge-2021/587/week-4-february-22nd-february-28th/3653/
    /// @des : 
    /// </summary>
    public class Validate_Stack_Sequences
    {

        // 0 <= pushed.length == popped.length <= 1000
        //0 <= pushed[i], popped[i] < 1000
        //pushed is a permutation of popped.
        //pushed and popped have distinct values.

        // Your runtime beats 56.41 %
        // em.
        public bool Simple(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            int j = 0;
            for (int i = 0; i < pushed.Length; i++)
            {
                if (pushed[i] == popped[j])
                {
                    j++;
                    while (stack.Count > 0 && popped[j] == stack.Peek())
                    {
                        stack.Pop();
                        j++;
                    }
                }
                else
                {
                    stack.Push(pushed[i]);
                }
            }

            return stack.Count == 0;
        }

        private bool Help(int[] pushed, int[] popped, Stack<int> stack, int i, int j)
        {

            if(i == pushed.Length)
            {
                while(stack.Count > 0)
                {
                    if (stack.Pop() != popped[j++]) return false;
                }
            }

            if (stack.Count == 0)
            {
                stack.Push(pushed[i]);
                return Help(pushed, popped, stack, i + 1, j);
            }

            int peek = stack.Peek();

            if(peek == popped[j])
            {
                stack.Pop();
                return Help(pushed, popped, stack, i, j+1);
            }
            else
            {
                stack.Push(pushed[i]);
                return Help(pushed, popped, stack, i + 1, j);
            }

        }

    }
}
