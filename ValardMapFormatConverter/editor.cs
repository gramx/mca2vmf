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

        public editor()
        {
            color = new rbg(0, 202, 175);
            visgroupshown = true;
            visgroupsutoshown = true;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "editor");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "color", color.Serialize(ref tier));
            if (visgroupid != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "visgroupid", visgroupid.ToString());
            }
            if (groupid != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "groupid", groupid.ToString());
            }
            Helpers.AppendBoolianRow(ref tier, ref sb, "visgroupshown", visgroupshown);
            Helpers.AppendBoolianRow(ref tier, ref sb, "visgroupsutoshown", visgroupsutoshown);
            if (comments != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "comments", comments);
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
