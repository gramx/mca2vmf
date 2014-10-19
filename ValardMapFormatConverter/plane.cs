using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class plane
    {
        public List<vertex> vertex;

        public plane()
        {
            vertex = new List<vertex>();
        }

        public plane(List<vertex> Vertex)
        {
            vertex = Vertex;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            if (vertex != null && vertex.Count > 0)
            {
                foreach (vertex v in vertex)
                {
                    sb.Append("(");
                    sb.Append(v.Serialize(ref tier));
                    sb.Append(") ");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
    }
}
