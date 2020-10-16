using Command.Tools;
using ConsoleTest.LargeData;
using Questions.DailyChallenge._2020September.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 10/14/2020 6:30:13 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestLargest_NumberDemo
    {
        public static void Run(CodeTimer codeTimer)
        {
            CodeTimerResult codeTimerResult;

            {
                string res;
                {
                    res = new Largest_Number().LargestNumber(new[] { 3, 30, 34, 5, 9 });

                    ShowTools.Show(res);

                }
                {

                    for (int i = 0; i < 2; i++)
                    {
                        codeTimerResult = codeTimer.Time(1, () =>
                        {
                            res = new Largest_Number().LargestNumber(LargeArray.Arr);
                        });

                        ShowTools.Show(res);

                        ShowTools.Show(codeTimerResult);
                    }


                }
            }

        }
    }
}
