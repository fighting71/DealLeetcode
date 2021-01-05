using Command.Tools;
using Newtonsoft.Json;
using Questions.DailyChallenge._2021.January;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.January
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/5/2021 5:37:47 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRemove_Duplicates_from_Sorted_List_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Remove_Duplicates_from_Sorted_List_II instance = new Remove_Duplicates_from_Sorted_List_II();
            if (runSimple)
            {

                var argArr = new[]
                {
                        "[1,2,3,3,4,4,5]",
                        "[1,1,1,2,3]"
                    };

                foreach (var arg in argArr)
                {
                    ShowTools.Show(instance.DeleteDuplicates(JsonConvert.DeserializeObject<int[]>(arg)));
                }

            }
            else { }
        }
    }
}
