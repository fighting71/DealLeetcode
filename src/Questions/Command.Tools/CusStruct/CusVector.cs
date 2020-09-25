using System;
using System.Collections.Generic;
using System.Text;

namespace Command.CusStruct
{

    /// <summary>
    /// @auth : monster
    /// @since : 9/25/2020 10:51:33 AM
    /// @source : 
    /// @des : 
    /// </summary>
    public struct CusVector<XT,YT>
    {

        public XT X { get; set; }
        public YT Y { get; set; }

        public CusVector(XT x, YT y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is CusVector<XT, YT> vector &&
                   EqualityComparer<XT>.Default.Equals(X, vector.X) &&
                   EqualityComparer<YT>.Default.Equals(Y, vector.Y);
        }

        public override int GetHashCode()
        {
            int hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + EqualityComparer<XT>.Default.GetHashCode(X);
            hashCode = hashCode * -1521134295 + EqualityComparer<YT>.Default.GetHashCode(Y);
            return hashCode;
        }

        public override string ToString()
        {
            return $"<{X},{Y}>";
        }
    }
}
