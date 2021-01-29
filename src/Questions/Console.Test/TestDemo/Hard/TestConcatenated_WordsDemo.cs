using Command.Helper;
using ConsoleTest.LargeData;
using Questions.Hard.Deal2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/26/2021 4:03:08 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestConcatenated_WordsDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Concatenated_Words instance = new Concatenated_Words();

            BaseLibrary.CommonTest(new[] {
                    new []{  "cats", "dog", "dogcatsdog" },
                    LargeArray.Arr3,
                    //new []{ "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" },
                    //new []{ "cat","dog","catdog" },
                }, instance.findAllConcatenatedWordsInADict, () => CollectionHelper.GetEnumerable(1000_0, () => CollectionHelper.GetString(random.Next(1000), () => (char)('a' + random.Next(26)))).ToHashSet().ToArray(), showArg: false);

        }
    }
}
