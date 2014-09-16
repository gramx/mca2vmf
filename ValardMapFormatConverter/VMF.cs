using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    [Serializable()]
    public class VMF
    {
        public versioninfo versioninfo;
        public visgroups visgroups;
        public viewsettings viewsettings;
        public world world;
        public cameras cameras;
        public cordons cordons;

        public void VMF()
        {

        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder("{");
            sb.AppendLine("\tversioninfo");
            sb.AppendLine(versioninfo.Serialize());
            sb.AppendLine("\tvisgroups");
            sb.AppendLine(visgroups.Serialize());
            sb.AppendLine("\tviewsettings");
            sb.AppendLine(viewsettings.Serialize());
            sb.AppendLine("\tworld");
            sb.AppendLine(world.Serialize());
            sb.AppendLine("\tcameras");
            sb.AppendLine(cameras.Serialize());
            sb.AppendLine("\tcordons");
            sb.AppendLine(cordons.Serialize());
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
    
}
