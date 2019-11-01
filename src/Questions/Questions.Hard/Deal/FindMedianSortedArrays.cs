using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal
{
    /// <summary>
    /// @auth : monster
    /// @since : 2019/11/1 10:24:44
    /// @source : https://leetcode.com/problems/median-of-two-sorted-arrays/
    /// @des : 简单的题，想明白求解方式就很容易
    /// </summary>
    public class FindMedianSortedArrays
    {
        
        /**
         * Runtime: 120 ms, faster than 91.09% of C# online submissions for Median of Two Sorted Arrays.
         * Memory Usage: 27.2 MB, less than 6.25% of C# online submissions for Median of Two Sorted Arrays.
         *
         * Runtime: 116 ms, faster than 96.88% of C# online submissions for Median of Two Sorted Arrays.
         * Memory Usage: 27.2 MB, less than 6.25% of C# online submissions for Median of Two Sorted Arrays.
         *
         * Try2的简洁版
         *
         * 我就知道其实不慢，只是需要整理....
         * 
         */
        public double Solution(int[] nums1, int[] nums2)
        {
            int len = nums1.Length, len2 = nums2.Length, mid = (len + len2) / 2, prev = 0, last = 0;
            bool flag = (len + len2) % 2 == 0;

            if (len == 0)
            {
                if (flag)
                    prev = nums2[mid - 1];
                last = nums2[mid];
            }
            else if (len2 == 0)
            {
                if (flag)
                    prev = nums1[mid - 1];
                last = nums1[mid];
            }
            else if (nums1[0] >= nums2[len2 - 1])
            {
                last = mid < len2 ? nums2[mid] : nums1[mid - len2];
                if (flag)
                    prev = mid - 1 < len2 ? nums2[mid - 1] : nums1[mid - 1 - len2];
            }
            else if (nums2[0] >= nums1[len - 1])
            {
                last = mid < len ? nums1[mid] : nums2[mid - len];
                if (flag)
                    prev = mid - 1 < len ? nums1[mid - 1] : nums2[mid - 1 - len];
            }
            else
            {
                int i = 0, j = 0;
                while (mid-- >= 0)
                {
                    if (flag)
                        prev = last;
                    if (i == len)
                        last = nums2[j++];
                    else if (j == len2)
                        last = nums1[i++];
                    else if (nums1[i] > nums2[j])
                        last = nums2[j++];
                    else
                        last = nums1[i++];
                }
            }

            if (flag)
                return (last + prev) / 2.0;

            return last;
        }

        /**
         * Runtime: 132 ms, faster than 51.29% of C# online submissions for Median of Two Sorted Arrays.
         * Memory Usage: 27.3 MB, less than 6.25% of C# online submissions for Median of Two Sorted Arrays.
         *
         * 尝试说明版。
         * 
         */
        public double Try2(int[] nums1, int[] nums2)
        {
            int len = nums1.Length, len2 = nums2.Length, mid = (len + len2) / 2;

            // nums1 为空数组 
            if (len == 0)
            {
                if (len2 % 2 == 0) return (nums2[mid] + nums2[mid - 1]) / 2.0;
                return nums2[mid];
            }

            // nums2 为空数组
            if (len2 == 0)
            {
                if (len % 2 == 0) return (nums1[mid] + nums1[mid - 1]) / 2.0;
                return nums1[mid];
            }

            // nums2 -> nums1 是一个排序数组
            if (nums1[0] >= nums2[len2 - 1])
            {
                if ((len + len2) % 2 == 0)
                {
                    return ((mid < len2 ? nums2[mid] : nums1[mid - len2]) +
                            (mid - 1 < len2 ? nums2[mid - 1] : nums1[mid - 1 - len2])) / 2.0;
                }

                return mid < len2 ? nums2[mid] : nums1[mid - len2];
            }

            // nums1->nums2 是一个排序数组
            if (nums2[0] >= nums1[len - 1])
            {
                if ((len + len2) % 2 == 0)
                {
                    return ((mid < len ? nums1[mid] : nums2[mid - len]) +
                            (mid - 1 < len ? nums1[mid - 1] : nums2[mid - 1 - len])) / 2.0;
                }

                return mid < len ? nums1[mid] : nums2[mid - len];
            }

            // 找出第mid小和第mid-1的数 - 计算求值
            int i = 0, j = 0, last = 0, prev = 0;
            while (mid-- >= 0)
            {
                prev = last;
                if (i == len)
                {
                    last = nums2[j];
                    j++;
                }
                else if (j == len2)
                {
                    last = nums1[i];
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    last = nums2[j];
                    j++;
                }
                else
                {
                    last = nums1[i];
                    i++;
                }
            }

            if ((len + len2) % 2 == 0)
            {
                return (last + prev) / 2.0;
            }

            return last;
        }

        /// <summary>
        /// 即跳前又跳后 写完就感觉过不了....
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double Try(int[] nums1, int[] nums2)
        {
            bool flag = true, flag2 = true;
            int startI = 0, endI = nums1.Length - 1, startJ = 0, endJ = nums2.Length - 1;

            while (true)
            {
                if (!flag)
                {
                    if (endJ == startJ) return nums2[startJ];
                    if (endJ - startJ == 1) return (nums2[startJ] + nums2[endJ]) / 2.0;
                    startJ++;
                    endJ--;
                }
                else if (!flag2)
                {
                    if (startI == endI) return nums2[startJ];
                    if (endI - startI == 1) return (nums2[startI] + nums2[endI]) / 2.0;
                    startI++;
                    endI--;
                }
                else
                {
                    if (startI == endI && startJ == endJ) return (nums1[startI] + nums2[startJ]) / 2.0;

                    if (nums1[startI] > nums2[startJ])
                    {
                        startJ++;
                    }
                    else
                    {
                        startI++;
                    }

                    if (nums1[endI] > nums2[endJ])
                    {
                        endI--;
                    }
                    else
                    {
                        endJ--;
                    }

                    if (endI < startI) flag = false;
                    else if (endJ < startJ) flag2 = false;
                }
            }
        }

        /// <summary>
        /// 检验方法 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double Check(int[] nums1, int[] nums2)
        {
            List<int> list = new List<int>();

            list.AddRange(nums1);

            list.AddRange(nums2);

            list = list.OrderBy(u => u).ToList();

            var len = list.Count;
            if (len % 2 == 0)
            {
                return (list[len / 2] + list[len / 2 - 1]) / 2.0;
            }

            return list[len / 2];
        }
    }
}