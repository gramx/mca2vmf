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

        public entity()
        {

        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder();
            Helpers.AppendTextRow(ref tier, ref sb, "world");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "id", id.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "classname", classname);
            Helpers.AppendTextRow(ref tier, ref sb, "spawnflags", spawnflags.ToString());
            if (connections != null || connections.Count > 0)
            {
                foreach (connections c in connections)
                {
                    sb.AppendLine("\tconnections");
                    sb.AppendLine(c.Serialize(ref tier));
                }
            }
            if (solid != null && solid.Count > 0)
            {
                foreach (solid s in solid)
                {
                    sb.Append(s.Serialize(ref tier));
                }
            }
            if (hidden != null && hidden.Count > 0)
            {
                foreach (hidden h in hidden)
                {
                    sb.Append(h.Serialize(ref tier));
                }
            }
            if (origin != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "origin", origin.Serialize(ref tier));
            }
            if (editor != null && editor.Count > 0)
            {
                foreach (editor e in editor)
                {
                    sb.Append(e.Serialize(ref tier));
                }
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
