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
        public double y;
        public double z;

        public vertex()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public vertex(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public vertex(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder(x.ToString("F"));
            sb.Append(" ");
            sb.Append(y.ToString("F"));
            sb.Append(" ");
            sb.Append(z.ToString("F"));
            return sb.ToString();
        }
    }
}
