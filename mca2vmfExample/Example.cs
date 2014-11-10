using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using mca2vmf;

namespace mca2vmfExample
{
    public class Example
    {
        static bool inDebug = false;
        [STAThread]
        public static void Main(string[] args)
        {
            int xStart = 0;
            int zStart = 0;
            int xEnd = 0;
            int zEnd = 0;
            int yTop = 256;
            int yBottom = 0;
#if DEBUG
            inDebug = true;
#endif
            if (inDebug)
            {
                Console.WriteLine("Parameters: {0}", args.Length);
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("Argument [{0}][{1}]", i, args[i]);
                }
            }
            //IF nothing found run help text
            if (args.Length < 6 || string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1]) || args[2] == null || args[3] == null)
            {
                HelpText(args);
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!int.TryParse(args[2], out xStart))
            {
                Console.WriteLine("Error: XCoordinateStart ({0}) could not be converted to int type (invalid?)", args[2]);
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (!int.TryParse(args[3], out zStart))
            {
                Console.WriteLine("Error: ZCoordinateStart ({0}) could not be converted to int type (invalid?)", args[3]);
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (!int.TryParse(args[4], out xEnd))
            {
                Console.WriteLine("Error: XCoordinateEnd ({0}) could not be converted to int type (invalid?)", args[4]);
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (!int.TryParse(args[5], out zEnd))
            {
                Console.WriteLine("Error: ZCoordinateEnd ({0}) could not be converted to int type (invalid?)", args[5]);
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (args.Length == 8)
            {
                if (!int.TryParse(args[6], out yTop))
                {
                    Console.WriteLine("Error: YHightMax ({0}) could not be converted to int type (invalid?)", args[6]);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                if (!int.TryParse(args[7], out yBottom))
                {
                    Console.WriteLine("Error: YHightMin ({0}) could not be converted to int type (invalid?)", args[7]);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            //Load File
            Console.WriteLine("Loading Minecraft files...");
            if (!ConvertFile.LoadWorld(args[0]))
            {
                Console.WriteLine("Unknowen error reading Minecraft files.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Minecraft files loaded. Setting Bounds...");
                ConvertFile.SetWorldBounds(xStart * 16, zStart * 16, xEnd * 16, zEnd * 16, yTop, yBottom);
                Console.WriteLine("Bounds set. Building quick Ref ID Index...");
                Stopwatch s1 = Stopwatch.StartNew();
                ConvertFile.BuildIdIndex();
                s1.Stop();
                Console.WriteLine("Quick Ref ID Index built [{0}]", s1.Elapsed.ToString());
            }
            //Console.WriteLine("Minecraft files trimming...");
            //if (!ConvertFile.TrimWorld())
            //{
            //    Console.WriteLine("Unknowen error trimming minecraft files.");
            //    Console.ReadLine();
            //    Environment.Exit(0);
            //}
            //Console.WriteLine("Minecraft files trimed.");
            Console.ReadLine();
            //Test Create Boxes
            Stopwatch s2 = Stopwatch.StartNew();
            ConvertFile.GenerateTestBoxSet();
            s2.Stop();
            Console.WriteLine("Quick Ref ID Index built [{0}]", s2.Elapsed.ToString());
            Console.ReadLine();

            //Test VMF generation
            Console.WriteLine("Testing VMF text generation...");
            StringBuilder testingText = ConvertFile.TestVMFGeneration();
            Console.WriteLine(testingText.ToString());
            Console.WriteLine("Saving File...");
            ConvertFile.TestVMFGeneration(testingText, args[1]);
            Console.WriteLine("...");
            //Console.ReadLine();
        }

        private static void HelpText(string[] args)
        {
            Console.WriteLine("mca2vmf - Example Help");
            Console.WriteLine(" ");
            Console.WriteLine("This example program will (limitedly) convert a mca (Minecraft) file");
            Console.WriteLine("to a (Valve CS/TF2/ext Hammer map editor) vmf file.");
            Console.WriteLine("");
            Console.WriteLine("Call using the parameters  (order matters):");
            Console.WriteLine("");
            Console.WriteLine("1: \"PathToMCLevelFiles\"\t - Where is the level.dat ext, found?");
            Console.WriteLine("2: \"PathToVMF\"\t\t - Where will the output Valve Map will be saved?");
            Console.WriteLine("3: \"XCoordinateStart\"\t - What chunk X will the converted map start?");
            Console.WriteLine("4: \"ZCoordinateStart\"\t - What chunk Z will the converted map start?");
            Console.WriteLine("5: \"XCoordinateEnd\"\t - What chunk X will the converted map end?");
            Console.WriteLine("6: \"ZCoordinateEnd\"\t - What chunk Z will the converted map end?");
            Console.WriteLine("7: \"YHightMax\"\t - Top of the map? (optional)");
            Console.WriteLine("8: \"YHightMin\"\t - Bottom of the map? (optional)");
            Console.WriteLine("");
            Console.WriteLine("NOTE:");
            Console.WriteLine(" A: If you parameters have spaces use quotes around the value.");
            Console.WriteLine(" B: The start and end coordinates are needed, they together create a box ");
            Console.WriteLine("    only the ariea within your box is converted (all hight will be imported).");
            Console.WriteLine("    VFM can not handle large mincraft maps, the XZ allows you to restrict");
            Console.WriteLine("    the size and only convert what you need to VMF.");
        }
    }
}
