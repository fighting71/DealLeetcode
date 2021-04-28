using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/27/2021 5:27:59 PM
    /// @source : https://leetcode.com/problems/smallest-rotation-with-highest-score/
    /// @des : 
    /// </summary>
    [Obsolete("no thingk & slow simple")]
    [Serie(FlagConst.Complex, FlagConst.Special, "似懂非懂，值得深究")]
    public class Smallest_Rotation_with_Highest_Score
    {

        // A will have length at most 20000.
        // A[i] will be in the range[0, A.length].

        // source: https://leetcode.com/problems/smallest-rotation-with-highest-score/discuss/118725/C%2B%2BJavaPython-Solution-with-Explanation
        public int OtherSolution(int[] A)
        {

            /*
             * 参考说明：
             * Very brilliant solution!
很出色的解决方案!
It takes me quite a while to understand.
我花了很长时间才明白。
Here is my understanding in detail:
以下是我的具体理解:
For one step move left, we can figure out how points change with respect to the last position.
向左移动一步，我们可以算出点相对于最后一个位置的变化。
For each element, it must satisfy one of the three cases when moving from position i to position (i - 1 + N) % N:
对于每个元素，当从位置i移动到位置(i - 1 + N) % N时，它必须满足以下三种情况之一:
No point get and no point lose, this happens when A[i] &gt;
当A[i] &gt;
i;
我;
One point get, this happens when it moves from 0 to N - 1;
当它从0移动到N - 1时;
One point lost, this happens when A[i] == i and moves to i - 1.
当A[i] == i并移动到i - 1时，就会失去一个点。
change[k] actually records all the lost points after k steps moving left, by calculating how many elements would lose point at k.
Change [k]通过计算在k点丢失的元素数量，实际上记录了左移k步后丢失的所有点数。
The relationship of turning point k and initial position of element i is: k = (i - A[i] + 1 + N) % N.
转折点k与元素i初始位置的关系为:k = (i - A[i] + 1 + N) % N。
So by looping i, we can calculate the vector of change[k].
所以通过循环i，我们可以计算变化向量[k]。
The second for loop actually calculate total changes in k step moving left via k - 1, so you could think of
第二个for循环实际上是计算从k - 1向左移动k步的总变化量，你可以这样想
totalChange[k] = totalChange[k - 1] + change[k] + 1, as an equivalent as change[k] += change[k - 1] + 1.
totalChange[k] = totalChange[k - 1] + change[k] + 1，等价于change[k] += change[k - 1] + 1。
The above applies well when 0 &lt;
以上适用于0 &lt;
A[i] &lt;
[我]& lt;
A.length, but what if A[i] = 0 or A[i] = A.length()?
但是如果A[i] = 0或者A[i] = A.length()呢?
Their turning point k = (i - 0(or N) + 1 + N) % N = i + 1 is not real, because they never lose point! 
他们的转折点k = (i - 0(或N) + 1 + N) % N = i + 1是不真实的，因为他们永远不会失去点!
(0 always counts one point, and N never).
(0总是算一分，N从不算)。
However, assume that 0(or N) is at position i in original array, and it needs i steps to move to position 0.
但是，假设0(或N)在原始数组的位置i，需要i步才能移动到位置0。
So when it arrives at the turning point i + 1, it is actually moving from 0 to A.length - 1,
所以当它到达转折点i + 1时，它实际上是从0移动到a，长度是- 1，
which means we simultaneously subtract 1(in change[k]) and add 1 for totalChange[k].
这意味着我们同时减去1(在change[k]中)，并为totalChange[k]加1。
             */

            int n = A.Length;

            int[] change = new int[n];
            for (int i = 0; i < n; i++)
            {
                change[(i - A[i] + 1 + n) % n] -= 1;
            }

            int maxI = 0;
            for (int i = 1; i < n; i++)
            {
                change[i] += change[i - 1] + 1;
                maxI = change[i] > change[maxI] ? i : maxI;
            }
            return maxI;
        }

        // bug
        public int Try(int[] A)
        {
            int len = A.Length;

            int[][] dp = new int[len][];

            for (int i = 0; i < len; i++)
            {
                dp[i] = new int[len];
            }

            for (int i = 0; i < len; i++)
            {
                var curr = A[i];
                for (int j = 0; j < len; j++)
                {
                    dp[i][j] = (curr <= j ? 1 : 0) + (i > 0 && j > 0 ? dp[i - 1][j - 1] : 0) + (j != len - 1 ? dp[len - 1 - j][len - 1] : 0);
                }
            }

            return len;
        }

        // O(n*n)
        public int Simple(int[] A)
        {
            int res = 0, maxScore = 0, len = A.Length;

            for (int i = 0; i < len; i++)
            {
                if (A[i] <= i)
                {
                    maxScore++;
                }
            }

            for (int i = 1; i < len; i++)
            {
                var score = 0;
                for (int j = i; j < len; j++)
                {
                    if (A[j] <= j - i) score++;
                }
                var start = len - i;
                for (int j = 0; j < i; j++)
                {
                    if (A[j] <= start + j) score++;
                }
                if (score > maxScore)
                {
                    maxScore = score;
                    res = i;
                }
            }
            return res;

        }

    }
}
