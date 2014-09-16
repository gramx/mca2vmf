using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ValardMapFormatConverter
{
    public static class VMFConverter
    {
        public VMF CreateBasicVFM()
        {
            VMF vfm = new VMF();

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
            w.skyname = "sky_wasteland02"; //Maybe this should be a passin?
            w.solid = new List<solid>();
            w.hidden = new List<hidden>();
            w.group = new List<group>();
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

        public string SerializeVFM(VMF vmf)
        {

            return "";
        }

        public string DeserializeVFM(VMF vmf)
        {

            return "";
        }
    }
}
