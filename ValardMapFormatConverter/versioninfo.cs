using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class versioninfo
    {

        public int editorversion;
        public int editorbuild;
        public int mapversion;
        public int formatversion;
        public bool prefab;

        public versioninfo()
        {
            editorbuild = 0;
            editorbuild = 0;
            mapversion = 0;
            formatversion = 0;
            prefab = false;
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "versioninfo");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "editorversion", editorversion.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "editorbuild", editorbuild.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "mapversion", mapversion.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "formatversion", formatversion.ToString());
            Helpers.AppendBoolianRow(ref tier, ref sb, "prefab", prefab);
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
