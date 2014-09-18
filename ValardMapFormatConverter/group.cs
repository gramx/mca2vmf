using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class group
    {
        public int id;
        public List<editor> editor;

        public group()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"id\"\t\"");
            sb.Append(id.ToString());
            sb.Append("\"");
            if (editor != null || editor.Count > 0)
            {
                foreach (editor e in editor)
                {
                    sb.AppendLine("\teditor");
                    sb.AppendLine(e.Serialize());
                }
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
