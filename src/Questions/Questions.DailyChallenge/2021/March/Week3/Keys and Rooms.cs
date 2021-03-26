using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/19/2021 4:43:16 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3677/
    /// @des : 
    /// 
    /// 给定一组房间 rooms
    ///     每个房间内都放置着一组钥匙 keys
    ///     钥匙0 可打开第一个房间，钥匙1 可打开第二个房间，以此类推
    ///     
    /// base case:
    ///     第一个门是打开的，无需钥匙即可进入
    ///    
    /// target:
    ///     能否打开所有的门.
    /// 
    /// </summary>
    public class Keys_and_Rooms
    {

        // 1 <= rooms.length <= 1000
        //0 <= rooms[i].length <= 1000
        //The number of keys in all rooms combined is at most 3000.

        // Your runtime beats 74.63 % 
        public bool Solution2(IList<IList<int>> rooms)
        {

            int count = rooms.Count;
            bool[] visited = new bool[count];

            Help(0);

            return count == 0;

            void Help(int i)
            {
                count--;
                visited[i] = true;
                var list = rooms[i];

                foreach (var key in list)
                    if (!visited[key])
                        Help(key);
            }

        }

        // Your runtime beats 51.49 % of csharp submissions.
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {

            ISet<int> keys = new HashSet<int>() { 0 };

            Help(0);

            return keys.Count == rooms.Count;

            void Help(int i)
            {
                var list = rooms[i];

                foreach (var key in list)
                {
                    if (!keys.Contains(key))
                    {
                        keys.Add(key);
                        Help(key);
                    }
                }

            }

        }

    }
}
