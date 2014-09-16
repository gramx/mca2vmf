using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class rbg
    {
        public int red;
        public int blue;
        public int green;

        public void rbg()
        {
            red = 0;
            blue = 0;
            green = 0;
        }

        public void rbg(Int16 Red, Int16 Blue, Int16 Green)
        {
            red = Red;
            blue = Blue;
            green = Green;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder(red.ToString());
            sb.Append(" ");
            sb.Append(blue.ToString());
            sb.Append(" ");
            sb.Append(green.ToString());
            return sb.ToString();
        }
    }
}
