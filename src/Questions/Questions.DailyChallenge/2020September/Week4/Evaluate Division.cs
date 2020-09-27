using Command.CusStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.DailyChallenge._2020September.Week4
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/27/2020 4:14:20 PM
    /// @source : https://leetcode.com/explore/challenge/card/september-leetcoding-challenge/557/week-4-september-22nd-september-28th/3474/
    /// @des : 
    /// </summary>
    public class Evaluate_Division
    {
        /**
1 <= equations.length <= 20
equations[i].length == 2
1 <= equations[i][0].length, equations[i][1].length <= 5
values.length == equations.length
0.0 < values[i] <= 20.0
1 <= queries.length <= 20
queries[i].length == 2
1 <= queries[i][0].length, queries[i][1].length <= 5
equations[i][0], equations[i][1], queries[i][0], queries[i][1] consist of lower case English letters and digits.
         */

        public double[] Try(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {

            IDictionary<string, ISet<string>> mapperDic = new Dictionary<string, ISet<string>>();

            IDictionary<(string, string), double> dic = new Dictionary<(string, string), double>();

            for (int i = 0; i < values.Length; i++)
            {

                string a = equations[i][0], b = equations[i][1];
                double value = values[i];

                if (dic.ContainsKey((a, b))) continue;

                dic[(a, a)] = 1;

                if (a == b) continue;

                dic[(b, b)] = 1;

                dic[(a, b)] = value;
                dic[(b, a)] = 1 / value;

                Help(dic, mapperDic, a, b, value);


            }

            double[] answer = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                var key = (queries[i][0], queries[i][1]);
                if (dic.ContainsKey(key)) answer[i] = dic[key];
                else answer[i] = -1;
            }

            return answer;

        }

        private void Help(IDictionary<(string, string), double> dic, IDictionary<string, ISet<string>> mapperDic, string a, string b, double value)
        {
            if (mapperDic.ContainsKey(a))
            {
                foreach (var item in mapperDic[a].ToArray())
                {
                    if (dic.ContainsKey((item, b))) continue;
                    var empty = dic[(item, b)] = dic[(item, a)] * value;
                    dic[(b, item)] = 1 / empty;
                    Help(dic, mapperDic, item, b, empty);
                }
                mapperDic[a].Add(b);
            }
            else mapperDic[a] = new HashSet<string>() { b };

            if (mapperDic.ContainsKey(b))
            {
                foreach (var item in mapperDic[b].ToArray())
                {
                    if (dic.ContainsKey((item, a))) continue;
                    var empty = dic[(a, item)] = value / dic[(b, item)];
                    dic[(item, a)] = 1 / empty;
                    Help(dic, mapperDic, a, item, empty);
                }
                mapperDic[b].Add(a);
            }
            else mapperDic[b] = new HashSet<string>() { a };

        }

        public double[] Simple(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {

            IDictionary<CusVector<string, string>, double> dic = new Dictionary<CusVector<string, string>, double>();

            for (int i = 0; i < values.Length; i++)
            {

                var vector = new CusVector<string, string>(equations[i][0], equations[i][1]);

                if (dic.ContainsKey(vector)) continue;

                if (vector.X == vector.Y)
                {
                    dic[new CusVector<string, string>(vector.X, vector.X)] = dic[new CusVector<string, string>(vector.Y, vector.Y)] = 1;
                    continue;
                }

                // bug : 此处可能需要递归...
                foreach (var key in dic.Keys.ToArray())
                {
                    if (key.X == key.Y) continue;
                    if (key.Y == vector.X)
                    {
                        dic[new CusVector<string, string>(key.X, vector.Y)] = dic[key] / values[i];
                        dic[new CusVector<string, string>(vector.Y, key.X)] = values[i] / dic[key];
                    }
                    else if (key.X == vector.Y)
                    {
                        dic[new CusVector<string, string>(key.X, vector.Y)] = values[i] / dic[key];
                        dic[new CusVector<string, string>(vector.Y, key.X)] = dic[key] / values[i];
                    }
                    else if (key.X == vector.X)
                    {
                        dic[new CusVector<string, string>(key.Y, vector.Y)] = values[i] / dic[key];
                        dic[new CusVector<string, string>(vector.Y, key.Y)] = dic[key] / values[i];
                    }
                    else if (key.Y == vector.Y)
                    {
                        dic[new CusVector<string, string>(key.X, vector.X)] = dic[key] / values[i];
                        dic[new CusVector<string, string>(vector.X, key.X)] = values[i] / dic[key];
                    }
                }

                dic[vector] = values[i];
                dic[new CusVector<string, string>(vector.Y, vector.X)] = 1 / values[i];
                dic[new CusVector<string, string>(vector.X, vector.X)] = dic[new CusVector<string, string>(vector.Y, vector.Y)] = 1;

            }

            double[] answer = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                var vector = new CusVector<string, string>(queries[i][0], queries[i][1]);
                if (dic.ContainsKey(vector)) answer[i] = dic[vector];
                else answer[i] = -1;
            }

            return answer;

        }

    }
}
