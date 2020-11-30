using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Series.AlgorithmThinking
{
    /// <summary>
    /// @auth : monster
    /// @since : 11/30/2020 3:18:18 PM
    /// @source : https://leetcode.com/problems/flood-fil
    /// @des : 
    /// </summary>
    public class Flood_Fill
    {

        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            Help(image, sc, sr, image[sr][sc], newColor);
            return image;
        }

        private void Help(int[][] image, int x, int y, int oldColor, int newColor)
        {
            if (y < 0 || y == image.Length || x < 0 || x == image[0].Length || image[y][x] != oldColor) return;

            image[y][x] = -1;
            Help(image, x + 1, y, oldColor, newColor);
            Help(image, x - 1, y, oldColor, newColor);
            Help(image, x, y + 1, oldColor, newColor);
            Help(image, x, y - 1, oldColor, newColor);
            image[y][x] = newColor;
        }

        private void Help(int[][] image, int x, int y, int oldColor, int newColor, bool[][] visited)
        {
            if (y < 0 || y == image.Length || x < 0 || x == image[0].Length
                || image[y][x] != oldColor
                || visited[y][x]) return;

            Help(image, x + 1, y, oldColor, newColor, visited);
            Help(image, x - 1, y, oldColor, newColor, visited);
            Help(image, x, y + 1, oldColor, newColor, visited);
            Help(image, x, y - 1, oldColor, newColor, visited);
        }
    }
}
