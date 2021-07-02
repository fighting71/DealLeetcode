using Command.Helper;
using Questions.DailyChallenge._2021.July.Week1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.July
{
    /// <summary>
    /// @auth : monster
    /// @since : 7/2/2021 6:34:04 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFind_K_Clsest_ElementsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Find_K_Clsest_Elements instance = new Find_K_Clsest_Elements();

            BaseLibrary.CommonTest(new[] {
                    (new []{ 14,4,-48,-82,72,84,58,-7,-1,-6,95,-67,-70,-46,-34,-69,-40,4,32,-23,71,32,-3,-55,15,53,47,11,70,-43,-85,-78,-73,96,-93,-8,-89,42,55,-35,91,-81,52,32,-4,36,73,46,-73,66,72,-40,54,-14,38,81,-93,-93,2,-81,-63,-53,23,-58,-21,73,-94,-67,-53,73,-81,18,48,-33,-14,51,80,65,48,79,79,-100,-16,-97,-16,55,-33,40,-42,-75,-16,-96,-61,36,-73,43,-5,10,-47,22 }, 65 , 39), //
                    (new []{ 1, 2, 3, 4, 5 }, 4 , 3), //
                    (new []{ 1, 2, 3, 4, 5 }, 4 , -1), //
                }
            , arg => instance.Try2(arg.Item1, arg.Item2, arg.Item3)
            , () =>
            {
                int len = 10000;
                return (CollectionHelper.GetEnumerable(len, () => random.Next(-len, len)).ToArray(), random.Next(len) + 1, random.Next(-len, len));
            }
            , checkFunc: arg => instance.Simple(arg.Item1, arg.Item2, arg.Item3)
            , equalsFunc: (res, res2) =>
            {
                for (int i = 0; i < res.Count; i++)
                {
                    if (res[i] != res2[i]) return false;
                }
                return true;
            }
            , showArg: false
            , showRes: false
            );

        }

    }
}
