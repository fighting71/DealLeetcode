using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020September.Week4;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/28/2020 2:56:57 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestEvaluate_DivisionDemo : BaseDemo
    {

        public void Test()
        {

            {


                IList<IList<string>>[] equationsArr = new[] {
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"b\"],[\"e\",\"f\"],[\"b\",\"e\"]]"), // [0.29412,10.94800,1.00000,1.00000,-1.00000,-1.00000,0.71429]
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"b\"],[\"b\",\"c\"],[\"bc\",\"cd\"]]"),
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"b\"],[\"b\",\"c\"]]"),
                    };

                double[][] valuesArr = new[]
                {
                        new[] { 3.4,1.4,2.3 },
                        new[] { 1.5, 2.5, 5.0 },
                        new[] { 2.0, 3.0 },
                    };

                IList<IList<string>>[] queriesArr = new[] {
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"b\",\"a\"],[\"a\",\"f\"],[\"f\",\"f\"],[\"e\",\"e\"],[\"c\",\"c\"],[\"a\",\"c\"],[\"f\",\"e\"]]"),
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"c\"],[\"c\",\"b\"],[\"bc\",\"cd\"],[\"cd\",\"bc\"]]"),
                        JsonConvert.DeserializeObject<List<IList<string>>>("[[\"a\",\"c\"],[\"b\",\"a\"],[\"a\",\"e\"],[\"a\",\"a\"],[\"x\",\"x\"]]"),
                    };

                for (int i = 0; i < equationsArr.Length; i++)
                {
                    if (!runSimple) break;
                    var res = new Evaluate_Division().Try(equationsArr[i], valuesArr[i], queriesArr[i]);
                    ShowTools.ShowLine(res);

                }

            }

            {
                CodeTimerResult codeTimerResult;

            }

        }

    }
}
