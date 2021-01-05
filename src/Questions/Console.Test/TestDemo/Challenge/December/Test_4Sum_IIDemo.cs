using Command.Tools;
using Questions.DailyChallenge._2020.December.Week3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge.December
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/17/2020 4:55:54 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class Test_4Sum_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            _4Sum_II instance = new _4Sum_II();
            if (runSimple)
            {

            }
            //else
            for (int x = 0; x < 3; x++)
            {
                int len = 500;
                int[] a = new int[len],
                    b = new int[len],
                    c = new int[len],
                    d = new int[len];

                //int min = -(2 << 28), max = 2 << 28;
                int min = -100, max = 100;
                for (int i = 0; i < len; i++)
                {
                    a[i] = random.Next(min, max);
                    b[i] = random.Next(min, max);
                    c[i] = random.Next(min, max);
                    d[i] = random.Next(min, max);
                }
                int res = 0;
                CodeTimerResult codeTimerResult = codeTimer.Time(1, () => {
                    res = instance.Simple(a, b, c, d);
                });

                ShowTools.ShowMulti(new (string, object)[]
                {
                        (null, a ),
                        (null, b ),
                        (null, c ),
                        (null, d ),
                        (nameof(res), res ),
                        (nameof(codeTimerResult), codeTimerResult ),
                });

            }

        }

    }
}
