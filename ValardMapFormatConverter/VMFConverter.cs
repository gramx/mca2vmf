using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ValardMapFormatConverter
{
    public static class VMFConverter
    {
        public static VMF SetupBasicVFM(VMF vfm)
        {
            //versioninfo
            versioninfo vi = new versioninfo();
            vi.editorbuild = 400;
            vi.editorbuild = 6262;
            vi.mapversion = 7;
            vi.formatversion = 100;
            vi.prefab = false;
            vfm.versioninfo = vi;

            //viewsettings
            viewsettings vs = new viewsettings();
            vs.bSnapToGrid = true;
            vs.bShowGrid = true;
            vs.bShowLogicalGrid = false;
            vs.nGridSpacing = 16;
            vs.bShow3DGrid = false;
            vfm.viewsettings = vs;

            //world
            world w = new world();
            w.id = 1;
            w.mapversion = "1";
            w.classname = "worldspawn";
            w.skyname = "sky_wasteland02"; //Maybe this should be a pass-in?
            w.solid = new List<solid>();
            vfm.world = w;
            
            //cameras
            cameras c = new cameras();
            c.activecamera = false;
            c.camera = new List<camera>();
            c.camera.Add(new camera());
            vfm.cameras = c;

            //cordons
            cordons cd = new cordons();
            cd.active = false;
            vfm.cordons = cd;

            return vfm;
        }

        public static string SerializeVFM(VMF vmf)
        {
            //TODO simple check if valid file

            return vmf.Serialize();
        }

        //TODO
        //public static string DeserializeVFM(VMF vmf)
        //{

        //    return "";
        //}
    }
}
