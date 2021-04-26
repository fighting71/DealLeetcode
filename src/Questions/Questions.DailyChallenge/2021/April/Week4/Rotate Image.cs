using Command.Attr;
using Command.Const;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.April.Week4
{
    /// <summary>
    /// @auth : monster
    /// @since : 4/26/2021 2:22:45 PM
    /// @source : https://leetcode.com/explore/challenge/card/april-leetcoding-challenge-2021/596/week-4-april-22nd-april-28th/3720/
    /// @des : 
    ///     旋转方块
    ///     ==> 将一个正方形顺时针旋转90°
    ///         在不产生额外空间的前提下进行旋转
    /// </summary>
    [Favorite(FlagConst.Rotate, FlagConst.Matrix)]
    public class Rotate_Image
    {

        // 差不太多，速度提升还得减少索引搜索.
        public void Solution3(int[][] matrix)
        {
            int len = matrix.Length, left = 0, right = len - 1, count = right - left;

            while (right > left)
            {
                for (int j = 0; j < count; j++)
                {
                    var empty = matrix[left][left + j];
                    matrix[left][left + j] = matrix[right - j][left];
                    matrix[right - j][left] = matrix[right][right - j];
                    matrix[right][right - j] = matrix[left + j][right];
                    matrix[left + j][right] = empty;
                }
                count -= 2;
                left++;
                right--;
            }
        }

        public void Solution2(int[][] matrix)
        {

            int len = matrix.Length, left = 0, right = len - 1, top = 0, bottom = len - 1, count = right - left;

            while (right > left)
            {
                for (int j = 0; j < count; j++)
                {
                    var empty = matrix[top][left + j];
                    matrix[top][left + j] = matrix[bottom - j][left];
                    matrix[bottom - j][left] = matrix[bottom][right - j];
                    matrix[bottom][right - j] = matrix[top + j][right];
                    matrix[top + j][right] = empty;
                }
                count -= 2;
                left++;
                right--;
                top++;
                bottom--;
            }
        }
        // Your runtime beats 65.97 %
        public void Rotate(int[][] matrix)
        {
            var len = matrix.Length;
            int left, right, top, bottom;
            int count;
            if (len % 2 == 0)
            {
                count = 2;
                left = len / 2 - 1;
                right = left + 1;
                top = left;
                bottom = left + 1;
            }
            else
            {
                count = 3;
                left = len / 2 - 1;
                right = left + 2;
                top = left;
                bottom = left + 2;
            }

            for (int i = 0; i < len / 2; i++)
            {

                for (int j = 0; j < count - 1; j++)
                {
                    var empty = matrix[top][left + j];
                    matrix[top][left + j] = matrix[bottom - j][left];
                    matrix[bottom - j][left] = matrix[bottom][right - j];
                    matrix[bottom][right - j] = matrix[top + j][right];
                    matrix[top + j][right] = empty;
                }

                left--;
                right++;
                top--;
                bottom++;
                count += 2;
            }

        }

    }
}
