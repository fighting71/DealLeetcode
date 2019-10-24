using System;

namespace Questions.Easy.Concurrency
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/8/23 10:53:52
    /// @source : 
    /// @des : 
    /// </summary>
    public class PrintInOrder
    {
        /**
         * Runtime: 232 ms, faster than 35.26% of C# online submissions for Print in Order.
         * Memory Usage: 23 MB, less than 100.00% of C# online submissions for Print in Order.
         */
        //private volatile int state = 0;

        private Action[] _actions = new Action[3];
        private object _lockObj = new object();

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
//            printFirst();
//            state = 1;
            Run(printFirst, 0);
        }

        public void Second(Action printSecond)
        {
//            while(state <= 0)
//            {
//                Thread.Yield();
//            }
            Run(printSecond, 1);
        }

        public void Third(Action printThird)
        {
            Run(printThird, 2);
        }

        /**
         * Runtime: 116 ms, faster than 86.63% of C# online submissions for Print in Order.
         * Memory Usage: 23 MB, less than 100.00% of C# online submissions for Print in Order.
         */
        protected void Run(Action action, int index)
        {
            lock (_lockObj)
            {
                bool canRun = true;
                for (int i = 0; i < index; i++)
                {
                    if (_actions[i] == null)
                    {
                        canRun = false;
                        break;
                    }
                }

                _actions[index] = action;

                if (canRun)
                {
                    for (int i = index; i < _actions.Length; i++)
                    {
                        if (_actions[i] == null) break;
                        _actions[i]();
                    }
                }
            }
        }
    }
}