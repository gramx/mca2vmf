using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class entity
    {
        public int id;
        public string classname;
        public int spawnflags;
        public List<connections> connections;
        public List<solid> solid;
        public List<hidden> hidden;
        public vertex origin;
        public List<editor> editor;

        public void entity()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            sb.AppendLine("\t\"id\"\t\"");
            sb.Append(id.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"classname\"\t\"");
            sb.Append(classname);
            sb.Append("\"");
            sb.AppendLine("\t\"spawnflags\"\t\"");
            sb.Append(spawnflags.ToString());
            sb.Append("\"");
            if (connections != null || connections.Count > 0)
            {
                foreach (connections c in connections)
                {
                    sb.AppendLine("\tconnections");
                    sb.AppendLine(c.Serialize());
                }
            }
            if (solid != null || solid.Count > 0)
            {
                foreach (solid s in solid)
                {
                    sb.AppendLine("\tsolid");
                    sb.AppendLine(s.Serialize());
                }
            }
            if (hidden != null || hidden.Count > 0)
            {
                foreach (hidden h in hidden)
                {
                    sb.AppendLine("\thidden");
                    sb.AppendLine(h.Serialize());
                }
            }
            if (origin != null)
            {
                sb.AppendLine("\t\"origin\"\t\"");
                sb.Append(origin.Serialize());
                sb.Append("\"");
            }
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
