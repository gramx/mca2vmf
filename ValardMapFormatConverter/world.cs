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

        public void world()
        {
            classname = "worldspawn";
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"id\"\t\"");
            sb.Append(id.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"mapversion\"\t\"");
            sb.Append(mapversion);
            sb.Append("\"");
            sb.AppendLine("\t\"classname\"\t\"");
            sb.Append(classname);
            sb.Append("\"");
            sb.AppendLine("\t\"detailmaterial\"\t\"");
            sb.Append(detailmaterial);
            sb.Append("\"");
            sb.AppendLine("\t\"detailvbsp\"\t\"");
            sb.Append(detailvbsp);
            sb.Append("\"");
            sb.AppendLine("\t\"maxpropscreenwidth\"\t\"");
            sb.Append(maxpropscreenwidth.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"musicpostfix\"\t\"");
            sb.Append(musicpostfix);
            sb.Append("\"");
            sb.AppendLine("\t\"skyname\"\t\"");
            sb.Append(skyname);
            sb.Append("\"");
            if (solid != null || solid.Count > 0)
            { 
                foreach (solid s in solid)
                {
                    sb.AppendLine("\tsolid");
                    sb.AppendLine(s.Serialize());
                }
            }
            if (group != null || group.Count > 0)
            { 
                foreach (group g in group)
                {
                    sb.AppendLine("\tgroup");
                    sb.AppendLine(g.Serialize());
                }
            }
            if (hidden != null || hidden.Count > 0)
            { 
                foreach (hidden h in hidden)
                {
                    sb.AppendLine("\thidden");
                    sb.AppendLine(h.Serialize());
                }
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
