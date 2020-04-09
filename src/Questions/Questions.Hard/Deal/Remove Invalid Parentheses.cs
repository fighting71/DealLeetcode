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
    public class Remove_Invalid_Parentheses
    {

        public IList<string> Solution(string s)
        {
            ISet<string> set = new HashSet<string>();

            Help(s, 0, 0, new List<int>(), new bool[s.Length], set);

            return set.ToList();
        }

        private void Help(string s,int index,int left,List<int> rightIndex,bool[] flag,ISet<string> set)
        {
            for (; index < s.Length; index++)
            {
                if (s[index] == '(')
                {
                    left++;
                }
                else if(s[index] == ')')
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
                        rightIndex.Add(index);
                        left--;
                    }
                }
            }

            // //bug : "(((k()(("
            for (int i = s.Length - 1; i >= 0 && left > 0; i--)
            {
                if (flag[i]) continue;
                if (s[i] == '(')
                {
                    flag[i] = true;
                    left--;
                }
            }

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (!flag[i]) builder.Append(s[i]);
            }

            set.Add(builder.ToString());

        }

    }
}
