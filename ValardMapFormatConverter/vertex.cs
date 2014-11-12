using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class vertex
    {
        public double x;
        public double z;
        public double y;

        public vertex()
        {
            x = 0;
            z = 0;
            y = 0;
        }

        public vertex(double X, double Z, double Y)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public vertex(int X, int Z, int Y)
        {
            x = X;
            z = Z;
            y = Y;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder(x.ToString("F").Replace(".00", ""));
            sb.Append(" ");
            sb.Append(z.ToString("F").Replace(".00", ""));
            sb.Append(" ");
            sb.Append(y.ToString("F").Replace(".00",""));
            return sb.ToString();
        }
    }
}
