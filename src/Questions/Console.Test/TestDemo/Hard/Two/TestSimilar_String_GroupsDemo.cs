using Command.Helper;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Hard.Two
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/23/2021 2:12:13 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestSimilar_String_GroupsDemo : BaseDemo, IWork
    {
        public void Run()
        {

            Similar_String_Groups instance = new Similar_String_Groups();

            BaseLibrary.CommonTest(new[] {
                    new []{"ufixvnxsdxalinayfaappbmmj","nxpxiaauvyjxasbfmfinmdpla","ujimiyxsaxpavnanfapmlbxdf","ufimvyxsaxpainanfapdlbxmj","nxpyajaumxixalbfvpdnmasfi","nxpxiaauvyjxpsbfmfinmdala","ufimvyxspxaainanfapdlbxmj","nxpyaiaumxjxapbfvlanmdsfi","ufimvyxspxapinanfaadlbxmj","nxpyaaauvxjxasbfmfinmdpli","nxpyajaumxixapbfvlanmdsfi","nxpyaaaumxjxasbfvfinmdpli","ufixvnbsdxalinayfamppxamj","ujimvyxsaxpainanfapdlbxmf","ufixvyxsdxalinanfaappbmmj","nxpyaaaumxjxapbfvlinmdsfi","ufixvyxspxalinanfaadpbmmj","nxpyaaaumxjxasbfvlinmdpfi","ufixvyxspxapinanfaadlbmmj","ufixvnbsdxalinayfaappxmmj","ufiavnbsdxxlinayfamppxamj","nxpyajaumxixapbfvldnmasfi","ufiavnbsdxxlinayfamppxajm","nxpyiaauvxjxasbfmfinmdpla","ujimiyxsaxpavnanfapdlbxmf"},//2
                    new []{"zkhnmefhyr","ykznfhehmr","mkhnyefrzh","zkhnyefrmh","zkmnhefhyr","ykznhfehmr","zkynhfehmr","mkhnhefrzy","zkhnmefryh","zkmnhfehyr"},//1
                    new []{"kccomwcgcs","socgcmcwkc","sgckwcmcoc","coswcmcgkc","cowkccmsgc","cosgmccwkc","sgmkwcccoc","coswmccgkc","kowcccmsgc","kgcomwcccs"},//5
                    new []{"blw","bwl","wlb"},//1
                    new []{"blw", "blw"},//1
                    new []{"omv","ovm"},//1
                    new []{"tars","rats","arts","star"},//2
                }
            , instance.Try4
            //, instance.Simple2
            //, () => CollectionHelper.GetEnumerable(300, () => CollectionHelper.GetString(300, 'a', 5)).ToArray()
            , () => // 产生极其相似的项.
            {
                string str = CollectionHelper.GetString(300, 'a', 26);

                var list = new List<string>() { str };

                ISet<(int, int)> set = new HashSet<(int, int)>();

                for (int i = 0; i < 299; i++)
                {
                    var arr = str.ToCharArray();

                    int randIndex, randIndex2;

                    while (true)
                    {
                        randIndex = random.Next(str.Length);
                        randIndex2 = random.Next(str.Length);

                        (int randIndex, int randIndex2) key;

                        if (randIndex > randIndex2)
                        {
                            key = (randIndex, randIndex2);
                        }
                        else
                        {
                            key = (randIndex2, randIndex);
                        }

                        if (set.Add(key)) break;

                    }

                    var t = arr[randIndex];
                    arr[randIndex] = arr[randIndex2];
                    arr[randIndex2] = t;
                    list.Add(new string(arr));
                }

                return list.ToArray();

            }
            , showArg: false
            , skipFunc: res => res == 0
            );

        }
    }
}
