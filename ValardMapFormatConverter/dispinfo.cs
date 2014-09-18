using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class dispinfo
    {
        public int power;
        public vertex startposition;
        public double elevation;
        public bool subdiv;

        //TODO
        //normals{}
        //distances{}
        //offsets{}
        //offset_normals{}
        //alphas{}
        //triangle_tags{}
        //allowed_verts{}

        public dispinfo()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"power\"\t\"");
            sb.Append(power.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"startposition\"\t\"");
            sb.Append(startposition.Serialize());
            sb.Append("\"");
            sb.AppendLine("\t\"elevation\"\t\"");
            sb.Append(elevation.ToString("F"));
            sb.Append("\"");
            if (subdiv)
            {
                sb.AppendLine("\t\"subdiv\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"subdiv\"\t\"0\"");
            }
            //normals{}
            //distances{}
            //offsets{}
            //offset_normals{}
            //alphas{}
            //triangle_tags{}
            //allowed_verts{}
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
