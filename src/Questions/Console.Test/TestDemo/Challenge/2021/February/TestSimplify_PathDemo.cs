using Questions.DailyChallenge._2021.February.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.February
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/5/2021 6:39:51 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSimplify_PathDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Simplify_Path instance = new Simplify_Path();

            BaseLibrary.CommonTest(new[] {
                    "/..hidden",
                    "/.../",
                    "/home/",
                    "/../",
                    "/home/foo",
                    "/a/./b/../../c/"
                }, instance.SimplifyPath);

        }
    }
}
