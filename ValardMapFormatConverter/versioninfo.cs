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

        public void versioninfo()
        {
            editorbuild = 0;
            editorbuild = 0;
            mapversion = 0;
            formatversion = 0;
            prefab = false;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            sb.AppendLine("\t\"editorversion\"\t\"");
            sb.Append(editorversion.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"editorbuild\"\t\"");
            sb.Append(editorbuild.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"mapversion\"\t\"");
            sb.Append(mapversion.ToString());
            sb.Append("\"");
            sb.AppendLine("\t\"formatversion\"\t\"");
            sb.Append(formatversion.ToString());
            sb.Append("\"");
            if (prefab)
            {
                sb.AppendLine("\t\"prefab\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"prefab\"\t\"0\"");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
