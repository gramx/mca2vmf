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

        public void camera()
        {
            position = new vertex();
            look = new vertex();
        }
        public void camera(vertex Position, vertex Look)
        {
            position = Position;
            look = Look;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            sb.AppendLine("\t\"position\"\t\"");
            sb.Append(position.Serialize());
            sb.Append("\"");
            sb.AppendLine("\t\"look\"\t\"");
            sb.Append(look.Serialize());
            sb.Append("\"");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
