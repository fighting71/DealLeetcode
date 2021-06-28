using Command.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.Hard.Deal3
{
    /// <summary>
    /// @auth : monster
    /// @since : 6/28/2021 2:29:25 PM
    /// @source : https://leetcode.com/problems/minimum-cost-to-hire-k-workers/
    /// @des : 
    /// 
    ///     给定n个工人，第i个工人，有一个quality[i]（质量）和wage[i]（最低期望工资）。
    /// 
    ///     target: 
    ///         用最少的金额雇佣k个工人
    ///         
    ///     支付工资规则：
    ///     
    ///         支付工资至少支付最低期望工资
    ///         所有工人的支付比例应该一致（比例 = 质量/支付工资）
    /// 
    /// </summary>
    [Obsolete(FlagConst.TimeLimit)]
    public class Minimum_Cost_to_Hire_K_Workers
    {

        // 1 <= k <= n <= 10000, where n = quality.length = wage.length
        //1 <= quality[i] <= 10000
        //1 <= wage[i] <= 10000
        //Answers within 10^-5 of the correct answer will be considered correct.

        #region other solution 

        // source : https://leetcode.com/problems/minimum-cost-to-hire-k-workers/discuss/141768/Detailed-explanation-O(NlogN)
        public double mincostToHireWorkers(int[] q, int[] w, int K)
        {
            double[][] workers = new double[q.Length][];

            for (int i = 0; i < q.Length; ++i)
                workers[i] = new double[] { (double)(w[i]) / q[i], q[i] };

            workers = workers.OrderBy(u => u[0]).ToArray();

            double res = Double.MaxValue, qsum = 0;
            Queue<double> pq = new Queue<double>();
            foreach (double[] worker in workers)
            {
                qsum += worker[1];
                pq.Enqueue(-worker[1]);
                if (pq.Count() > K) qsum += pq.Dequeue();
                if (pq.Count() == K) res = Math.Min(res, qsum * worker[0]);
            }
            return res;
        }

        #endregion

        /**
         *      pay = Sum(quality) / min(rate)
         *      
         *      n = 1  res = Min(wage)
         *      n = 2  res = Min(Sum(quality) / rate)
         *      
         */
        // more slow
        public double Try4(int[] quality, int[] wage, int k)
        {

            int len = quality.Length;

            if (len == 1) return wage.Min();

            (double rate,int sumQuality)[][] dp = new (double rate, int sumQuality)[len][];

            double[] rateArr = new double[len];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new (double rate, int sumQuality)[k];
                var q = quality[i];
                var w = wage[i];
                var rate = rateArr[i] = q / (double)w;
                dp[i][0] = (rate, q);
            }

            double minCost = int.MaxValue;

            for (int count = 1; count < k; count++)
            {
                for (int i = 0; i < len - count; i++)
                {
                    int q = quality[i],sum = q;
                    double rate = rateArr[i], res = int.MaxValue;
                    for (int j = i + 1; j < len; j++)
                    {
                        var v = dp[j][count - 1];

                        var min = Math.Min(rate, v.rate);
                        var sumQ = v.sumQuality + q;
                        var currRes = sumQ / min;
                        if(currRes < res)
                        {
                            sum = sumQ;
                            res = currRes;
                            rate = min;
                        }
                    }
                    dp[i][count] = (rate, sum);
                    if(count == k - 1)
                    {
                        minCost = Math.Min(minCost, res);
                    }
                }
            }
            return minCost;
        }

        // time limit
        public double Try3(int[] quality, int[] wage, int k)
        {
            int len = quality.Length;

            var ps = quality.Select((item, index) =>
            {

                var q = quality[index];
                var w = wage[index];
                var v = q / (double)w;

                return new { q, w, v };

            }).OrderBy(u => u.v).ToArray();

            var arr2 = ps.Select((item, index) => new { index, item.q }).OrderBy(u => u.q).ToList();

            double res = int.MaxValue;

            for (int i = 0; i < len - k + 1; i++)
            {
                var curr = ps[i];

                double sum = curr.w, rate = curr.v;

                arr2.Remove(arr2.Find(u => u.index == i));

                sum += arr2.Take(k - 1).Sum(u => u.q / rate);

                res = Math.Min(res, sum);
            }
            return res;

        }

        // time limit 
        public double Try2(int[] quality, int[] wage, int k) 
        {
            int len = quality.Length;

            var ps = quality.Select((item, index) =>
            {

                var q = quality[index];
                var w = wage[index];
                var v = q / (double)w;

                return new { q, w, v };

            }).OrderBy(u => u.v).ToArray();

            var arr2 = ps.Select((item, index) => new { index, item.q }).OrderBy(u => u.q).ToArray();

            double res = int.MaxValue;

            for (int i = 0; i < len - k + 1; i++)
            {
                var curr = ps[i];

                double sum = curr.w, rate = curr.v;

                sum += arr2.Where(u => u.index > i).Take(k - 1).Sum(u => u.q / rate);

                res = Math.Min(res, sum);
            }
            return res;
        }
        public double Try(int[] quality, int[] wage, int k)
        {

            int len = quality.Length;

            var ps = quality.Select((item, index) =>
            {

                var q = quality[index];
                var w = wage[index];
                var v = q / (double)w;

                return new { q, w, v };

            }).OrderBy(u => u.v).ToArray();

            double res = int.MaxValue;

            for (int i = 0; i < len - k + 1; i++)
            {
                var curr = ps[i];

                double sum = curr.w, rate = curr.v;

                sum += ps.Skip(i + 1).OrderBy(u => u.q).Take(k - 1).Sum(u => u.q / rate);
                res = Math.Min(res, sum);
            }
            return res;
        }
        public double Simple(int[] quality, int[] wage, int k)
        {
            int len = quality.Length;

            bool[] visited = new bool[len];

            double res = int.MaxValue;

            for (int i = 0; i < len; i++)
            {
                visited[i] = true;
                res = Math.Min(res, Help(k - 1, quality[i] / (double)wage[i], wage[i]));
                visited[i] = false;
            }

            return res;

            double Help(int count, double rate, double sum)
            {
                if (count == 0) return sum;

                double res = int.MaxValue;

                for (int i = 0; i < len; i++)
                {
                    if (visited[i]) continue;

                    int q = quality[i], w = wage[i];

                    var newRate = q / (double)w;

                    if (newRate < rate) continue;
                    visited[i] = true;
                    res = Math.Min(res, Help(count - 1, rate, sum + (q / rate)));
                    visited[i] = false;
                }
                return res;
            }

        }

        // bug
        public double MincostToHireWorkers(int[] quality, int[] wage, int k)
        {
            // [10,20,5], wage = [70,50,30]
            var ps = quality.Select((item, index) =>
            {

                var q = quality[index];
                var w = wage[index];
                var v = w / (double)q;

                return new { q, w, v };

            }).OrderByDescending(u => u.v).ToArray();

            var min = ps[ps.Length - 1];

            double spend = min.w;

            for (int i = 0; i < ps.Length - 1; i++)
            {
                spend += ps[i].q / spend;
            }
            return spend;
        }

    }
}
