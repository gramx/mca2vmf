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

        //TODO !! NOT A STRING
        public string plane;

        public string material;

        //TODO !! MISSING
        //public string uaxis;
        //public string vaxis;

        public Decimal rotation;
        public int lightmapscale;
        public int smoothing_groups;

        public void slide()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"id\"\t\"");
            sb.Append(id.ToString());
            sb.Append("\"");

            //TODO !! NOT A STRING
            sb.AppendLine("\t\"plane\"\t\"");
            sb.Append(plane);
            sb.Append("\"");

            sb.AppendLine("\t\"material\"\t\"");
            sb.Append(material);
            sb.Append("\"");

            //TODO !! MISSING
            //public string uaxis;
            //public string vaxis;

            sb.AppendLine("\t\"rotation\"\t\"");
            sb.Append(rotation.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"lightmapscale\"\t\"");
            sb.Append(lightmapscale.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"smoothing_groups\"\t\"");
            sb.Append(smoothing_groups.ToString());
            sb.Append("\"");

            if (side != null || side.Count > 0)
            {
                foreach (side s in side)
                {
                    sb.AppendLine("\tside");
                    sb.AppendLine(s.Serialize());
                }
            }

            if (editor != null)
            {
                sb.AppendLine("\teditor");
                sb.AppendLine(editor.Serialize());
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
