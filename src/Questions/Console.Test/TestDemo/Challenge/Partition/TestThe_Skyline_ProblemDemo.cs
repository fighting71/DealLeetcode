﻿using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2020.November.Week5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge
{
    /// <summary>
    /// @auth : monster
    /// @since : 12/1/2020 11:46:41 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestThe_Skyline_ProblemDemo : BaseDemo, IWork
    {
        public void Run()
        {
            var instance = new The_Skyline_Problem();
            The_Skyline_Problem.Tools tools = new The_Skyline_Problem.Tools();
            if (runSimple)
            { // simple
                var argArr = new[]
                {
                        JsonConvert.DeserializeObject<int[][]>("[[2190,661048,758784],[9349,881233,563276],[12407,630134,38165],[22681,726659,565517],[31035,590482,658874],[41079,901797,183267],[41966,103105,797412],[55007,801603,612368],[58392,212820,555654],[72911,127030,629492],[73343,141788,686181],[83528,142436,240383],[84774,599155,787928],[106461,451255,856478],[108312,994654,727797],[126206,273044,692346],[134022,376405,472351],[151396,993568,856873],[171466,493683,664744],[173068,901140,333376],[179498,667787,518146],[182589,973265,394689],[201756,900649,31050],[215635,818704,576840],[223320,282070,850252],[252616,974496,951489],[255654,640881,682979],[287063,366075,76163],[291126,900088,410078],[296928,373424,41902],[297159,357827,174187],[306338,779164,565403],[317547,979039,172892],[323095,698297,566611],[323195,622777,514005],[333003,335175,868871],[334996,734946,720348],[344417,952196,903592],[348009,977242,277615],[351747,930487,256666],[363240,475567,699704],[365620,755687,901569],[369650,650840,983693],[370927,621325,640913],[371945,419564,330008],[415109,890558,606676],[427304,782478,822160],[439482,509273,627966],[443909,914404,117924],[446741,853899,285878],[480389,658623,986748],[545123,873277,431801],[552469,730722,574235],[556895,568292,527243],[568368,728429,197654],[593412,760850,165709],[598238,706529,500991],[604335,921904,990205],[627682,871424,393992],[630315,802375,714014],[657552,782736,175905],[701356,827700,70697],[712097,737087,157624],[716678,889964,161559],[724790,945554,283638],[761604,840538,536707],[776181,932102,773239],[855055,983324,880344]]"), // [[2190,758784],[41966,797412],[103105,787928],[106461,856478],[151396,856873],[252616,951489],[369650,983693],[480389,986748],[604335,990205],[921904,951489],[974496,880344],[983324,856873],[993568,727797],[994654,0]]
                        JsonConvert.DeserializeObject<int[][]>("[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]"), // [[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]]
                        JsonConvert.DeserializeObject<int[][]>("[[0,2,3],[2,5,3]]"), // [[0,3],[5,0]]
                        JsonConvert.DeserializeObject<int[][]>("[[0,11,17],[0,11,15],[0,10,8],[0,1,19],[0,5,10],[0,14,12],[0,1,10],[1,2,2],[1,4,1],[1,11,10],[1,8,3],[1,9,5],[3,5,5],[3,6,10],[3,6,12],[3,9,25],[3,18,18],[3,16,22],[3,11,20],[3,22,9],[4,16,8],[4,5,23],[5,21,18],[5,15,1],[5,12,30],[5,16,8],[6,22,2],[6,16,1],[6,10,4],[6,6,28],[6,15,2],[6,7,23],[7,16,1],[7,17,11],[7,8,20],[7,19,11],[8,25,20],[8,13,22],[8,22,8],[8,25,11],[8,22,1],[9,9,25],[9,20,30],[9,11,20],[9,22,28],[9,22,26],[10,29,20],[11,14,26],[11,28,15],[11,17,23],[11,29,23],[11,29,19],[11,21,7],[11,19,20],[11,29,9],[12,22,9],[12,24,27],[12,24,8],[12,13,8],[12,28,25],[12,29,2],[13,17,13],[13,15,15],[13,29,12],[13,22,6],[13,23,12],[13,26,10],[13,26,26],[13,28,30],[13,25,21],[14,29,3],[14,24,14],[14,31,9],[14,14,5],[14,21,15],[14,31,2],[14,15,9],[14,29,2],[14,25,22],[15,26,15],[15,31,7],[15,25,10],[15,19,30],[16,34,14],[16,29,11],[16,19,29],[16,35,12],[16,25,19],[17,27,2],[17,23,16],[17,27,4],[17,23,17],[17,19,9],[17,30,7],[18,32,10],[18,24,24],[18,34,23],[18,34,10],[18,29,30],[19,26,8]]"), // [[0,19],[1,17],[3,25],[5,30],[29,23],[34,12],[35,0]]
                        JsonConvert.DeserializeObject<int[][]>("[[0,10,15],[0,10,22],[0,16,26],[0,19,22],[0,9,5],[0,7,8],[0,16,21],[0,17,3],[0,10,2],[0,7,22],[1,12,12],[1,5,20],[1,10,22],[1,5,19],[1,12,4],[1,10,26],[2,13,13],[2,3,30],[2,21,16],[2,20,8],[2,3,5],[2,17,16],[2,19,15],[2,2,6],[3,12,11],[3,5,10]]"), // [[0,26],[2,30],[3,26],[16,22],[19,16],[21,0]]
                        JsonConvert.DeserializeObject<int[][]>("[[0,15,30],[2,14,12],[6,16,16],[9,14,21],[11,16,7],[14,24,21],[14,15,21],[15,30,14],[18,32,13],[19,23,23]]"), // [[0,30],[15,21],[19,23],[23,21],[24,14],[30,13],[32,0]]
                        JsonConvert.DeserializeObject<int[][]>("[ [2,9,10], [3 ,7 ,15], [5 ,12 ,12], [15, 20, 10], [19, 24, 8] ]"), // [ [2 10], [3 15], [7 12], [12 0], [15 10], [20 8], [24, 0] ].
                        JsonConvert.DeserializeObject<int[][]>("[[1,5,2],[2,3,3]]"),// [[1, 2],[2,3],[3,2],[5,0]]
                    };

                foreach (var item in argArr)
                {
                    //tools.ShowImage(item);
                    ShowTools.Show(instance.Try3(item));
                }

            }
            //else
            for (int j = 0; j < 100; j++)
            { // speed&real

                int len = 1000;
                int[][] arr = new int[len][], oldArr = new int[len][];

                for (int i = 0; i < len; i++)
                {
                    int[] item = new int[3];
                    item[0] = random.Next(100);
                    item[1] = random.Next(20) + item[0] + 1;
                    item[2] = random.Next(100) + 1;
                    arr[i] = item;
                    oldArr[i] = new[] { item[0], item[1], item[2] };
                }
                arr = arr.OrderBy(u => u[0]).ToArray();
                oldArr = oldArr.OrderBy(u => u[0]).ToArray();

                IList<IList<int>> res = null;
                CodeTimerResult codeTimerResult = codeTimer.Time(1, () =>
                {
                    res = instance.Try3(arr);
                });

                ShowTools.ShowMulti(new Dictionary<string, object> {
                        {nameof(arr),oldArr },
                        {nameof(res),res },
                        {nameof(codeTimerResult),codeTimerResult },
                    });

                tools.Check(oldArr, res);

            }
        }

    }
}
