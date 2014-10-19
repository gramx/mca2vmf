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

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "visgroups");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            if (name != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "name", name);
            }
            Helpers.AppendTextRow(ref tier, ref sb, "visgroupid", visgroupid.ToString());
            if (color != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "color", color.Serialize(ref tier));
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
