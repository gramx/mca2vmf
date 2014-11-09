using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Substrate;
using Substrate.Core;
using System.IO;
using mca2vmf.VolxClasses;
using Dynovox;
using ValardMapFormatConverter;

namespace mca2vmf
{
    public static class ConvertFile
    {
        private static NbtWorld importedWorld;
        private static List<SimpleChunkRef> TrimedChunks;
        private static int xOffset = 0;
        private static int yOffset = 0;
        private static int zOffset = 0;
        private static int xStart = 0;
        private static int yTop = 0;
        private static int zStart = 0;
        private static int xEnd = 0;
        private static int yBottom = 0;
        private static int zEnd = 0;

        /// <summary>
        /// Setup the bounds of the world
        /// </summary>
        /// <param name="StartX"></param>
        /// <param name="StartZ"></param>
        /// <param name="EndX"></param>
        /// <param name="EndZ"></param>
        /// <param name="TopY"></param>
        /// <param name="BottomY"></param>
        public static void SetWorldBounds(int StartX, int StartZ, int EndX, int EndZ, int TopY, int BottomY)
        {
            //Start should be smaller
            if (StartX > EndX)
            {
                xStart = EndX;
                xEnd = StartX;
            }
            else
            {
                xStart = StartX;
                xEnd = EndX;

            }
            //Start should be smaller
            if (StartZ > EndZ)
            {
                zStart = EndZ;
                zEnd = StartZ;
            }
            else
            {
                zStart = StartZ;
                zEnd = EndZ;
            }
            //Bottom should be smaller
            if (BottomY > yTop)
            {
                yTop = BottomY;
                yBottom = TopY;
            }
            else
            {
                yTop = TopY;
                yBottom = BottomY;

            }
            xOffset = xStart * -1;
            yOffset = yBottom * -1;
            zOffset = zStart * -1;
        }

        /// <summary>
        /// Loads the Mincraft world files into a Nbt file using Substrate
        /// </summary>
        /// <param name="inputPath">Location of Minecraft saved wold files</param>
        /// <returns>True if successfully loaded world</returns>
        public static bool LoadWorld(string inputPath)
        {
            importedWorld = NbtWorld.Open(inputPath);

            if (importedWorld != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Trims the world to work with only the chuncks within the coordents.
        /// </summary>
        /// <param name="xStart"></param>
        /// <param name="zStart"></param>
        /// <param name="xEnd"></param>
        /// <param name="zEnd"></param>
        /// <param name="yTop"></param>
        /// <param name="yBottom"></param>
        /// <returns></returns>
        public static bool TrimWorld()
        {
            //Clear trimmed chunks list
            TrimedChunks = new List<SimpleChunkRef>();
            
            //Get the higher X
            int HighX = xStart / 16;
            int LowX = xEnd / 16;
            if(xEnd > xStart)
            {
                HighX = xEnd / 16;
                LowX = xStart / 16;
            }
            //Get the higher Z
            int HighZ = zStart / 16;
            int LowZ = zEnd / 16;
            if(zEnd > zStart)
            {
                HighZ = zEnd / 16;
                LowZ = zStart / 16;
            }

            //Loop through world and grab chuncks
            IChunkManager cm = importedWorld.GetChunkManager();

            for (int x = LowX; x <= HighX; x++ )
            {
                for (int z = LowZ; z <= HighZ; z++)
                {
                    string signX = "+";
                    if (z < 0)
                    {
                        signX = "-";
                    }
                    string signZ = "+";
                    if (z < 0)
                    {
                        signZ = "-";
                    }
                    if(cm.ChunkExists(x,z))
                    {
                        IChunk chunk = cm.GetChunk(x, z);
                        Console.WriteLine("Saving: xz[{0}{1},{2}{3}]", signX, Math.Abs(x).ToString("D3"), signZ, Math.Abs(z).ToString("D3"));
                        TrimedChunks.Add(new SimpleChunkRef(x, z, chunk));
                    }
                    else
                    {
                        Console.WriteLine("No chunk found: xz[{0}{1},{2}{3}]", signX, Math.Abs(x).ToString("D3"), signZ, Math.Abs(z).ToString("D3"));
                        TrimedChunks.Add(new SimpleChunkRef(x, z, null));
                    }
                }
            }

            if (TrimedChunks.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Parse the world to output block IDs of intrest. (NOTE THIS IS TO BE REMOVED)
        /// </summary>
        /// <returns>False always</returns>
        public static bool ParseWorld()
        {
            // The chunk manager is more efficient than the block manager for
            // this purpose, since we'll inspect every block
            IChunkManager cm = importedWorld.GetChunkManager();

            foreach (ChunkRef chunk in cm)
            {
                int absY = 0;
                int absZ = 0;
                int absX = 0;
                string signX = "+";
                if (chunk.X < 0)
                {
                    signX = "-";
                }
                string signZ = "+";
                if (chunk.Z < 0)
                {
                    signZ = "-";
                }
                string chunkString = string.Format("C xz[{0}{1},{2}{3}]", signX, Math.Abs(chunk.X).ToString("D3"), signZ, Math.Abs(chunk.Z).ToString("D3"));
                
                // You could hardcode your dimensions, but maybe some day they
                // won't always be 16.  Also the CLR is a bit stupid and has
                // trouble optimizing repeated calls to Chunk.Blocks.xx, so we
                // cache them in locals
                int xdim = chunk.Blocks.XDim;
                int ydim = chunk.Blocks.YDim;
                int zdim = chunk.Blocks.ZDim;

                // Dont know why this was in the example...
                chunk.Blocks.AutoFluid = true;

                // x, z, y is the most efficient order to scan blocks
                // (not that you should care about internal detail)
                for (int x = 0; x < xdim; x++)
                {
                    for (int z = 0; z < zdim; z++)
                    {
                        for (int y = 0; y < ydim; y++)
                        {
                            BlockInfo info = chunk.Blocks.GetInfo(x, y, z);
                            if (info.ID != 0 && info.ID != 2 && info.ID != 3 && info.ID != 7)
                            {
                                absX = ((chunk.X * 16) + x);
                                absZ = ((chunk.Z * 16) + z);
                                absY = y;
                                Console.Write("{0} ", chunkString);
                                Console.Write("xyz[{0},{1},{2}] abs xyz[{3}{4},+{5},{6}{7}] ", x.ToString("D2"), y.ToString("D2"), z.ToString("D2"), signX, Math.Abs(absX).ToString("D4"), absY.ToString("D5"), signZ, Math.Abs(absZ).ToString("D5"));
                                Console.Write("{0} - '{1}'", info.ID.ToString("D4"), info.Name);
                                Console.Write("\n");
                            }
                        }
                    }
                }
            }



            return false;
        }

        /// <summary>
        /// Builds the quick reference array for converstion of Vox Data
        /// </summary>
        /// <returns></returns>
        public static bool BuildIdIndex()
        {
            // Build quick ID ref index array (map grid to closer to zero numbers)
            Voxset vs = new Voxset(xEnd + xOffset, yTop + yOffset, zEnd + zOffset);

            // The chunk manager is more efficient than the block manager for
            // this purpose, since we'll inspect every block
            IChunkManager cm = importedWorld.GetChunkManager();

            foreach (ChunkRef chunk in cm)
            
            {
                // You could hardcode your dimensions, but maybe some day they
                // won't always be 16.  Also the CLR is a bit stupid and has
                // trouble optimizing repeated calls to Chunk.Blocks.xx, so we
                // cache them in locals
                int xdim = chunk.Blocks.XDim;
                int ydim = chunk.Blocks.YDim;
                int zdim = chunk.Blocks.ZDim;

                // Dont know why this was in the example...
                chunk.Blocks.AutoFluid = true;

                // x, z, y is the most efficient order to scan blocks
                // (not that you should care about internal detail)
                for (int x = 0; x < xdim; x++)
                {
                    for (int z = 0; z < zdim; z++)
                    {
                        for (int y = 0; y < ydim; y++)
                        {
                            BlockInfo info = chunk.Blocks.GetInfo(x, y, z);
                            vs.IdArray[x + xOffset, y + yOffset, z + zOffset] = info.ID;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Test VMF text generation.
        /// </summary>
        /// <returns>The serialized VFM text</returns>
        public static StringBuilder TestVMFGeneration()
        {
            VMF testVMF = ValardMapFormatConverter.VMFConverter.SetupBasicVFM();

            return testVMF.Serialize();
        }

        /// <summary>
        /// Wright text to file.
        /// </summary>
        /// <returns>If save was successful this will return true</returns>
        public static bool TestVMFGeneration(StringBuilder fileTextStringBuilder, string outputFilePath)
        {
            // Write the stream contents to a new file named "AllTxtFiles.txt".
            using (StreamWriter outfile = new StreamWriter(outputFilePath + @"\mca2vmf_" + FileSafeDate() + @".txt"))
            {
                outfile.Write(fileTextStringBuilder.ToString());
            }

            return true;
        }

        private static string FileSafeDate()
        {
            return "Y" + DateTime.Now.Year.ToString("D4") + "M" + DateTime.Now.Month.ToString("D2") + "D" + DateTime.Now.Day.ToString("D2") + "h" + DateTime.Now.Hour.ToString("D2") + "m" + DateTime.Now.Hour.ToString("D2") + "s" + DateTime.Now.Second.ToString("D2") + "ms" + DateTime.Now.Millisecond.ToString("D4");
        }
    }
}
