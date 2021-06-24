using Command.Tools;
using ConsoleTest.LargeData;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/23/2020 4:16:43 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestDemo : BaseDemo
    {

        public void Test()
        {
            int res;
            { // simple case

                res = new Best_Time_to_Buy_and_Sell_Stock_IV().Optimize(1000000000, LargeArray.Arr);//1648961

                ShowTools.Show(res);
                res = new Best_Time_to_Buy_and_Sell_Stock_IV().Optimize(2, new[] { 2, 4, 6 }); // 4

                ShowTools.Show(res);

                res = new Best_Time_to_Buy_and_Sell_Stock_IV().Optimize(2, new[] { 2, 4, 1 }); // 2

                ShowTools.Show(res);

                res = new Best_Time_to_Buy_and_Sell_Stock_IV().Optimize(2, new[] { 3, 2, 6, 5, 0, 3 }); // 7

                ShowTools.Show(res);

            }
            for (int j = 0; j < 10; j++)
            {

                List<int> nums = new List<int>();
                int i = 0, len = random.Next(2000) + 10;
                for (; i < len; i++)
                {
                    nums.Add(random.Next(10) + 1);
                }
                int k = random.Next(len / 2) + 1;

                //                    Console.WriteLine($@"
                //{k}
                //[{string.Join(',',nums)}]
                //({nums.Count}):
                //");

                codeTimerResult = codeTimer.Time(1, () =>
                {
                    //res = new Best_Time_to_Buy_and_Sell_Stock_IV().MaxProfit(k, nums.ToArray());
                    //res = new Best_Time_to_Buy_and_Sell_Stock_IV().DpSolution(k, nums.ToArray());
                    res = new Best_Time_to_Buy_and_Sell_Stock_IV().Optimize(k, nums.ToArray());
                });

                Console.WriteLine($@"
res:{res}
{nameof(codeTimerResult)}:{codeTimerResult}
");
                int real = 0;
                codeTimerResult = codeTimer.Time(1, () =>
                {
                    real = new Best_Time_to_Buy_and_Sell_Stock_IV().DpSolution(k, nums.ToArray());
                });

                Console.WriteLine($@"
[dpSolution]
{nameof(codeTimerResult)}:{codeTimerResult}
");
                if (res != real)
                {
                    throw new Exception("bug");
                }

                Console.WriteLine("--------------------");


            }

        }


    }
}
