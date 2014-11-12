using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    public class side
    {
        public int id;
        public plane plane;
        public string material;
        public axis uaxis;
        public axis vaxis;
        public double rotation;
        public int lightmapscale;
        public int smoothing_groups;
        public dispinfo dispinfo;

        private void initializeProperties()
        {
            id = 0;
            plane = new plane();
            material = String.Empty;
            uaxis = new axis();
            vaxis = new axis();
            rotation = 0;
            lightmapscale = 0;
            smoothing_groups = 0;
        }

        public side()
        {
            initializeProperties();
        }

        public side(int x, int z, int y, Nullable<bool> dimension, int ID, string Material, int offset)
        {
            lightmapscale = Math.Abs(offset);
            rotation = 0;
            smoothing_groups = 0;
            id = ID;
            material = Material;
            plane = new plane();
            //Horizontal Surface (Y is height)
            if (!dimension.HasValue)
            {
                plane.vertex.Add(new vertex(x, z + offset, y));
                plane.vertex.Add(new vertex(x, z, y));
                plane.vertex.Add(new vertex(x + offset, z, y));
                uaxis = new axis(1, 0, 0, 0);
                vaxis = new axis(0, -1, 0, 0);
            }
            //Vertical Surface (A)
            else if (dimension.Value)
            {
                plane.vertex.Add(new vertex(x, z + offset, y));
                plane.vertex.Add(new vertex(x, z, y));
                plane.vertex.Add(new vertex(x, z, y + offset));
                uaxis = new axis(0, 1, 0, 0);
                vaxis = new axis(0, 0, -1, 0);
            }
            //Vertical Surface (B)
            else
            {
                plane.vertex.Add(new vertex(x + offset, z, y));
                plane.vertex.Add(new vertex(x, z, y));
                plane.vertex.Add(new vertex(x, z, y + offset));
                uaxis = new axis(1, 0, 0, 0);
                vaxis = new axis(0, 0, -1, 0);
            }
        }

        /// <summary>
        /// Decare a side
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <param name="y"></param>
        /// <param name="face">
        /// Object face looking outside of the object
        /// 1 - Top
        /// 2 - Bottom
        /// 3 - Left Side
        /// 4 - Right Side
        /// 5 - Front
        /// 6 - Back
        /// </param>
        /// <param name="ID">Side ID</param>
        /// <param name="Material">Texture</param>
        /// <param name="offset">Scale of the map</param>
        public side(int x, int z, int y, byte face, int ID, string Material, int offset)
        {
            lightmapscale = Math.Abs(offset);
            rotation = 0;
            smoothing_groups = 0;
            id = ID;
            material = Material;
            plane = new plane();

            //Looks like the VMF only works when points are counter-clockwise when viewing from outside the box
            switch (face)
            {
                case 1: //Top
                    plane.vertex.Add(new vertex(x, z + offset, y + offset));
                    plane.vertex.Add(new vertex(x + offset, z + offset, y + offset));
                    plane.vertex.Add(new vertex(x + offset, z, y + offset));
                    uaxis = new axis(1, 0, 0, 0);
                    vaxis = new axis(0, -1, 0, 0);
                    break;
                case 2: //Bottom
                    plane.vertex.Add(new vertex(x, z + offset, y));
                    plane.vertex.Add(new vertex(x, z, y));
                    plane.vertex.Add(new vertex(x + offset, z, y));
                    uaxis = new axis(1, 0, 0, 0);
                    vaxis = new axis(0, -1, 0, 0);
                    break;
                case 3: //Left Side
                    plane.vertex.Add(new vertex(x + offset, z, y));
                    plane.vertex.Add(new vertex(x, z, y));
                    plane.vertex.Add(new vertex(x, z, y + offset));
                    uaxis = new axis(1, 0, 0, 0);
                    vaxis = new axis(0, 0, -1, 0);
                    break;
                case 4: //Right Side
                    plane.vertex.Add(new vertex(x + offset, z + offset, y));
                    plane.vertex.Add(new vertex(x + offset, z + offset, y + offset));
                    plane.vertex.Add(new vertex(x, z + offset, y + offset));
                    uaxis = new axis(1, 0, 0, 0);
                    vaxis = new axis(0, 0, -1, 0);
                    break;
                case 5: //Front
                    plane.vertex.Add(new vertex(x, z, y + offset));
                    plane.vertex.Add(new vertex(x, z, y));
                    plane.vertex.Add(new vertex(x, z + offset, y));
                    uaxis = new axis(0, 1, 0, 0);
                    vaxis = new axis(0, 0, -1, 0);
                    break;
                case 6: //Back
                    plane.vertex.Add(new vertex(x + offset, z, y + offset));
                    plane.vertex.Add(new vertex(x + offset, z + offset, y + offset));
                    plane.vertex.Add(new vertex(x + offset, z + offset, y));
                    uaxis = new axis(0, 1, 0, 0);
                    vaxis = new axis(0, 0, -1, 0);
                    break;
                default:
                    throw new Exception("Your face is invalid (use one to six as a face code).");
                    break;
            }
        }

        public string Serialize(ref int tier)
        {
            StringBuilder sb = new StringBuilder("");
            Helpers.AppendTextRow(ref tier, ref sb, "side");
            Helpers.AppendTextRow(ref tier, ref sb, "{");
            tier++;
            Helpers.AppendTextRow(ref tier, ref sb, "id", id.ToString());
            if (plane != null)
            {
                Helpers.AppendTextRow(ref tier, ref sb, "plane", plane.Serialize(ref tier));
            }
            Helpers.AppendTextRow(ref tier, ref sb, "material", material);
            Helpers.AppendTextRow(ref tier, ref sb, "uaxis", uaxis.Serialize(ref tier));
            Helpers.AppendTextRow(ref tier, ref sb, "vaxis", vaxis.Serialize(ref tier));
            Helpers.AppendTextRow(ref tier, ref sb, "rotation", rotation.ToString("F").Replace(".00", ""));
            Helpers.AppendTextRow(ref tier, ref sb, "lightmapscale", lightmapscale.ToString());
            Helpers.AppendTextRow(ref tier, ref sb, "smoothing_groups", smoothing_groups.ToString());
            if (dispinfo != null)
            {
                sb.Append(dispinfo.Serialize(ref tier));
            }
            tier--;
            Helpers.AppendTextRow(ref tier, ref sb, "}");
            return sb.ToString();
        }
    }
}
