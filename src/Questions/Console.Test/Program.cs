using Command.CommonStruct;
using Command.Tools;
using Newtonsoft.Json;
using Questions.Hard.Deal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            CodeTimer codeTimer = new CodeTimer();

            codeTimer.Initialize();

            Random random = new Random();

            {

                Word_Ladder_II instance = new Word_Ladder_II();
                /*
                 * 
                 * 
"magic"
"pearl"
["flail","halon","lexus","joint","pears","slabs","lorie","lapse","wroth","yalow","swear","cavil","piety","yogis","dhaka","laxer","tatum","provo","truss","tends","deana","dried","hutch","basho","flyby","miler","fries","floes","lingo","wider","scary","marks","perry","igloo","melts","lanny","satan","foamy","perks","denim","plugs","cloak","cyril","women","issue","rocky","marry","trash","merry","topic","hicks","dicky","prado","casio","lapel","diane","serer","paige","parry","elope","balds","dated","copra","earth","marty","slake","balms","daryl","loves","civet","sweat","daley","touch","maria","dacca","muggy","chore","felix","ogled","acids","terse","cults","darla","snubs","boats","recta","cohan","purse","joist","grosz","sheri","steam","manic","luisa","gluts","spits","boxer","abner","cooke","scowl","kenya","hasps","roger","edwin","black","terns","folks","demur","dingo","party","brian","numbs","forgo","gunny","waled","bucks","titan","ruffs","pizza","ravel","poole","suits","stoic","segre","white","lemur","belts","scums","parks","gusts","ozark","umped","heard","lorna","emile","orbit","onset","cruet","amiss","fumed","gelds","italy","rakes","loxed","kilts","mania","tombs","gaped","merge","molar","smith","tangs","misty","wefts","yawns","smile","scuff","width","paris","coded","sodom","shits","benny","pudgy","mayer","peary","curve","tulsa","ramos","thick","dogie","gourd","strop","ahmad","clove","tract","calyx","maris","wants","lipid","pearl","maybe","banjo","south","blend","diana","lanai","waged","shari","magic","duchy","decca","wried","maine","nutty","turns","satyr","holds","finks","twits","peaks","teems","peace","melon","czars","robby","tabby","shove","minty","marta","dregs","lacks","casts","aruba","stall","nurse","jewry","knuth"]

                 */
                { // error
                    IList<IList<string>> lists = instance.Simple("magic", "pearl", new List<string>() { "flail", "halon", "lexus", "joint", "pears", "slabs", "lorie", "lapse", "wroth", "yalow", "swear", "cavil", "piety", "yogis", "dhaka", "laxer", "tatum", "provo", "truss", "tends", "deana", "dried", "hutch", "basho", "flyby", "miler", "fries", "floes", "lingo", "wider", "scary", "marks", "perry", "igloo", "melts", "lanny", "satan", "foamy", "perks", "denim", "plugs", "cloak", "cyril", "women", "issue", "rocky", "marry", "trash", "merry", "topic", "hicks", "dicky", "prado", "casio", "lapel", "diane", "serer", "paige", "parry", "elope", "balds", "dated", "copra", "earth", "marty", "slake", "balms", "daryl", "loves", "civet", "sweat", "daley", "touch", "maria", "dacca", "muggy", "chore", "felix", "ogled", "acids", "terse", "cults", "darla", "snubs", "boats", "recta", "cohan", "purse", "joist", "grosz", "sheri", "steam", "manic", "luisa", "gluts", "spits", "boxer", "abner", "cooke", "scowl", "kenya", "hasps", "roger", "edwin", "black", "terns", "folks", "demur", "dingo", "party", "brian", "numbs", "forgo", "gunny", "waled", "bucks", "titan", "ruffs", "pizza", "ravel", "poole", "suits", "stoic", "segre", "white", "lemur", "belts", "scums", "parks", "gusts", "ozark", "umped", "heard", "lorna", "emile", "orbit", "onset", "cruet", "amiss", "fumed", "gelds", "italy", "rakes", "loxed", "kilts", "mania", "tombs", "gaped", "merge", "molar", "smith", "tangs", "misty", "wefts", "yawns", "smile", "scuff", "width", "paris", "coded", "sodom", "shits", "benny", "pudgy", "mayer", "peary", "curve", "tulsa", "ramos", "thick", "dogie", "gourd", "strop", "ahmad", "clove", "tract", "calyx", "maris", "wants", "lipid", "pearl", "maybe", "banjo", "south", "blend", "diana", "lanai", "waged", "shari", "magic", "duchy", "decca", "wried", "maine", "nutty", "turns", "satyr", "holds", "finks", "twits", "peaks", "teems", "peace", "melon", "czars", "robby", "tabby", "shove", "minty", "marta", "dregs", "lacks", "casts", "aruba", "stall", "nurse", "jewry", "knuth" });

                    ShowTools.ShowLine(lists);

                }

                {
                    IList<IList<string>> lists = instance.Simple("flogs", "slaps", new List<string>() { "slogs", "flops", "flogs", "slags", "flaps", "slops", "flags", "slaps" });

                    ShowTools.ShowLine(lists);

                }

                {
                    IList<IList<string>> lists = instance.Simple("magic", "pearl", new List<string>() { "flail", "halon", "lexus", "joint", "pears", "slabs", "lorie", "lapse", "wroth", "yalow", "swear", "cavil", "piety", "yogis", "dhaka", "laxer", "tatum", "provo", "truss", "tends", "deana", "dried", "hutch", "basho", "flyby", "miler", "fries", "floes", "lingo", "wider", "scary", "marks", "perry", "igloo", "melts", "lanny", "satan", "foamy", "perks", "denim", "plugs", "cloak", "cyril", "women", "issue", "rocky", "marry", "trash", "merry", "topic", "hicks", "dicky", "prado", "casio", "lapel", "diane", "serer", "paige", "parry", "elope", "balds", "dated", "copra", "earth", "marty", "slake", "balms", "daryl", "loves", "civet", "sweat", "daley", "touch", "maria", "dacca", "muggy", "chore", "felix", "ogled", "acids", "terse", "cults", "darla", "snubs", "boats", "recta", "cohan", "purse", "joist", "grosz", "sheri", "steam", "manic", "luisa", "gluts", "spits", "boxer", "abner", "cooke", "scowl", "kenya", "hasps", "roger", "edwin", "black", "terns", "folks", "demur", "dingo", "party", "brian", "numbs", "forgo", "gunny", "waled", "bucks", "titan", "ruffs", "pizza", "ravel", "poole", "suits", "stoic", "segre", "white", "lemur", "belts", "scums", "parks", "gusts", "ozark", "umped", "heard", "lorna", "emile", "orbit", "onset", "cruet", "amiss", "fumed", "gelds", "italy", "rakes", "loxed", "kilts", "mania", "tombs", "gaped", "merge", "molar", "smith", "tangs", "misty", "wefts", "yawns", "smile", "scuff", "width", "paris", "coded", "sodom", "shits", "benny", "pudgy", "mayer", "peary", "curve", "tulsa", "ramos", "thick", "dogie", "gourd", "strop", "ahmad", "clove", "tract", "calyx", "maris", "wants", "lipid", "pearl", "maybe", "banjo", "south", "blend", "diana", "lanai", "waged", "shari", "magic", "duchy", "decca", "wried", "maine", "nutty", "turns", "satyr", "holds", "finks", "twits", "peaks", "teems", "peace", "melon", "czars", "robby", "tabby", "shove", "minty", "marta", "dregs", "lacks", "casts", "aruba", "stall", "nurse", "jewry", "knuth" });

                    ShowTools.ShowLine(lists);

                }

                {
                    IList<IList<string>> lists = instance.Simple("cet", "ism", new List<string>() { "kid", "tag", "pup", "ail", "tun", "woo", "erg", "luz", "brr", "gay", "sip", "kay", "per", "val", "mes", "ohs", "now", "boa", "cet", "pal", "bar", "die", "war", "hay", "eco", "pub", "lob", "rue", "fry", "lit", "rex", "jan", "cot", "bid", "ali", "pay", "col", "gum", "ger", "row", "won", "dan", "rum", "fad", "tut", "sag", "yip", "sui", "ark", "has", "zip", "fez", "own", "ump", "dis", "ads", "max", "jaw", "out", "btu", "ana", "gap", "cry", "led", "abe", "box", "ore", "pig", "fie", "toy", "fat", "cal", "lie", "noh", "sew", "ono", "tam", "flu", "mgm", "ply", "awe", "pry", "tit", "tie", "yet", "too", "tax", "jim", "san", "pan", "map", "ski", "ova", "wed", "non", "wac", "nut", "why", "bye", "lye", "oct", "old", "fin", "feb", "chi", "sap", "owl", "log", "tod", "dot", "bow", "fob", "for", "joe", "ivy", "fan", "age", "fax", "hip", "jib", "mel", "hus", "sob", "ifs", "tab", "ara", "dab", "jag", "jar", "arm", "lot", "tom", "sax", "tex", "yum", "pei", "wen", "wry", "ire", "irk", "far", "mew", "wit", "doe", "gas", "rte", "ian", "pot", "ask", "wag", "hag", "amy", "nag", "ron", "soy", "gin", "don", "tug", "fay", "vic", "boo", "nam", "ave", "buy", "sop", "but", "orb", "fen", "paw", "his", "sub", "bob", "yea", "oft", "inn", "rod", "yam", "pew", "web", "hod", "hun", "gyp", "wei", "wis", "rob", "gad", "pie", "mon", "dog", "bib", "rub", "ere", "dig", "era", "cat", "fox", "bee", "mod", "day", "apr", "vie", "nev", "jam", "pam", "new", "aye", "ani", "and", "ibm", "yap", "can", "pyx", "tar", "kin", "fog", "hum", "pip", "cup", "dye", "lyx", "jog", "nun", "par", "wan", "fey", "bus", "oak", "bad", "ats", "set", "qom", "vat", "eat", "pus", "rev", "axe", "ion", "six", "ila", "lao", "mom", "mas", "pro", "few", "opt", "poe", "art", "ash", "oar", "cap", "lop", "may", "shy", "rid", "bat", "sum", "rim", "fee", "bmw", "sky", "maj", "hue", "thy", "ava", "rap", "den", "fla", "auk", "cox", "ibo", "hey", "saw", "vim", "sec", "ltd", "you", "its", "tat", "dew", "eva", "tog", "ram", "let", "see", "zit", "maw", "nix", "ate", "gig", "rep", "owe", "ind", "hog", "eve", "sam", "zoo", "any", "dow", "cod", "bed", "vet", "ham", "sis", "hex", "via", "fir", "nod", "mao", "aug", "mum", "hoe", "bah", "hal", "keg", "hew", "zed", "tow", "gog", "ass", "dem", "who", "bet", "gos", "son", "ear", "spy", "kit", "boy", "due", "sen", "oaf", "mix", "hep", "fur", "ada", "bin", "nil", "mia", "ewe", "hit", "fix", "sad", "rib", "eye", "hop", "haw", "wax", "mid", "tad", "ken", "wad", "rye", "pap", "bog", "gut", "ito", "woe", "our", "ado", "sin", "mad", "ray", "hon", "roy", "dip", "hen", "iva", "lug", "asp", "hui", "yak", "bay", "poi", "yep", "bun", "try", "lad", "elm", "nat", "wyo", "gym", "dug", "toe", "dee", "wig", "sly", "rip", "geo", "cog", "pas", "zen", "odd", "nan", "lay", "pod", "fit", "hem", "joy", "bum", "rio", "yon", "dec", "leg", "put", "sue", "dim", "pet", "yaw", "nub", "bit", "bur", "sid", "sun", "oil", "red", "doc", "moe", "caw", "eel", "dix", "cub", "end", "gem", "off", "yew", "hug", "pop", "tub", "sgt", "lid", "pun", "ton", "sol", "din", "yup", "jab", "pea", "bug", "gag", "mil", "jig", "hub", "low", "did", "tin", "get", "gte", "sox", "lei", "mig", "fig", "lon", "use", "ban", "flo", "nov", "jut", "bag", "mir", "sty", "lap", "two", "ins", "con", "ant", "net", "tux", "ode", "stu", "mug", "cad", "nap", "gun", "fop", "tot", "sow", "sal", "sic", "ted", "wot", "del", "imp", "cob", "way", "ann", "tan", "mci", "job", "wet", "ism", "err", "him", "all", "pad", "hah", "hie", "aim", "ike", "jed", "ego", "mac", "baa", "min", "com", "ill", "was", "cab", "ago", "ina", "big", "ilk", "gal", "tap", "duh", "ola", "ran", "lab", "top", "gob", "hot", "ora", "tia", "kip", "han", "met", "hut", "she", "sac", "fed", "goo", "tee", "ell", "not", "act", "gil", "rut", "ala", "ape", "rig", "cid", "god", "duo", "lin", "aid", "gel", "awl", "lag", "elf", "liz", "ref", "aha", "fib", "oho", "tho", "her", "nor", "ace", "adz", "fun", "ned", "coo", "win", "tao", "coy", "van", "man", "pit", "guy", "foe", "hid", "mai", "sup", "jay", "hob", "mow", "jot", "are", "pol", "arc", "lax", "aft", "alb", "len", "air", "pug", "pox", "vow", "got", "meg", "zoe", "amp", "ale", "bud", "gee", "pin", "dun", "pat", "ten", "mob" });

                    ShowTools.ShowLine(lists);
                }

                {
                    IList<IList<string>> lists = instance.Simple("leet", "code", new List<string>() { "lest", "leet", "lose", "code", "lode", "robe", "lost" });

                    ShowTools.ShowLine(lists);
                }

                {

                    IList<IList<string>> lists = instance.Simple("qa", "sq", new List<string>() { "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye" });

                    ShowTools.ShowLine(lists);

                }
                {
                    IList<IList<string>> lists = instance.Simple("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" });

                    ShowTools.ShowLine(lists);
                }

                {
                    IList<IList<string>> lists = instance.Simple("hit", "cog", new List<string>() { "hot", "dot", "dog", "lot", "log" });

                    ShowTools.ShowLine(lists);
                }

            }

            { // unresolve

                //UnresolveTest.TestSolveSudoku();

            }

            Console.ReadKey(true);

            Console.WriteLine("Hello World!");
        }


        private static void TestBurst_Balloons()
        {
            Burst_Balloons instance = new Burst_Balloons();

            //[3,1,5,8,1,5] 350

            //Console.WriteLine(instance.Try(new[] { 3, 1, 5, 8 }));// 167 
            Console.WriteLine(instance.Try(new[] { 3, 1, 5, 8, 1, 5 }));// out 315 expected 350 
            Console.WriteLine(instance.Try(new[] { 3, 1, 8, 5, 1, 5 }));// out 315 expected 350 
        }

        private static void TestRemove_Invalid_Parentheses()
        {
            Remove_Invalid_Parentheses instnace = new Remove_Invalid_Parentheses();

            ShowTools.Show(instnace.Optimize("(r(()()("));// ["r()()","r(())","(r)()","(r())"]
            ShowTools.Show(instnace.Optimize("()((k()(("));// ["()k()","()(k)"]
            //ShowTools.Show(instnace.Optimize("a()())()()())())())()()())()"));
            ShowTools.Show(instnace.Optimize("()())()"));// ["()()()", "(())()"]
            ShowTools.Show(instnace.Optimize("(a)())()"));// ["(a)()()", "(a())()"]
            ShowTools.Show(instnace.Optimize(")("));// [""]
        }

        private static void TestFind_Median_from_Data_Stream()
        {
            //[[],[6],[],[10],[],[2],[],[6],[],[5],[],[0],[],[6],[],[3],[],[1],[],[0],[],[0],[]]
            Find_Median_from_Data_Stream instance = new Find_Median_from_Data_Stream();

            instance.AddNum(12);
            instance.AddNum(10);
            instance.AddNum(13);
            instance.AddNum(11);
            instance.AddNum(5);
            instance.AddNum(15);
            instance.AddNum(1);
            instance.AddNum(11);
            instance.AddNum(6);
            instance.AddNum(17);
            instance.AddNum(14);
            instance.AddNum(8);
            instance.AddNum(17);
            instance.AddNum(6);
            instance.AddNum(4);
            instance.AddNum(16);
            instance.AddNum(8);
            instance.AddNum(10);
            instance.AddNum(2);
            instance.AddNum(12);
            //instance.AddNum(0);
            Console.WriteLine(instance.FindMedian());
        }

        private static void TestExpression_Add_Operators()
        {
            Expression_Add_Operators instance = new Expression_Add_Operators();

            ShowTools.Show(instance.Simple("232", 8));
        }

        private static void TestSliding_Window_Maximum()
        {
            Sliding_Window_Maximum instance = new Sliding_Window_Maximum();

            ShowTools.Show(instance.Simple(new[] { 1 }, 1));
            ShowTools.Show(instance.Simple(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3));
        }

        private static void TestBasic_Calculator()
        {
            Basic_Calculator instance = new Basic_Calculator();

            //Console.WriteLine(instance.Solution("1 + 1")); // 2
            //Console.WriteLine(instance.Solution(" 2-1 + 2 "));// 3
            //Console.WriteLine(instance.Solution("(1+(4+5+2)-3)+(6+8)"));// 23
            //Console.WriteLine(instance.Solution("1 - (2 + 3 + (1 + 2))"));// -7
        }

        private static void TestShortestPalindrome(Random random)
        {
            ShortestPalindrome instance = new ShortestPalindrome();

            //instance.IsDebug = true;

            ShowTools.ShowIndex("bbacabbacabbabbcacabcabcccccaaaabccba");

            Console.WriteLine(instance.Simple("bbacabbacabbabbcacabcabcccccaaaabccba"));
            Console.WriteLine(instance.Solution("bbacabbacabbabbcacabcabcccccaaaabccba"));

            Console.WriteLine(instance.Simple("cabcbacbacaccaaaacacaabcba"));
            Console.WriteLine(instance.Solution("cabcbacbacaccaaaacacaabcba"));

            Console.WriteLine(instance.Simple("cacbcccbcbcacaacbccabcbaacabbbcbbaccbbc"));
            Console.WriteLine(instance.Solution("cacbcccbcbcacaacbccabcbaacabbbcbbaccbbc"));

            Console.WriteLine(instance.Simple("bcbbbcccaabbbcaaaba"));
            Console.WriteLine(instance.Solution("bcbbbcccaabbbcaaaba"));

            Console.WriteLine(instance.Simple("aaaacdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
            Console.WriteLine(instance.Solution("aaaacdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));

            Console.WriteLine(instance.Simple("aabba"));
            Console.WriteLine(instance.Solution("aabba"));

            Console.WriteLine(instance.Simple("aacecaaa"));
            Console.WriteLine(instance.Solution("aacecaaa"));

            Console.WriteLine(instance.Simple("abcd"));
            Console.WriteLine(instance.Solution("abcd"));
            Console.ReadKey(true);
            for (int i = 0; i < 100000; i++)
            {
                StringBuilder builder = new StringBuilder();

                var len = random.Next(40000);

                for (int j = 0; j < len; j++)
                {
                    builder.Append((char)('a' + random.Next(3)));
                }

                var real = instance.Simple(builder.ToString());
                var res = instance.Solution(builder.ToString());

                ShowTools.ShowMulti(new System.Collections.Generic.Dictionary<string, object>() {
                    {nameof(builder),builder },
                    {nameof(real),real },
                    {nameof(res),res },
                });

                if (real != res) throw new Exception();

            }
        }

        private static void TestWordSearchII()
        {
            WordSearchII instance = new WordSearchII();

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['a','b'],['a','a']]")
                , new[] { "aba", "baa", "bab", "aaab", "aaa", "aaaa", "aaba" }));

            ShowTools.Show(instance.Simple(JsonConvert.DeserializeObject<char[][]>("[['b','b','a','a','b','a'],['b','b','a','b','a','a'],['b','b','b','b','b','b'],['a','a','a','b','a','a'],['a','b','a','a','b','b']]")
                , new[] { "abbbababaa" }));

            Console.WriteLine("success");
        }

        private static void TestDungeon_Game(Random random)
        {
            Dungeon_Game instance = new Dungeon_Game();

            instance.IsDebug = true;

            //Console.WriteLine(instance.Solution(JsonConvert.DeserializeObject<int[][]>("[[2,-7,-8,-16,-19,-19,-12,-19,-20,-27,-21,-16,-8,-12],[-3,-9,0,-9,-1,-6,-3,-13,-23,-16,-22,-14,-20,-20],[-5,-3,-10,-12,-6,-10,-6,-15,-14,-5,3,0,-7,-16],[1,-1,4,-3,4,7,16,6,8,-2,-7,-9,-4,-3],[-8,0,11,9,5,4,21,28,21,20,19,20,28,21],[-5,8,3,9,0,5,15,30,22,13,9,20,28,25],[-15,17,9,3,6,12,5,39,31,30,20,26,24,34],[-20,12,15,10,15,20,17,42,49,53,43,35,32,33]]")));// 7

            //Console.WriteLine(instance.Solution(JsonConvert.DeserializeObject<int[][]>("[[3,5,5,11,19,19,23,16,9,-1,1],[-6,5,2,8,17,23,15,24,26,35,38],[-4,0,5,3,12,15,14,25,35,40,45],[-4,7,13,7,10,7,16,26,39,45,53],[4,7,16,3,19,24,15,33,42,53,48],[13,16,11,3,21,19,20,36,43,44,55],[8,6,11,9,25,21,30,32,33,38,62],[11,2,4,11,33,26,34,34,25,30,69],[5,9,12,10,28,28,30,43,33,26,76],[-4,3,15,21,28,18,34,51,47,54,67],[-12,-2,23,32,37,33,32,60,51,44,72],[-14,3,25,31,32,23,31,69,59,52,75]]")));// 1

            //Console.WriteLine(instance.Solution(new[] {
            //    new []{ -2, -3, 3 },
            //     new []{ -5,-10,1 },
            //      new []{ 10,30,-5 },
            //}));// 7

            Console.WriteLine(instance.DpSolution3(JsonConvert.DeserializeObject<int[][]>("[[-2,-3,3],[-5,-10,1],[10,30,-5]]")));// 3

            Console.ReadKey(true);

            for (int i = 0; i < 10; i++)
            {
                int m = random.Next(200) + 2, n = random.Next(200) + 4;

                int[][] dungeon = new int[m][];
                for (int j = 0; j < m; j++)
                {
                    dungeon[j] = new int[n];
                    for (int k = 0; k < n; k++)
                    {
                        dungeon[j][k] = random.Next(-20, 5);
                    }
                }

                ShowTools.Show(dungeon);

                var res = instance.Solution((int[][])dungeon.Clone());

                ShowTools.ShowMulti(new System.Collections.Generic.Dictionary<string, object>() {
                    {nameof(res),res }
                });

            }
        }
    }
}