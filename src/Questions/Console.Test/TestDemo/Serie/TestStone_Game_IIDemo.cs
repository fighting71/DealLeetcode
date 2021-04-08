using Command.Tools;
using Questions.Series.Dp.Stone_Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Serie
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/6/2021 2:38:14 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestStone_Game_IIDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Stone_Game_II instance = new Stone_Game_II();
            ShowTools.Show(instance.Simple(new[] { 8, 6, 9, 1, 7, 9 }));// 25
            ShowTools.Show(instance.Simple(new[] { 1, 2, 3, 4, 5, 100 }));// 104
            ShowTools.Show(instance.Simple(new[] { 2, 7, 9, 4, 4 }));// 10
        }
    }
}
