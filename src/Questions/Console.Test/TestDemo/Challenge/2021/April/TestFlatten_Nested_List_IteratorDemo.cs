using Questions.DailyChallenge._2021.April.Week2;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.April
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/14/2021 11:25:55 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestFlatten_Nested_List_IteratorDemo : BaseDemo, IWork
    {
        public void Run()
        {

            // [[1,2],[3],[4,5,6]]

            Flatten_Nested_List_Iterator.NestedIterator instance = new Flatten_Nested_List_Iterator.NestedIterator(new List<NestedInteger> {

                    new CusNestedInteger(1),
                    new CusNestedInteger(new List<NestedInteger>(){
                        new CusNestedInteger(4),
                        new CusNestedInteger(new List<NestedInteger>(){
                            new CusNestedInteger(6),
                        })
                    })

                });

            Show();

            instance = new Flatten_Nested_List_Iterator.NestedIterator(new List<NestedInteger> {
                    new CusNestedInteger(new List<NestedInteger>(){
                        new CusNestedInteger(1),
                        new CusNestedInteger(2),
                    }),
                    new CusNestedInteger(3),
                    new CusNestedInteger(new List<NestedInteger>(){
                        new CusNestedInteger(4),
                        new CusNestedInteger(5),
                        new CusNestedInteger(6),
                    }),

                });

            Show();

            void Show()
            {
                Console.WriteLine("-------------------------");
                while (instance.HasNext())
                {
                    Console.WriteLine(instance.Next());
                }
            }

        }
    }
}
