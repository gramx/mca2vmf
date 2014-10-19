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

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder();
            Helpers.AppendTextRow(ref tier, ref sb, "group");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "id", id.ToString());
            if (editor != null && editor.Count > 0)
            {
                foreach (editor e in editor)
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
