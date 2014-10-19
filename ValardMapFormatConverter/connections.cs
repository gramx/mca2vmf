using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class connections
    {
        public List<List<string>> OnTrigger;

        /// <summary>
        /// Connections object
        /// </summary>
        /// <remarks>
        /// NOTE: I still dont understand how exactly this works
        /// </remarks>
        public connections()
        {

        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder();
            Helpers.AppendTextRow(ref tier, ref sb, "connections");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            if (OnTrigger != null && OnTrigger.Count > 0)
            {
                foreach (List<string> s in OnTrigger)
                {
                    if (s != null && s.Count > 0)
                    {
                        Helpers.AppendTextRow(ref tier, ref sb, "OnTrigger", String.Join(",", s));
                    }
                }
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
