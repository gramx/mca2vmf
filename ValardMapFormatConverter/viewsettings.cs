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

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "viewsettings");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendBoolianRow(ref tier, ref sb, "bSnapToGrid", bSnapToGrid);
            Helpers.AppendBoolianRow(ref tier, ref sb, "bShowGrid", bShowGrid);
            Helpers.AppendBoolianRow(ref tier, ref sb, "bShowLogicalGrid", bShowLogicalGrid);
            Helpers.AppendTextRow(ref tier, ref sb, "nGridSpacing", nGridSpacing.ToString());
            Helpers.AppendBoolianRow(ref tier, ref sb, "bShow3DGrid", bShow3DGrid);
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
