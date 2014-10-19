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

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "dispinfo");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "power", power.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "startposition", startposition.Serialize(ref tier));
            Helpers.AppendTextRow(ref tier, ref sb, "elevation", elevation.ToString("F"));
            Helpers.AppendBoolianRow(ref tier, ref sb, "subdiv", subdiv);
            
            //normals{}
            //distances{}
            //offsets{}
            //offset_normals{}
            //alphas{}
            //triangle_tags{}
            //allowed_verts{}
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
