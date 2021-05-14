using Questions.DailyChallenge._2021.May.Week1;
using System;
using System.Collections.Generic;
using System.Text;
using Command.Extension;

namespace ConsoleTest.TestDemo.Challenge._2021.May
{
    /// <summary>
    /// @auth : monster
    /// @since : 5/14/2021 5:58:39 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestPrefix_and_Suffix_SearchDemo : BaseDemo, IWork
    {
        public void Run()
        {

            { // test 1 [null,9,4,5,0,8,1,2,5,3,1]
              //string[][] json = "[[\"bccbacbcba\", \"a\"], 	[\"ab\", \"abcaccbcaa\"], 	[\"a\", \"aa\"], 	[\"cabaaba\", \"abaaaa\"], 	[\"cacc\", \"accbbcbab\"], 	[\"ccbcab\", \"bac\"], 	[\"bac\", \"cba\"], 	[\"ac\", \"accabaccaa\"], 	[\"bcbb\", \"aa\"], 	[\"ccbca\", \"cbcababac\"] ]".ParseJson<string[][]>();

                ////Prefix_and_Suffix_Search.Base instance = new Prefix_and_Suffix_Search.Try(new[] {"appaple", "apple"});
                //Prefix_and_Suffix_Search.Base instance = new Prefix_and_Suffix_Search.Try(new[] { "cabaabaaaa", "ccbcababac", "bacaabccba", "bcbbcbacaa", "abcaccbcaa", "accabaccaa", "cabcbbbcca", "ababccabcb", "caccbbcbab", "bccbacbcba" });

                //foreach (var item in json)
                //{
                //    Console.WriteLine(instance.F(item[0], item[1]));
                //}
            }
            {// test 2
             //string[] init = LargeData_File.Large.ParseJson<string[]>();
             //Prefix_and_Suffix_Search.Base instance = new Prefix_and_Suffix_Search.Try(init);

                //string[][] json = LargeData_File.Large2.ParseJson<string[][]>();
                //for (int i = 0; i < json.Length; i++)
                //{
                //    var item = json[i];
                //    int res = instance.F(item[0], item[1]);

                //    int real = LargeData_File.res[i];

                //    if(res != real)
                //    {
                //        if(real >= 0)
                //            Console.WriteLine(init[real]);
                //        if(res >= 0)
                //            Console.WriteLine(init[res]);
                //    }

                //}
            }
            { // test3
                string[] init = LargeData_File.Init2;
                Prefix_and_Suffix_Search.Try instance = new Prefix_and_Suffix_Search.Try(init);

                string[][] json = LargeData_File.Arg2.ParseJson<string[][]>();
                for (int i = 0; i < json.Length; i++)
                {
                    var item = json[i];
                    int res = instance.F(item[0], item[1]);

                    int real = LargeData_File.res[i];

                    if (res != real)
                    {
                        if (real >= 0)
                            Console.WriteLine(init[real]);
                        if (res >= 0)
                            Console.WriteLine(init[res]);
                    }

                }
            }



        }
    }
}
