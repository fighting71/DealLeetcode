using Command.Helper;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.March.Week3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.March
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/19/2021 5:31:39 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestKeys_and_RoomsDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Keys_and_Rooms instance = new Keys_and_Rooms();

            int len = 100;

            BaseLibrary.CommonTest(new[] {
                        JsonConvert.DeserializeObject<IList<IList<int>>>("[[1],[2],[3],[]]"), // t
                        JsonConvert.DeserializeObject<IList<IList<int>>>("[[1,3],[3,0,1],[2],[0]]"), // f
                    }
                , instance.CanVisitAllRooms
                , generateArg: () => CollectionHelper.GetEnumerable(len, () => (CollectionHelper.GetEnumerable(random.Next(len / 3), () => random.Next(len))).ToList() as IList<int>).ToList()
                , skipFunc: res => !res
            );

        }

    }
}
