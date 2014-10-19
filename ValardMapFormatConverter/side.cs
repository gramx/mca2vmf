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

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "side");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "id", id.ToString());
            if (plane != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "plane", plane.Serialize(ref tier));
            }
            Helpers.AppendTextRow(ref tier, ref sb, "material", material);
            Helpers.AppendTextRow(ref tier, ref sb, "uaxis", uaxis.Serialize(ref tier));
            Helpers.AppendTextRow(ref tier, ref sb, "vaxis", vaxis.Serialize(ref tier));
            Helpers.AppendTextRow(ref tier, ref sb, "rotation", rotation.ToString("F"));
            Helpers.AppendTextRow(ref tier, ref sb, "lightmapscale", lightmapscale.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "smoothing_groups", smoothing_groups.ToString());
            if (dispinfo != null)
            {
                sb.Append(dispinfo.Serialize(ref tier));
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
