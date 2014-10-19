using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class world
    {
        public int id;
        public string mapversion;
        public string classname;
        public string detailmaterial;
        public string detailvbsp;
        public int maxpropscreenwidth;
        public string musicpostfix;
        public string skyname;
        public List<solid> solid;
        public List<group> group;
        public List<hidden> hidden;

        public world()
        {
            id = 0;
            mapversion = String.Empty;
            classname = "worldspawn";
            detailmaterial = String.Empty;
            detailvbsp = String.Empty;
            maxpropscreenwidth = 0;
            musicpostfix = String.Empty;
            skyname = String.Empty;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder();
            Helpers.AppendTextRow(ref tier, ref sb, "world");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "id", id.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "mapversion", mapversion);
            Helpers.AppendTextRow(ref tier, ref sb, "classname", classname);
            Helpers.AppendTextRow(ref tier, ref sb, "detailmaterial", detailmaterial);
            Helpers.AppendTextRow(ref tier, ref sb, "detailvbsp", detailvbsp);
            Helpers.AppendTextRow(ref tier, ref sb, "maxpropscreenwidth", maxpropscreenwidth.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "musicpostfix", musicpostfix);
            Helpers.AppendTextRow(ref tier, ref sb, "skyname", skyname);
            if (solid != null && solid.Count > 0)
            {
                foreach (solid s in solid)
                {
                    sb.Append(s.Serialize(ref tier));
                }
            }
            if (group != null && group.Count > 0)
            { 
                foreach (group g in group)
                {
                    sb.Append(g.Serialize(ref tier));
                }
            }
            if (hidden != null && hidden.Count > 0)
            { 
                foreach (hidden h in hidden)
                {
                    sb.Append(h.Serialize(ref tier));
                }
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
