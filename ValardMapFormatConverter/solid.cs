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

        public solid()
        {

        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder();
            Helpers.AppendTextRow(ref tier, ref sb, "solid");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "id", id.ToString());
            if (side != null && side.Count > 0)
            {
                foreach (side s in side)
                {
                    sb.Append(s.Serialize(ref tier));
                }
            }
            if (editor != null)
            {
                sb.Append(editor.Serialize(ref tier));
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
