using Command.Helper;
using Command.Tools;
using Questions.Hard.Deal3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.TestDemo.Hard
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/30/2021 12:26:56 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestStickers_to_Spell_WordDemo : BaseDemo, IWork
    {
        public void Run()
        {
            Stickers_to_Spell_Word instance = new Stickers_to_Spell_Word();

            //                ["slave","doctor","kept","insect","an","window","she","range","post","guide"]
            //"supportclose"

            BaseLibrary.CommonTest(new[] {
                    (new [] { "slave","doctor","kept","insect","an","window","she","range","post","guide" }, "supportclose"), // 5
                    (new [] { "with", "example", "science" }, "thehat"), // 3
                    (new [] { "notice", "possible" }, "basicbasic"), // -1
                    (new [] { "these","guess","about","garden","him" }, "atomher"), // 3
                }
            , arg => instance.OtherSolution(arg.Item1, arg.Item2)
            , generateArg: () => (
                CollectionHelper.GetEnumerable(50, () => CollectionHelper.GetString(10, () => (char)('a' + random.Next(26)))).ToArray(),
                CollectionHelper.GetString(15, () => (char)('a' + random.Next(26)))
                )
            , formatArg: arg => $"{ShowTools.GetStr(arg.Item1)}\n\"{arg.Item2}\""
            //, checkFunc: arg => instance.Try4(arg.Item1, arg.Item2)
            );

        }
    }
}
