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

        public void cameras()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            if (activecamera)
            {
                sb.AppendLine("\t\"activecamera\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"activecamera\"\t\"0\"");
            }
            if (camera != null || camera.Count > 0)
            {
                foreach (camera c in camera)
                {
                    sb.AppendLine("\tcamera");
                    sb.AppendLine(c.Serialize());
                }
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

    }
}
