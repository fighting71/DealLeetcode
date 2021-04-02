using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/1/2021 2:26:49 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestCount_Different_Palindromic_SubsequencesDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Count_Different_Palindromic_Subsequences instance = new Count_Different_Palindromic_Subsequences();

            BaseLibrary.CommonTest(new[] {
                    "aabaa", // 7
                    "a",
                    "aba",
                    "cabac",
                    "dcabacd",
                    "ada",//4
                    "bccb",//6
                    "abdba",//10
                    "abcdcba",//22
                    "abcdabcdabcdabcdabcdabcdabcdabcddcbadcbadcbadcbadcbadcbadcbadcba",//104860361
                "aadadddbcaabdbacbbacaccbbbcbccaacacdcbccbdcddaadcbadbbcccccbbbddaaddcbadcbaadcbabcdbcacabaaacbbaacddbabbbaaaabcdacdccbbdbcbcadbbdaabccdabcabdcdacaaacdbdaabcddabddbabaacccadbaddcbdddbcdcbacabbcbccdbdccdbcdccbaacdbdaccabbadcbabcbccabccbdbddbaddbcbdcbadcdcccbabbaaccaabdcaadbaaadacdbdaccbbaddcabcbaabbbaaaadabdbccbcbdadaadcaddcdbccaaccadbdacbdcdbabcacababcddbbcddcabcdcbccbdbcaabbcabbaccdbabddbbccabbdadbbadbcccdcacbcbcccccbddcdbcddddbbbddacbbcccadcdaabcdbccbcbdadccddcbacccabadcbdcabcdbaadcccbccabdacbabcbcdcbacdaccdcadadcccbaaabadacdbbdcbaccddacccddcaaddccdbacdaabcbabadddcbaddcccbabccacadddbacdbcbbbbbcddbbccdcbcbacccdcdacbabcdcdbcabbdbcdacdcdbcddcacdbdbadbdbdbddcdaadbaaddddccdbbdbbabababaacbbadcbbcddbacacdbcbccadacdadcdcaaccbcddabcbdabbbbbccdcdababdacddaaddbbabcaadcadbbdbbbdbbcbdccdaddcdabbdabbadcdcbadcbaccaccbabcdcabadadadabaadcdcccbcbccaacbdacdcbbcbdcabddadcbbdccbdbabbcddcbacbcbcbdcddbddcbdccbbacadababcddcacadaaddadcbbbacdcabadddacaabcdaacdabcccccbbacccabbacbcacbccddcbdbbccabbdcdbbccbabddad",//104860361
                }
            , instance.Try4
            //, checkFunc: instance.Simple
            , generateArg: () => CollectionHelper.GetString(1000, () => (char)('a' + random.Next(4)))
            );

        }
    }
}
