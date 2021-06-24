using Command.Tools;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/26/2020 9:43:54 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestRemove_Invalid_ParenthesesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Remove_Invalid_Parentheses instnace = new Remove_Invalid_Parentheses();

            ShowTools.Show(instnace.Optimize("(r(()()("));// ["r()()","r(())","(r)()","(r())"]
            ShowTools.Show(instnace.Optimize("()((k()(("));// ["()k()","()(k)"]
            //ShowTools.Show(instnace.Optimize("a()())()()())())())()()())()"));
            ShowTools.Show(instnace.Optimize("()())()"));// ["()()()", "(())()"]
            ShowTools.Show(instnace.Optimize("(a)())()"));// ["(a)()()", "(a())()"]
            ShowTools.Show(instnace.Optimize(")("));// [""]
        }
    }
}
