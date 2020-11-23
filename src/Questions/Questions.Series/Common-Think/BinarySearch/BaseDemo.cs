using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.Common_Think
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/23/2020 10:54:22 AM
    /// @source : 二分查找
    /// @des : 
    /// </summary>
    public class BaseDemo
    {

        #region Find One

        /// <summary>
        /// 左右皆闭
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindOne(int[] arr, int target)
        {

            if (arr.Length == 0) return false;

            int len = arr.Length, left = 0, right = len - 1;

            while (left <= right) // 当left == right - 1 时退出 例如(3,2)
            {
                var mid = left + (right - left) / 2;// 等价于==> (left + right)/2  但前者能避免越界
                var num = arr[mid];
                if (num == target) return true;
                // a.由于mid已经查找过了，故没必要继续搜索
                if (num > target) right = mid - 1;
                else left = mid + 1;
            }

            return default;
        }

        /// <summary>
        /// 左闭右开
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindOne2(int[] arr, int target)
        {
            if (arr.Length == 0) return false;

            int len = arr.Length, left = 0, right = len;

            while (right > left)// 当left == right 时退出 例如(2,2), 故可能退出时存在点(2)没有搜寻.
            {
                var mid = left + (right - left) / 2;
                var num = arr[mid];
                if (num == target) return true;
                if (num > target) right = mid - 1;
                else left = mid + 1;
            }

            // 补丁
            return left != len && arr[left] == target;

        }


        #endregion

        #region Find Left

        /// <summary>
        /// 左右皆闭
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindLeft(int[] arr, int target)
        {
            if (arr.Length == 0) return -1;

            int len = arr.Length, left = 0, right = len - 1;

            while (right > left)// 当left == right 时退出 例如(2,2), 故可能退出时存在点(2)没有搜寻.
            {
                var mid = left + (right - left) / 2;// 等价于==> (left + right)/2  但前者能避免越界
                var num = arr[mid];
                if (num == target) right = mid - 1;// 收缩左半区，==>不能为mid : 可能导致right == left  然后死循环...
                // a.由于mid已经查找过了，故没必要继续搜索
                else if (num > target) right = mid - 1;
                else left = mid + 1;
            }

            if (left == len || arr[left] != target) return -1;

            return left;

        }
        /// <summary>
        /// 左闭右开
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindLeft2(int[] arr, int target)
        {
            if (arr.Length == 0) return -1;

            int len = arr.Length, left = 0, right = len;

            while (left < right) // 当left == right - 1 时退出 例如(3,2)
            {
                var mid = left + (right - left) / 2;// 等价于==> (left + right)/2  但前者能避免越界
                var num = arr[mid];
                if (num == target) right = mid;// 收缩左半区
                // a.由于mid已经查找过了，故没必要继续搜索
                // 这个很好解释，因为我们的「搜索区间」是  [left, right)  左闭右开，所以当  nums[mid]  被检测之后，下一步的搜索区间应该去掉  mid  分割成两个区间，即  [left, mid)  或  [mid + 1, right) 。
                else if (num > target) right = mid;// **
                else left = mid + 1;
            }

            return right != len && arr[right] == target ? right : -1;

        }
        #endregion

        #region Find right

        /// <summary>
        /// 左右皆闭
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindRight(int[] arr, int target)
        {
            if (arr.Length == 0) return -1;

            int len = arr.Length, left = 0, right = len - 1;

            while (right > left)// 当left == right 时退出 例如(2,2), 故可能退出时存在点(2)没有搜寻.
            {
                var mid = left + (right - left) / 2;// 等价于==> (left + right)/2  但前者能避免越界
                var num = arr[mid];
                if (num == target) left = mid + 1;// 收缩，==>不能为mid : 可能导致right == left  然后死循环...
                // a.由于mid已经查找过了，故没必要继续搜索
                else if (num > target) right = mid - 1;
                else left = mid + 1;
            }

            if (right < 0 || arr[right] != target) return -1;

            return right;

        }
        /// <summary>
        /// 左闭右开
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindRight2(int[] arr, int target)
        {
            if (arr.Length == 0) return -1;

            int len = arr.Length, left = 0, right = len;

            while (left < right) // 当left == right - 1 时退出 例如(3,2)
            {
                var mid = left + (right - left) / 2;// 等价于==> (left + right)/2  但前者能避免越界
                var num = arr[mid];
                if (num == target) left = mid + 1;// 收缩
                // a.由于mid已经查找过了，故没必要继续搜索
                // 这个很好解释，因为我们的「搜索区间」是  [left, right)  左闭右开，所以当  nums[mid]  被检测之后，下一步的搜索区间应该去掉  mid  分割成两个区间，即  [left, mid)  或  [mid + 1, right) 。
                else if (num > target) right = mid;// **
                else left = mid + 1;
            }

            if (left == 0) return -1;

            return arr[left - 1] == target ? left - 1 : - 1;

        }
        #endregion
    }
}
