using Command.Tools;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{

    /// <summary>
    /// @auth : monster
    /// @since : 11/10/2020 2:27:43 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMinWindowDemo : BaseDemo
    {

        public void Run()
        {
            MinWindow instance = new MinWindow();
            { // simple

                (string, string)[] argArr = new[]
                {
                        ("VJxchEnVdiKuBPybCoKVxzvxdCHcKWaXjtqicisoItpemPIRvOWgVGgMlKLZoLEpAvGPMZLhXYrGkoneoQqI","bc"),
                        ("mdjydSVKRWflALMJQyhMkVPyTMNQcYldqUHeSHAMMGTwBKFcXjWderZQolRelBmhFgBMxZhjrqcvtvUKSZEpCmZJcIhcaJKXabsLDPFyJ", "JrcM"),
                        ("a", "a"),
                        ("ADOBECODEBANC", "ABC"),
                    };

                foreach (var item in argArr)
                {

                    var s = GetSimple(item.Item1, item.Item2);
                    Console.WriteLine(instance.Try2(s, item.Item2));
                }

            }
            for (int i = 0; i < 1000; i++)
            { // speed&real

                string s = GetStr(random.Next(105) + 1), t = GetStr(random.Next(105) + 1);
                //string s = GetStr(105), t = GetStr(random.Next(105) + 1);
                //string s = GetStr(20), t = GetStr(random.Next(6) + 2);

                string real = instance.Try2(s, t);
                string res = instance.Clear(s, t);

                if (res != string.Empty)
                    ShowTools.ShowMulti(new Dictionary<string, object>
                        {
                            {nameof(s),s },
                            {nameof(t),t },
                            {nameof(res),res },
                        });

                if (real != res) throw bugEx;

            }

            string GetStr(int len)
            {

                StringBuilder builder = new StringBuilder(len);

                for (int i = 0; i < len; i++)
                {
                    if (random.Next(2) == 0)
                        builder.Append((char)(random.Next(26) + 'A'));
                    else
                        builder.Append((char)(random.Next(26) + 'a'));
                }
                return builder.ToString();

            }

            string GetSimple(string s, string t)
            {
                ISet<char> set = new HashSet<char>();

                foreach (var c in t)
                {
                    set.Add(c);
                }

                StringBuilder builder = new StringBuilder();
                foreach (var c in s)
                {
                    if (set.Contains(c)) builder.Append(c);
                    else builder.Append('_');
                }
                return builder.ToString();

            }
        }


    }
}
