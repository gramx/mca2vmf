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

        public hidden()
        {

        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder();
            Helpers.AppendTextRow(ref tier, ref sb, "world");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            if (solid != null && solid.Count > 0)
            {
                foreach (solid s in solid)
                {
                    sb.Append(s.Serialize(ref tier));
                }
            }
            if (entity != null && entity.Count > 0)
            {
                foreach (entity e in entity)
                {
                    sb.Append(e.Serialize(ref tier));
                }
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
