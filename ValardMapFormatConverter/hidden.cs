using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class hidden
    {
        public List<solid> solid;
        public List<entity> entity;

        public void hidden()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");

            if (solid != null || solid.Count > 0)
            {
                foreach (solid s in solid)
                {
                    sb.AppendLine("\tsolid");
                    sb.AppendLine(s.Serialize());
                }
            }
            if (entity != null || entity.Count > 0)
            {
                foreach (entity e in entity)
                {
                    sb.AppendLine("\tentity");
                    sb.AppendLine(e.Serialize());
                }
            }

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
