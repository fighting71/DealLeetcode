using Command.Helper;
using Command.Tools;
using ConsoleTest.LargeData;
using Questions.DailyChallenge._2021.March.Week4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.March
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/22/2021 6:57:22 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestVowel_SpellcheckerDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Vowel_Spellchecker instance = new Vowel_Spellchecker();

            //ShowTools.Show(instance.Simple(new[] { "KiTe", "kite", "hare", "Hare" }, new[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" }));
            {
                string[] wordlist = LargeArray.Get<string[]>("large_data/str/arr4.txt");
                string[] queries = LargeArray.Get<string[]>("large_data/str/arr5.txt");
                string[] answer = instance.Try(wordlist, queries);

                string[] real = LargeArray.Get<string[]>("large_data/str/arr6.txt");

                for (int i = 0; i < answer.Length; i++)
                {
                    string a = answer[i], r = real[i];
                    if (a != r)
                    {
                        Console.WriteLine($"currW:{queries[i]} diff:{a}_{Array.IndexOf(wordlist, a)}, {r}_{Array.IndexOf(wordlist, r)}");
                    }
                }
            }

            BaseLibrary.CommonTest(
                new[]
                {
                        //(new[] { "KiTe", "kite", "hare", "Hare" }, new[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" }),
                        (new[] { "aHaaKQa","aVaaQNS","THaaaaR","RaaaQOL", "aaaaaBa" }, new[] {"aaCIWOa","aaLNaaI","aaaaUBa" }),
                }
                , arg => instance.Try(arg.Item1, arg.Item2)
                , generateArg: () => (
                    CollectionHelper.GetEnumerable(5000, () => CollectionHelper.GetString(7, () => (char)(random.Next(2) == 0 ? 'a' : 'A' + random.Next(26)))).ToArray(),
                    CollectionHelper.GetEnumerable(5000, () => CollectionHelper.GetString(7, () => (char)(random.Next(2) == 0 ? 'a' : 'A' + random.Next(26)))).ToArray()
                )
                , showArg: false
                , showRes: false
                , formatArg: arg => $"{ShowTools.GetStr(arg.Item1)}\n{ShowTools.GetStr(arg.Item2)}"
            );

        }

    }
}
