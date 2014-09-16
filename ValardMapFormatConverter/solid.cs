using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class solid
    {
        public string id;
        public List<side> side;
        public editor editor;

        public void solid()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"id\"\t\"");
            sb.Append(id.ToString());
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
