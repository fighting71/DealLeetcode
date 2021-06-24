using Command.Helper;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/16/2021 4:24:20 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestDecode_Ways_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Decode_Ways_II instance = new Decode_Ways_II();

            BaseLibrary.CommonTest(new[] {
                    "1203", // 0
                    "9560", // 0
                    "9*06", // 2
                    "*472", // 11
                    "*241", // 20
                    "*", // 9
                    "1*", // 18
                    "2*", // 15
                    "922*124*256516554069194*74**3427*89**977*678488*7585991*93382579296376564*952659702868917*175945*956", // 0
                    "6667838*2129112284*7842416624931**834957883320*4686492213161855381913*9**39*1*106177392886*233923*51", // 150342169
                }, instance.DpSolution2
            , generateArg: () => CollectionHelper.GetString(1000_00, () =>
            {
                int rand = random.Next(2) + 1;
                if (rand == 10) return '*';
                return (char)(rand + '0');
            })
            //, skipFunc: res => res == 0
            , codeTimeCount: 100
            //, showRes: false
            , showArg: false
            //, checkFunc: instance.DpSolution
            );

        }
    }
}
