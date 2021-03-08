using Questions.DailyChallenge._2021.March.Week1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.TestDemo.Challenge._2021.February
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/8/2021 3:10:54 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public class TestDesign_HashMapDemo : BaseDemo, IWork
    {
        public void Run()
        {
            {
                Design_HashMap hashMap = new Design_HashMap();
                hashMap.put(3, 1);
                hashMap.put(5, 2);
                hashMap.put(2, 2);
            }
            { // test case
                Design_HashMap hashMap = new Design_HashMap();
                hashMap.put(1, 1);
                hashMap.put(2, 2);
                hashMap.get(1);            // returns 1
                hashMap.get(3);            // returns -1 (not found)
                hashMap.put(2, 1);          // update the existing value
                hashMap.get(2);            // returns 1 
                hashMap.remove(2);          // remove the mapping for 2
                hashMap.get(2);            // returns -1 (not found) 
            }

        }
    }
}
