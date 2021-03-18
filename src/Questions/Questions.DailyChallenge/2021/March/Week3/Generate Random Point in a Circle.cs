using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.DailyChallenge._2021.March.Week3
{
    /// <summary>
    /// @auth : monster
    /// @since : 3/17/2021 4:39:19 PM
    /// @source : https://leetcode.com/explore/challenge/card/march-leetcoding-challenge-2021/590/week-3-march-15th-march-21st/3675/
    /// @des : 
    /// </summary>
    [Obsolete("math question...")]
    public class Generate_Random_Point_in_a_Circle
    {
        public Generate_Random_Point_in_a_Circle(double radius, double x_center, double y_center)
        {
            this.r = radius;
            centerX = x_center;
            centerY = y_center;
        }

        private readonly double r;
        private readonly double centerX;
        private readonly double centerY;
        private Random random = new Random();

        #region other solution
        // https://www.cnblogs.com/grandyang/p/9741220.html
        public double[] RandPoint()
        {
            random.NextDouble();
            double theta = 2 * Math.PI * random.NextDouble();
            double len = Math.Sqrt(random.NextDouble()) * r;
            return new [] { centerX + len * Math.Cos(theta), centerY + len * Math.Sin(theta)};
        }
        #endregion
    }
}
