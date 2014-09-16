using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class cordons
    {
        public bool active;
        public void cordons()
        {
            active = false;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            if (active)
            {
                sb.AppendLine("\t\"active\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"active\"\t\"0\"");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
