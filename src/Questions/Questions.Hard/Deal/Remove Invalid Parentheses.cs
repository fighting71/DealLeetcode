using Command.Attr;
using Command.Const;
using Command.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/9/2020 3:52:46 PM
    /// @source : https://leetcode.com/problems/remove-invalid-parentheses/
    /// @des : 
    /// </summary>
    [Favorite(FlagConst.Complex),Optimize]
    public class Remove_Invalid_Parentheses
    {

        // same efficient
        public IList<string> Optimize(string s)
        {

            ISet<string> set = new HashSet<string>();

            OptimizeHelp(s, 0, 0, new List<int>(), new bool[s.Length], set);

            return set.ToList();

        }

        private void OptimizeHelp(string s, int index, int left, List<int> rightIndex, bool[] flag, ISet<string> set)
        {
            for (; index < s.Length; index++)
            {
                if (s[index] == '(') left++;
                else if (s[index] == ')')
                {
                    if (left == 0)
                    {
                        for (int j = 0; j < rightIndex.Count; j++)
                        {
                            var newList = new List<int>(rightIndex);
                            newList.RemoveAt(j);
                            newList.Add(index);
                            bool[] newFlag = (bool[])flag.Clone();
                            newFlag[rightIndex[j]] = true;
                            Help(s, index + 1, 0, newList, newFlag, set);
                        }
                        flag[index] = true;
                    }
                    else
                    {
                        left--;
                        rightIndex.Add(index);
                    }
                }
            }

            OptimizePush(s, left, 0, s.Length - 1, flag, set);
        }

        private void OptimizePush(string s, int left, int right, int start, bool[] flag, ISet<string> res)
        {
            for (; start >= 0 && left > 0; start--)
            {
                if (flag[start]) continue;
                if (s[start] == '(')
                {
                    if (right == 0) flag[start] = true;
                    else
                    {
                        OptimizePush(s, left, right - 1, start - 1, (bool[])flag.Clone(), res);
                        flag[start] = true;
                    }
                    left--;
                }
                else if (s[start] == ')') right++;
            }

            if (left > 0) return;

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < s.Length; i++) if (!flag[i]) builder.Append(s[i]);

            res.Add(builder.ToString());

        }

        #region simple

        /// <summary>
        /// Runtime: 256 ms, faster than 62.20% of C# online submissions for Remove Invalid Parentheses.
        /// Memory Usage: 33.3 MB, less than 100.00% of C# online submissions for Remove Invalid Parentheses.
        /// 
        /// emm... 还真就被我给试出来了
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> Solution(string s)
        {

            ShowTools.ShowIndex(s);

            ISet<string> set = new HashSet<string>();

            Help(s, 0, 0, new List<int>(), new bool[s.Length], set);

            return set.ToList();
        }

        private void Help(string s, int index, int left, List<int> rightIndex, bool[] flag, ISet<string> set)
        {
            for (; index < s.Length; index++)
            {
                if (s[index] == '(')
                {
                    left++;
                }
                else if (s[index] == ')')
                {
                    // **** 当(出现多余时，可以任意删除之前的一个(
                    // 例如: ()()) 可以删除 1 (()) 2 ()() 3()()
                    if (left == 0)
                    {
                        for (int j = 0; j < rightIndex.Count; j++)
                        {
                            var newList = new List<int>(rightIndex);
                            newList.RemoveAt(j);
                            newList.Add(index);
                            bool[] newFlag = (bool[])flag.Clone();
                            newFlag[rightIndex[j]] = true;
                            Help(s, index + 1, 0, newList, newFlag, set);
                        }
                        flag[index] = true;
                    }
                    else
                    {
                        // *** 记录下 ( 的下标
                        rightIndex.Add(index);
                        left--;
                    }
                }
            }

            //bug : "()((k()(("
            //for (int i = s.Length - 1; i >= 0 && left > 0; i--)
            //{
            //    if (flag[i]) continue;
            //    if (s[i] == '(')
            //    {
            //        flag[i] = true;
            //        left--;
            //    }
            //}

            //StringBuilder builder = new StringBuilder();

            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (!flag[i]) builder.Append(s[i]);
            //}

            //set.Add(builder.ToString());

            #region fix "()((k()(("
            Push(s, left, 0, s.Length - 1, flag, set);
            #endregion
        }

        private void Push(string s, int left, int right, int start, bool[] flag, ISet<string> res)
        {
            // *** 删除多余的 (
            for (; start >= 0 && left > 0; start--)
            {
                if (flag[start]) continue;
                if (s[start] == '(')
                {
                    if (right == 0)// 后面没有) 直接删除
                    {
                        flag[start] = true;
                    }
                    else
                    {// 后面存在) 可以保留跳过或删除
                        Push(s, left, right - 1, start - 1, (bool[])flag.Clone(), res);
                        flag[start] = true;
                    }
                    left--;
                }
                else if (s[start] == ')')
                {
                    right++;
                }
            }

            // bug : "(r(()()(" Output: ["r()()","r(())"] Expected: ["r()()","r(())","(r)()","(r())"]
            //if (left > 0 || right > 0) return;

            #region fix "(r(()()("
            if (left > 0) return;

            // ... 多余
            //for (;start >= 0 && right > 0; start -- )
            //{
            //    if (flag[start]) continue;
            //    if (s[start] == '(')
            //    {
            //        right--;
            //    }
            //    else if(s[start] == ')')
            //    {
            //        right++;
            //    }
            //}
            //if (right > 0) return;
            #endregion

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (!flag[i]) builder.Append(s[i]);
            }

            res.Add(builder.ToString());

        }

        #endregion

    }
}
