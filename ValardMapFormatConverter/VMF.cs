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

        /// <summary>
        /// Creates a classes that are used in VMF
        /// </summary>
        /// <remarks>
        /// TODO: dispinfo sub classes are missing
        /// </remarks>
        public VMF()
        {
            versioninfo = new versioninfo();
            visgroups = new visgroups();
            viewsettings = new viewsettings();
            world = new world();
            cameras = new cameras();
            cordons = new cordons();
        }

        public StringBuilder Serialize()
        {
            int tier = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append(versioninfo.Serialize(ref tier));
            sb.Append(visgroups.Serialize(ref tier));
            sb.Append(viewsettings.Serialize(ref tier));
            sb.Append(world.Serialize(ref tier));
            if (cameras != null)
            {
                sb.Append(cameras.Serialize(ref tier));
            }
            sb.Append(cordons.Serialize(ref tier));
            return sb;
        }
    }
    
}
