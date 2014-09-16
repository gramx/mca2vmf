using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class editor
    {
        public rbg color;
        public int visgroupid;
        public int groupid;
        public bool visgroupshown;
        public bool visgroupsutoshown;
        public string comments;

        public void editor()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"color\"\t\"");
            sb.Append(color.Serialize());
            sb.Append("\"");
            sb.AppendLine("\t\"visgroupid\"\t\"");
            sb.Append(visgroupid.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"groupid\"\t\"");
            sb.Append(groupid.ToString());
            sb.Append("\"");
            if (visgroupshown)
            {
                sb.AppendLine("\t\"visgroupshown\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"visgroupshown\"\t\"0\"");
            }
            if (visgroupsutoshown)
            {
                sb.AppendLine("\t\"visgroupsutoshown\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"visgroupsutoshown\"\t\"0\"");
            }
            sb.AppendLine("\t\"comments\"\t\"");
            sb.Append(comments);
            sb.Append("\"");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
