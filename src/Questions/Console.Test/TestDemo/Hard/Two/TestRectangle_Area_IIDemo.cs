using Command.Helper;
using Newtonsoft.Json;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/24/2021 6:28:50 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRectangle_Area_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Rectangle_Area_II instance = new Rectangle_Area_II();

            var arr = JsonConvert.DeserializeObject<int[][]>("[[93516,44895,94753,69358],[13141,52454,59740,71232],[22877,11159,85255,61703],[11917,8218,84490,36637],[75914,29447,83941,64384],[22490,71433,64258,74059],[18433,51177,87595,98688],[70854,80720,91838,92304],[46522,49839,48550,94096],[95435,37993,99139,49382],[10618,696,33239,45957],[18854,2818,57522,78807],[61229,36593,76550,41271],[99381,90692,99820,95125]]");// 971243962

            var argList = new List<int[][]>()
                {
                    arr,
                    JsonConvert.DeserializeObject<int[][]>("[[18433,51177,87595,98688],[70854,80720,91838,92304]]"), // 335106673
                    JsonConvert.DeserializeObject<int[][]>("[[18433,51177,87595,98688],[22877,11159,85255,61703],[70854,80720,91838,92304]]"), // 831349463
                    JsonConvert.DeserializeObject<int[][]>("[[18433,51177,87595,98688],[22490,71433,64258,74059],[22877,11159,85255,61703],[70854,80720,91838,92304]]"), // 831349463
                    JsonConvert.DeserializeObject<int[][]>("[[11917,8218,84490,36637],[13141,52454,59740,71232],[18433,51177,87595,98688],[22490,71433,64258,74059],[22877,11159,85255,61703],[70854,80720,91838,92304]]"), // 423398705
                    JsonConvert.DeserializeObject<int[][]>("[[22490,71433,64258,74059],[22877,11159,85255,61703],[70854,80720,91838,92304]]"), // 505595035
                    JsonConvert.DeserializeObject<int[][]>("[[49,40,62,100],[11,83,31,99],[19,39,30,99]]"), // 1584
                    JsonConvert.DeserializeObject<int[][]>("[[0,0,1000000000,1000000000]]"), // 49
                    JsonConvert.DeserializeObject<int[][]>("[[0,0,2,2],[1,0,2,3],[1,0,3,1]]"), // 6
                };

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    argList.Add(arr.Take(i + 1).ToArray());
            //}


            BaseLibrary.CommonTest(argList.ToArray()
            , instance.RectangleArea
            , () =>
            {
                var range = 1000_000_000;
                return CollectionHelper.GetEnumerable(200, () =>
                {
                    int x1 = random.Next(range), y1 = random.Next(range), x2 = random.Next(x1, range), y2 = random.Next(y1, range);
                    return new[] { x1, y1, x2, y2 };
                }).ToArray();
            }
            );

        }

    }
}
