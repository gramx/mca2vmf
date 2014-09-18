using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class viewsettings
    {
        public bool bSnapToGrid;
        public bool bShowGrid;
        public bool bShowLogicalGrid;
        public int nGridSpacing;
        public bool bShow3DGrid;

        public viewsettings()
        {
            bSnapToGrid = false;
            bShowGrid = false;
            bShowLogicalGrid = false;
            nGridSpacing = 0;
            bShow3DGrid = false;
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            if (bSnapToGrid)
            {
                sb.AppendLine("\t\"bSnapToGrid\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"bSnapToGrid\"\t\"0\"");
            }
            if (bShowGrid)
            {
                sb.AppendLine("\t\"bShowGrid\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"bShowGrid\"\t\"0\"");
            }
            if (bShowLogicalGrid)
            {
                sb.AppendLine("\t\"bShowLogicalGrid\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"bShowLogicalGrid\"\t\"0\"");
            }
            sb.AppendLine("\t\"nGridSpacing\"\t\"");
            sb.Append(nGridSpacing.ToString());
            sb.Append("\"");
            if (bShow3DGrid)
            {
                sb.AppendLine("\t\"bShow3DGrid\"\t\"1\"");
            }
            else
            {
                sb.AppendLine("\t\"bShow3DGrid\"\t\"0\"");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
