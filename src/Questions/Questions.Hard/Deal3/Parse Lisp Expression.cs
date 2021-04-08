using Command.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/6/2021 4:59:04 PM
    /// @source : https://leetcode.com/problems/parse-lisp-expression/
    /// @des : 
    ///     给定一个字符串表达式，它表示一个类似于lisp的表达式，用于返回的整数值。
    ///     表达式可以是整数、let表达式、add表达式、多表达式或指定的变量。
    ///     变量以小写字母开头，然后是0个或多个小写字母或数字
    ///     
    ///     let表达式注：
    ///         (let x 2 x 3 x) = 3 ,相同变量以最后一次赋值为准
    /// 
    /// </summary>
    [Favorite("表达式解析")]
    public class Parse_Lisp_Expression
    {


        // A variable starts with a lowercase letter, then zero or more lowercase letters or digits.

        // todo: 未写完  target: 简化获取
        public int Solution2(string expression) 
        {
            int i = 0;
            return Help(ref i);
            int Help(ref int i, Dictionary<string, int> variables = null)
            {
                StringBuilder builder = new StringBuilder();
                for (; i < expression.Length; i++)
                {
                    var c = expression[i];

                    if (c >= 'a' && c <= 'z')
                    {
                        GetVarKey(ref i);
                    }
                }

                return 0;

                void GetVarKey(ref int i)
                {
                    builder.Clear();
                    builder.Append(expression[i]);
                    while (expression[++i] != ' ')
                    {
                        builder.Append(expression[i]);
                    }
                }

            }

        }

        // Runtime: 88 ms, faster than 23.08% of C# online submissions for Parse Lisp Expression.
        // Memory Usage: 26.3 MB, less than 7.69% of C# online submissions for Parse Lisp Expression.
        public int Evaluate(string expression)
        {
            int i = 0;
            return Help(ref i, new Dictionary<string, int>());
            int Help(ref int i,Dictionary<string,int> variables)
            {
                int num = 0;
                StringBuilder varKey = new StringBuilder();
                StringBuilder varKey2 = new StringBuilder();
                OptType type = OptType.None;
                int? arg1 = null;
                bool isVar = false;
                bool hasVar = false;
                bool hasNum = false;
                bool isNagative = false;
                for (; i < expression.Length; i++)
                {
                    var c = expression[i];

                    if (c == '(')
                    {
                        i++;
                        Common(Help(ref i, variables));
                    }
                    else if (c == ')')
                    {
                        if(isVar)
                        {
                            if (type != OptType.Let)
                            {
                                Common(variables[varKey.ToString()]);
                                return num;
                            }
                            return variables[varKey.ToString()];
                        }
                        Common(num);
                        return num;
                    }
                    else if(c == ' ')
                    {
                        if (isVar)
                        {
                            if (hasVar)
                            {
                                Common(variables[varKey2.ToString()]);
                            }
                            else if (varKey.Equals("add"))
                            {
                                type = OptType.Add;
                            }
                            else if (varKey.Equals("mult"))
                            {
                                type = OptType.Mult;
                            }
                            else if (varKey.Equals("let"))
                            {
                                type = OptType.Let;
                            }
                            else if(type != OptType.Let)
                            {
                                Common(variables[varKey.ToString()]);
                            }
                            else
                            {
                                hasVar = true;
                            }
                            isVar = false;
                        }
                        else if(hasNum)
                        {
                            Common(num);
                            num = 0;
                            hasNum = false;
                            isNagative = false;
                        }
                    }
                    else if (isVar)
                    {
                        if (hasVar)
                        {
                            varKey2.Append(c);
                        }
                        else 
                            varKey.Append(c);
                    }
                    else if(c >= 'a' && c <= 'z')
                    {
                        isVar = true;
                        if (hasVar)
                        {
                            varKey2.Clear();
                            varKey2.Append(c);
                        }
                        else
                        {
                            varKey.Clear();
                            varKey.Append(c);
                        }
                    }
                    else if(c == '-')
                    {
                        isNagative = true;
                    }
                    else
                    {
                        hasNum = true;
                        if(isNagative)
                        {
                            num = num * 10 - c + '0';
                        }
                        else
                        {
                            num = num * 10 + c - '0';
                        }
                    }

                }
                return num;

                void Common(int right)
                {
                    if (type == OptType.None)
                    {
                        num = right;
                    }
                    else if (type == OptType.Let)
                    {
                        if (!hasVar)
                        {
                            num = right;
                        }
                        else
                        {
                            // clone
                            variables = new Dictionary<string, int>(variables);
                            variables[varKey.ToString()] = right;
                            hasVar = false;
                        }
                    }
                    else if (!arg1.HasValue)
                    {
                        arg1 = right;
                    }
                    else if (type == OptType.Add)
                    {
                        num = arg1.Value + right;
                        arg1 = null;
                    }
                    else
                    {
                        num = arg1.Value * right;
                        arg1 = null;
                    }
                }

            }
        }
        enum OptType
        {
            None = 0,
            Let = 1,
            Add = 2,
            Mult = 3
        }
    }
}
