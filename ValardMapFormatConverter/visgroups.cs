using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class visgroups
    {
        public string name;
        public int visgroupid;
        public rbg color;

        public visgroups()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            if (name != null)
            {
                sb.AppendLine("\t\"name\"\t\"");
                sb.Append(name);
                sb.Append("\"");
            }
            if (visgroupid != null)
            {
                sb.AppendLine("\t\"visgroupid\"\t\"");
                sb.Append(visgroupid.ToString());
                sb.Append("\"");
            }
            if (color != null)
            {
                sb.AppendLine("\t\"color\"\t\"");
                sb.Append(color.Serialize());
                sb.Append("\"");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
