using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class axis
    {
        public double x;
        public double y;
        public double z;
        public double translation;
        public double scaling;

        public axis()
        {
            x = 0;
            y = 0;
            z = 0;
            translation = 0;
            scaling = 0.25;
        }

        public axis(double X, double Y, double Z, double Translation, double Scaling)
        {
            x = X;
            y = Y;
            z = Z;
            translation = Translation;
            scaling = Scaling;
        }

        public axis(double X, double Y, double Z, double Translation)
        {
            x = X;
            y = Y;
            z = Z;
            translation = Translation;
            scaling = 0.25;
        }

        public axis(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
            translation = 0;
            scaling = 0.25;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("[");
            sb.Append(x.ToString("F"));
            sb.Append(" ");
            sb.Append(y.ToString("F"));
            sb.Append(" ");
            sb.Append(z.ToString("F"));
            sb.Append(" ");
            sb.Append(translation.ToString("F"));
            sb.Append("] ");
            sb.Append(scaling.ToString("F"));
            return sb.ToString();
        }
    }
}
