using Command.Helper;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Todo
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/5/2021 6:00:55 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestStrange_PrinterDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Strange_Printer instance = new Strange_Printer();

            BaseLibrary.CommonTest(new[] {
                    "hhaecdghfcfhjgehdfbh",// 13
                    "hhaecdghfcfhjgehdfb",// 13
                    "hhaecdghfcfhjgehd",// 11
                    "hhaecdghfcfhjgeh",// 10
                    "hhaecdghfcfhjge",// 10
                    "hhaecdghfcfh",// 8
                    "hhaecdgh",// 6
                    "aaabbb",// 2
                    "aba",// 2
                    "k{agbgjmen{mwiwbqrjqvokjijocvmnyisnvesexrxifdentxncmiaoxqsztthrs{beevayymmzzffgewvfijbqhdrfmumekfqfb",// 69
                }
            , instance.Try2
            , () => CollectionHelper.GetString(100, () => (char)(random.Next(10) + 'a'))
            );

        }
    }
}
