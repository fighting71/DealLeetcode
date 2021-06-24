using Command.Tools;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/16/2020 9:44:37 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestExpression_Add_OperatorsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Expression_Add_Operators instance = new Expression_Add_Operators();
            if (runSimple)
            { // simple

                var argArr = new[]
                {
                        ("1234567890", 8),
                        ("1111",-1),
                        ("232", 8),
                        ("2147483648", int.MinValue),
                    };

                foreach (var item in argArr)
                {
                    IList<string> res = instance.Try3(item.Item1, item.Item2);
                    IList<string> real = instance.Try2(item.Item1, item.Item2);

                    //ShowTools.Show(res);
                    //ShowTools.Show(real);

                    if (ShowTools.GetStr(res) != ShowTools.GetStr(real))
                    {
                        ShowTools.Show(res.Where(u => !real.Contains(u)));
                        //ShowTools.Show(real.Where(u => !res.Contains(u)));
                        throw bugEx;
                    }

                }
            }
            else
            { // speed&real
              //for (int i = 0; i < 10; i++)
              //{
              //    CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
              //    {
              //        instance.Try2("1234567890", 8);
              //    });
              //    Console.WriteLine(codeTimerResult);
              //}
            }
        }
    }
}
