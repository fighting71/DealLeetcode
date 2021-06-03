using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/2/2021 3:06:40 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCount_Unique_Characters_of_All_Substrings_of_a_Given_StringDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Count_Unique_Characters_of_All_Substrings_of_a_Given_String instance = new Count_Unique_Characters_of_All_Substrings_of_a_Given_String();

            BaseLibrary.CommonTest(new[] {
                    "VEICQD",// 
                    "VEICQDN",// 
                    "VEICQDNN",// 
                    "VEICQDNNN",// 
                    "VEICQDNNNB",// 
                    "LEE",// 
                    "LEET",// 
                    "LEETC",// 
                    "LEETCO",// 
                    "LEETCOD",// 
                    "LEETCODE",// 92
                    "BIB",// 
                    "BIBF",// 
                    "BIBFO",// 
                    "CXVXVZAYFO",// 
                    "LEE",// 6
                    "ABA",// 8
                    "ABC",// 10
                }
            , instance.Optimize
            //, () => CollectionHelper.GetString(10, 'A')
            , () => CollectionHelper.GetString(10_0000, 'A')
            , checkFunc: instance.Try4
            , showArg: false
            , showRes: false
            , codeTimeCount: 20
            );

        }
    }
}
