using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Const
{
    /// <summary>
    /// @auth : monster
    /// @since : 2/25/2020 4:39:57 PM
    /// @source : 
    /// @des : 
    /// </summary>
    public static class FlagConst
    {
        /// <summary>
        /// 贪心算法
        /// </summary>
        public const string Greedy = nameof(Greedy);
        /// <summary>
        /// 动态规划
        /// </summary>
        public const string DP = nameof(DP);
        /// <summary>
        /// 深度优先搜索
        /// </summary>
        public const string DFS = nameof(DFS);
        public const string BFS = nameof(BFS);
        /// <summary>
        /// 排序
        /// </summary>
        public const string Sort = nameof(Sort);
        /// <summary>
        /// 复杂逻辑
        /// </summary>
        public const string Complex = nameof(Complex);
        /// <summary>
        /// 正则匹配
        /// </summary>
        public const string RegexMatch = nameof(RegexMatch);
        /// <summary>
        /// 效率优化
        /// </summary>
        public const string Efficient = nameof(Efficient);
        /// <summary>
        /// 多数表决算法
        /// 参考：https://gregable.com/2013/10/majority-vote-algorithm-find-majority.html
        ///      http://www.cs.rug.nl/~wim/pub/whh348.pdf
        /// 其他参考:(Fewer comparisons) [在N票中占多数] http://www.cs.yale.edu/publications/techreports/tr252.pdf
        /// </summary>
        public const string BoyerMoore = nameof(BoyerMoore);
        /// <summary>
        /// 充满技巧性
        /// ~远在天边近在眼前~
        /// </summary>
        public const string Special = nameof(Special);
        public const string BinarySearch = nameof(BinarySearch);
        public const string Design = nameof(Design);
        public const string Tree = nameof(Tree);
        public const string Recursion = nameof(Recursion);
        public const string ListNode = nameof(ListNode);
    }
}
