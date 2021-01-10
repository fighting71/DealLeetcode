using Command.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    /// <summary>
    /// @auth : monster
    /// @since : 1/8/2021 2:56:35 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class BaseLibrary
    {
        public static CodeTimer CodeTimer { get; }
        static BaseLibrary()
        {
            CodeTimer = new CodeTimer();
            CodeTimer.Initialize();
        }

        public static void CommonTest<TArg, TRes>(TArg[] argArr, Func<TArg, TRes> func, Func<TArg> generateArg = null, int codeTimeCount = 10, bool showArg = true)
        {
            foreach (var arg in argArr)
            {
                Console.WriteLine(func(arg));
            }

            Console.WriteLine("是否运行测速?n-否");

            string input = Console.ReadLine();

            if (input.Contains("n")) return;

            if (generateArg == null)
            {
                Console.WriteLine($"{nameof(generateArg)}未定义！");
                return;
            }

            for (int i = 0; i < codeTimeCount; i++)
            {

                TArg arg = generateArg();
                TRes res = default;

                CodeTimerResult codeTimerResult = CodeTimer.Time(1, () => { res = func(arg); });
                Dictionary<string, object> mul = new Dictionary<string, object>() {
                            {nameof(res),res },
                            {nameof(codeTimerResult),codeTimerResult },
                        };
                if (showArg) mul[nameof(arg)] = arg;
                ShowTools.ShowMulti(mul);
            }
        }

        public static void CommonTest<TArg, TRes>(TArg[] argArr, Func<TArg, TRes> func, Func<TArg, TRes> checkFunc, Func<TArg> generateArg = null, int codeTimeCount = 10, bool showArg = true)
        {
            foreach (var arg in argArr)
            {
                TRes res = func(arg), real = checkFunc(arg);
                if(res.Equals(real))
                    Console.WriteLine(res);
                else
                {
                    ShowTools.ShowMulti(new Dictionary<string, object>() {
                            {nameof(res),res },
                            {nameof(real),real } 
                    });
                }
            }

            Console.WriteLine("是否运行测速?n-否");

            string input = Console.ReadLine();

            if (input.Contains("n")) return;

            if (generateArg == null)
            {
                Console.WriteLine($"{nameof(generateArg)}未定义！");
                return;
            }

            for (int i = 0; i < codeTimeCount; i++)
            {

                TArg arg = generateArg();
                TRes res = default;

                CodeTimerResult codeTimerResult = CodeTimer.Time(1, () => { res = func(arg); });
                Dictionary<string, object> mul = new Dictionary<string, object>() {
                            {nameof(res),res },
                            {nameof(codeTimerResult),codeTimerResult },
                        };
                if (showArg) mul[nameof(arg)] = arg;
                ShowTools.ShowMulti(mul);
            }
        }

    }
}
