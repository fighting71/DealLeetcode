using Questions.DailyChallenge._2020September.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/22/2020 3:45:36 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestMajority_Element_IIDemo : BaseDemo
    {

        public void Test ()
        {
            for (int j = 0; j < 10; j++)
            {

                List<int> nums = new List<int>();
                int i = 0, len = random.Next(2000) + 3000000;
                for (; i < len; i++)
                {
                    nums.Add(random.Next(len / 3));
                }
                IList<int> res;

                Console.WriteLine($@"
nums: len - {len}
");

                codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = new Majority_Element_II().MajorityElement(nums.ToArray());
                });

                Console.WriteLine(codeTimerResult);

                codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = new Majority_Element_II().Optimize2(nums.ToArray());
                });

                Console.WriteLine($"[optimize]:{codeTimerResult}");

                Console.WriteLine("----------------------------");
            }

        }


    }
}
