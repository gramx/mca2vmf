using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class side
    {
        public int id;
        public plane plane;
        public string material;
        public axis uaxis;
        public axis vaxis;
        public double rotation;
        public int lightmapscale;
        public int smoothing_groups;
        public dispinfo dispinfo;

        public side()
        {
            id = 0;
            plane = new plane();
            material = String.Empty;
            uaxis = new axis();
            vaxis = new axis();
            rotation = 0;
            lightmapscale = 0;
            smoothing_groups = 0;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"id\"\t\"");
            sb.Append(id.ToString());
            sb.Append("\"");
            if (plane != null)
            {
                sb.AppendLine("\t\"plane\"\t\"");
                sb.Append(plane.Serialize());
                sb.Append("\"");
            }
            sb.AppendLine("\t\"material\"\t\"");
            sb.Append(material);
            sb.Append("\"");
            sb.AppendLine("\t\"uaxis\"\t\"");
            sb.Append(uaxis.Serialize());
            sb.Append("\"");
            sb.AppendLine("\t\"vaxis\"\t\"");
            sb.Append(vaxis.Serialize());
            sb.Append("\"");
            sb.AppendLine("\t\"rotation\"\t\"");
            sb.Append(rotation.ToString("F"));
            sb.Append("\"");
            sb.AppendLine("\t\"lightmapscale\"\t\"");
            sb.Append(lightmapscale.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"smoothing_groups\"\t\"");
            sb.Append(smoothing_groups.ToString());
            sb.Append("\"");
            if (dispinfo != null)
            {
                sb.AppendLine("\tdispinfo");
                sb.AppendLine(dispinfo.Serialize());
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
