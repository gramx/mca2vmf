using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class vertex
    {
        public Decimal x;
        public Decimal y;
        public Decimal z;

        public void vertex()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public void vertex(Decimal X, Decimal Y, Decimal Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder(x.ToString());
            sb.Append(" ");
            sb.Append(y.ToString());
            sb.Append(" ");
            sb.Append(z.ToString());
            return sb.ToString();
        }
    }
}
