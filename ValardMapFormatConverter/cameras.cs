using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class cameras
    {
        public bool activecamera;
        public List<camera> camera;

        public cameras()
        {
            activecamera = false;
            camera = new List<camera>();
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "cameras");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendBoolianRow(ref tier, ref sb, "activecamera", activecamera);
            if (camera != null && camera.Count > 0)
            {
                foreach (camera c in camera)
                {
                    sb.Append(c.Serialize(ref tier));
                }
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }

    }
}
