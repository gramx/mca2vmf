using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class connections
    {
        public List<string> OnTrigger;

        public connections()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            if (OnTrigger != null || OnTrigger.Count > 0)
            {
                //foreach (string s in OnTrigger)
                //{
                sb.AppendLine("\t\"OnTrigger\"\t\"");
                sb.Append(String.Join(",", OnTrigger));
                sb.Append("\"");
                //}
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
