using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynovox
{
    public class Voxset
    {
        public int[, ,] IdArray { get; set; }

        /// <summary>
        /// The type ID of the block from the voxel program
        /// (0 to 4,294,967,295)
        /// </summary>
        private uint[, ,] typeID;

        /// <summary>
        /// A binary value (use bit shift to get values)
        /// 
        /// bits   1/2: X position of cube (spin)
        /// bits   3/4: Y position of cube (spin)
        /// bits   5/6: Z position of cube (spin)
        /// bits  7/10: State (steps,fence, pic)
        /// bit     11: Simple (full non-transparent box)
        /// bits 12/32: Reserved
        /// </summary>
        private uint[, ,] extraInfo;

        /// <summary>
        /// GUID of the object grouping (128 bit random values)
        /// </summary>
        private Guid[, ,] groupID;

        public Voxset()
        {
            IdArray = new int[0, 0, 0];
            typeID = new uint[0, 0, 0];
            extraInfo = new uint[0, 0, 0];
            groupID = new Guid[0, 0, 0];
        }

        public Voxset(int topX, int topZ, int topY)
        {
            IdArray = new int[topX, topZ, topY];
            typeID = new uint[topX, topZ, topY];
            extraInfo = new uint[topX, topZ, topY];
            groupID = new Guid[topX, topZ, topY];
        }

        public uint getTypeID(int x, int y, int z)
        {
            return typeID[x, y, z];
        }

        public uint getRawExtraInfo(int x, int y, int z)
        {
            return extraInfo[x, y, z];
        }

        public Guid getGroupID(int x, int y, int z)
        {
            return groupID[x, y, z];
        }

        /// <summary>
        /// Check if simple (full non-transparent box)
        /// (check on bit 11)
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <returns>True if simple</returns>
        public bool isSimple(int x, int y, int z)
        {
            return (extraInfo[x, y, z] & 1024) != 0;
        }

        /// <summary>
        /// Get the direction that the block faces on plain X
        /// (check on bits 1/2)
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <returns>Zero to four</returns>
        public byte getXPOS(int x, int y, int z)
        {
            return (byte)((extraInfo[x, y, z] & 1) + (extraInfo[x, y, z] & 2));
        }

        /// <summary>
        /// Get the direction that the block faces on plain Y
        /// (check on bits 3/4)
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <returns>Zero to four</returns>
        public byte getYPOS(int x, int y, int z)
        {
            return (byte)((extraInfo[x, y, z] & 4) + (extraInfo[x, y, z] & 8));
        }

        /// <summary>
        /// Get the direction that the block faces on plain Z
        /// (check on bits 5/6)
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <returns>Zero to four</returns>
        public byte getZPOS(int x, int y, int z)
        {
            return (byte)((extraInfo[x, y, z] & 16) + (extraInfo[x, y, z] & 32));
        }

        /// <summary>
        /// Gets the state of object at location
        /// (check on bits 7/10)
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <returns>Zero to 255</returns>
        public byte getState(int x, int y, int z)
        {
            return (byte)((extraInfo[x, y, z] & 64) + (extraInfo[x, y, z] & 128) + (extraInfo[x, y, z] & 256) + (extraInfo[x, y, z] & 512));
        }

    }
}
