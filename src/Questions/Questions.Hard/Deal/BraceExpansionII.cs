using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/19 星期一 下午 5:28:08
    /// @source : https://leetcode.com/problems/brace-expansion-ii/
    /// @des : 
    /// </summary>
    public class BraceExpansionII
    {
        #region solution

        public IList<string> Solution(string expression)
        {
//            ShowIndex(expression);
            var i = -1;
            return Helper3(expression, ref i).OrderBy(u => u).ToList();
        }

        /**
         * Runtime: 308 ms, faster than 83.33% of C# online submissions for Brace Expansion II.
         * Memory Usage: 32.6 MB, less than 100.00% of C# online submissions for Brace Expansion II.
         */
        public ISet<string> Helper3(string expression, ref int i)
        {
            ISet<string> res = new HashSet<string>();
            ISet<string> next = null;
            bool andFlag = false;
            string str = string.Empty;

            for (i++; i < expression.Length; i++)
            {
                if (expression[i] == '}') break;
                if (expression[i] == '{')
                {
                    if (str != string.Empty) // {a,b{...}}
                        next = Combination(next, new HashSet<string>() {str}, false);

                    //var flagI = i;
//                    Console.WriteLine(
//                        $"res:{JsonConvert.SerializeObject(res)},andFlag:{andFlag},flagI:{flagI},startI:{i}");
                    //{a,b{....}{....}}
                    next = Combination(next, Helper3(expression, ref i), false);

//                    Console.WriteLine(
//                        $"res:{JsonConvert.SerializeObject(res)},andFlag:{andFlag},flagI:{flagI},endI:{i}");
                    if (!andFlag)
                    {
                        res = Combination(res, next, false);
                        next = null;
                    }

                    str = String.Empty;
//                    andFlag = false;// bug
                }
                else if (expression[i] == ',')
                {
                    if (str != string.Empty)
                    {
                        if (next != null) //{...,{}b}
                            next = Combination(next, new HashSet<string>() {str}, false);
                        else
                            res = Combination(res, new HashSet<string>() {str}, andFlag);
                        str = string.Empty;
                    }

                    res = Combination(res, next, true);
                    next = null;

                    andFlag = true;
                }
                else
                {
                    str += expression[i];
                }
            }

            if (str != string.Empty)
            {
                //{...,{...}b}
                if (next != null) next = Combination(next, new HashSet<string>() {str}, false);
                else res = Combination(res, new HashSet<string>() {str}, andFlag);
            }

            return Combination(res, next, true);
        }

        /**
         * same...
         */
        public ISet<string> Optimize(string expression, ref int i)
        {
            ISet<string> res = new HashSet<string>();
            ISet<string> next = null;
            bool andFlag = false;
            StringBuilder builder = new StringBuilder();

            for (i++; i < expression.Length; i++)
            {
                if (expression[i] == '}') break;
                if (expression[i] == '{')
                {
                    if (builder.Length != 0) 
                        next = Combination(next, new HashSet<string>() {builder.ToString()}, false);

                    next = Combination(next, Optimize(expression, ref i), false);

                    if (!andFlag)
                    {
                        res = Combination(res, next, false);
                        next = null;
                    }

                    builder.Clear();
                }
                else if (expression[i] == ',')
                {
                    if (builder.Length != 0)
                    {
                        if (next != null) //{...,{}b}
                            next = Combination(next, new HashSet<string>() {builder.ToString()}, false);
                        else
                            res = Combination(res, new HashSet<string>() {builder.ToString()}, andFlag);
                        builder.Clear();
                    }

                    res = Combination(res, next, true);
                    next = null;

                    andFlag = true;
                }
                else
                    builder.Append(expression[i]);
            }

            if (builder.Length != 0)
            {
                if (next != null) next = Combination(next, new HashSet<string>() {builder.ToString()}, false);
                else res = Combination(res, new HashSet<string>() {builder.ToString()}, andFlag);
            }

            return Combination(res, next, true);
        }

        #region try

        public ISet<string> Helper2(string expression, ref int i)
        {
            bool andFlag = false;
            bool continueFlag = false;
            ISet<string> list = new HashSet<string>();
            string str = string.Empty;

            for (i++; i < expression.Length; i++)
            {
                if (expression[i] == '}')
                {
                    if (i + 1 == expression.Length || expression[i + 1] == ',' || expression[i + 1] == '}') break;
                    if (str != string.Empty)
                        list = Combination(list, new HashSet<string>() {str}, andFlag);
                    str = string.Empty;
                    andFlag = false;
                    continueFlag = true;
                }

                if (expression[i] >= 'a' && expression[i] <= 'z')
                {
                    str += expression[i];
                    continue;
                }

                if (expression[i] == ',')
                {
                    if (continueFlag)
                    {
                        i--;
                        break;
                    }

                    if (str != string.Empty)
                    {
                        list = Combination(list, new HashSet<string>() {str}, andFlag);
                        str = string.Empty;
                    }

                    andFlag = true;
                    continue;
                }

                if (expression[i] == '{')
                {
                    if (str != string.Empty)
                    {
                        list = Combination(list,
                            Combination(new HashSet<string>() {str}, Helper2(expression, ref i), false), andFlag);
                        str = string.Empty;
                    }
                    else
                    {
                        list = Combination(list, Helper2(expression, ref i), andFlag);
                    }

                    andFlag = false;
                }
            }

            if (str != string.Empty)
                list = Combination(list, new HashSet<string>() {str}, andFlag);

            return list;
        }

        // bug
        public ISet<string> Helper(string expression, ref int i)
        {
            ISet<string> list = new HashSet<string>();
            string str = string.Empty;
            for (i++; i < expression.Length; i++)
            {
                if (expression[i] >= 'a' && expression[i] <= 'z')
                {
                    str += expression[i];
                    continue;
                }

                if (str != string.Empty)
                {
                    list.Add(str);
                    str = string.Empty;
                }

                if (expression[i] == '}')
                    break;

                if (expression[i] == '{')
                {
                    if (i - 1 > 0)
                    {
                        if (expression[i - 1] == ',')
                        {
                            list = Combination(list, Helper(expression, ref i), true);
                        }
                        else
                        {
                            if (str != string.Empty)
                            {
                                list = Combination(list,
                                    Combination(new HashSet<string>() {str}, Helper(expression, ref i), false), true);
                            }
                        }
                    }
                    else
                    {
                        list = Helper(expression, ref i);
                    }
                }
            }

            return list;
        }

        #endregion

        public void ShowIndex(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{' || str[i] == '}')
                    Console.WriteLine($"{i}:{str[i]}");
            }
        }

        protected ISet<string> Combination(ISet<string> old, ISet<string> next, bool andFlag)
        {
            if (old == null || old.Count == 0) return next;
            if (next == null || next.Count == 0) return old;
            ISet<string> list;
            if (andFlag)
            {
                list = old;
                foreach (var item in next)
                {
                    list.Add(item);
                }
            }
            else
            {
                list = new HashSet<string>();

                foreach (var a in old)
                {
                    foreach (var b in next)
                    {
                        list.Add(a + b);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}