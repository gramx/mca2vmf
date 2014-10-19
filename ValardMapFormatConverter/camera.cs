using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class camera
    {
        public vertex position;
        public vertex look;

        public camera()
        {
            position = new vertex();
            look = new vertex();
        }
        public camera(vertex Position, vertex Look)
        {
            position = Position;
            look = Look;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder();
            Helpers.AppendTextRow(ref tier, ref sb, "camera");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "position", position.Serialize(ref tier));
            Helpers.AppendTextRow(ref tier, ref sb, "look", look.Serialize(ref tier));
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
