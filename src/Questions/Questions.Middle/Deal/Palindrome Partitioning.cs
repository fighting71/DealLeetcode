using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Middle.Deal
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 10:40:13 AM
    /// @source : https://leetcode.com/problems/palindrome-partitioning/
    /// @des : 
    /// </summary>
    public class Palindrome_Partitioning
    {

        public IList<IList<string>> Partition(string str)
        {
            int len = str.Length;

            bool[][] isPalindrome = new bool[len][];
            for (int i = 0; i < len; i++)
            {
                isPalindrome[i] = new bool[len - i];
                isPalindrome[i][0] = true;
            }

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j + i < len; j++)
                {
                    if (i < 3 || isPalindrome[j + 1][i - 2]) isPalindrome[j][i] = str[j] == str[j + i];
                }
            }
            IList<IList<string>> res = new List<IList<string>>();
            Help(isPalindrome, res, Array.Empty<string>(), 0, str);

            return res;
        }

        public IList<IList<string>> Optimize(string str)
        {
            int len = str.Length;

            bool[][] isPalindrome = new bool[len][];
            for (int i = 0; i < len; i++)
            {
                isPalindrome[i] = new bool[len - i];
                isPalindrome[i][0] = true;
            }

            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j + i < len; j++)
                {
                    if (i < 3 || isPalindrome[j + 1][i - 2]) isPalindrome[j][i] = str[j] == str[j + i];
                }
            }
            return Help2(isPalindrome, new IList<IList<string>>[len], 0, str);

        }

        //Runtime: 260 ms, faster than 87.36% of C# online submissions for Palindrome Partitioning.
        //Memory Usage: 33.4 MB, less than 89.01% of C# online submissions for Palindrome Partitioning.
        private IList<IList<string>> Help2(bool[][] isPalindrome, IList<IList<string>>[] cache, int index, string str)
        {
            if (index == str.Length) return null;

            if (cache[index] != null)
            {
                return cache[index];
            }

            var arr = isPalindrome[index];

            IList<IList<string>> res = new List<IList<string>>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i])
                {
                    IList<IList<string>> after = Help2(isPalindrome, cache, index + i + 1, str);

                    var info = str.AsSpan(index, i + 1).ToString();

                    if (after != null)
                    {
                        foreach (var item in after)
                        {
                            var copyItem = new List<string>(item);
                            copyItem.Insert(0, info);
                            res.Add(copyItem);
                        }
                    }
                    else
                    {
                        res.Add(new List<string>() { info });
                    }

                }
            }

            //Runtime: 264 ms, faster than 77.47% of C# online submissions for Palindrome Partitioning.
            //Memory Usage: 38.2 MB, less than 5.49% of C# online submissions for Palindrome Partitioning.
            // 不玩了...
            return cache[index] = res;
        }


        //Runtime: 260 ms, faster than 87.36% of C# online submissions for Palindrome Partitioning.
        //Memory Usage: 33.6 MB, less than 60.99% of C# online submissions for Palindrome Partitioning.
        private void Help(bool[][] isPalindrome, IList<IList<string>> res, IList<string> build, int index, string str)
        {
            if(index == str.Length)
            {
                res.Add(build);
                return;
            }
            var arr = isPalindrome[index];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i])
                {
                    var newBuild = new List<string>(build);
                    newBuild.Add(str.AsSpan(index, i + 1).ToString());
                    Help(isPalindrome, res, newBuild, index + i + 1, str);
                }
            }
        }

    }
}
