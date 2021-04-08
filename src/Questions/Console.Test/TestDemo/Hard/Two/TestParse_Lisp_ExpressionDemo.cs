using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/7/2021 10:08:59 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestParse_Lisp_ExpressionDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Parse_Lisp_Expression instance = new Parse_Lisp_Expression();

            var realRes = new[] { -2, -12, 6, 5, 12, 3, 15, 10, 2, 5, 4, 14 };
            int i = 0;

            BaseLibrary.CommonTest(new[] {
                    "(let x -2 y x y)", // -2
                    "(let x 7 -12)", // -12
                    "(let x 2 (add (let x 3 (let x 4 x)) x))", // 6
                    "(let x 1 y 2 x (add x y) (add x y))", // 5
                    "12", // 12
                    "(add 1 2)", // 3
                    "(mult 3 (add 2 3))", // 15
                    "(let x 2 (mult x 5))", // 10
                    "(let x 3 x 2 x)", // 2
                    "(let x 1 y 2 x (add x y) (add x y))", // 5
                    "(let a1 3 b2 (add a1 1) b2)", // 4
                    "(let x 2 (mult x (let x 3 y 4 (add x y))))", // 14
                }
            , instance.Evaluate
            , checkFunc: arg => {
                return realRes[i++];
            }
            );

        }
    }
}
