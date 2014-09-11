using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mca2vmf;

namespace mca2vmfExample
{
    public class Example
    {
        static bool inDebug = false;
        [STAThread]
        public static void Main(string[] args)
        {
            Decimal xzStart = 0;
            Decimal xzEnd = 0;
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
            if (args.Length < 4 || string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1]) || args[2] == null || args[3] == null)
            {
                HelpText(args);
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (!Decimal.TryParse(args[2], out xzStart))
            {
                Console.WriteLine("Error: XZCoordinateStart could not be converted to Decimal type (invalid?)");
                Console.ReadLine();
                Environment.Exit(0);
            }
            if (!Decimal.TryParse(args[3], out xzEnd))
            {
                Console.WriteLine("Error: XZCoordinateEnd could not be converted to Decimal type (invalid?)");
                Console.ReadLine();
                Environment.Exit(0);
            }
            //Load File
            Console.WriteLine("Loading Minecraft files...");
            if (!ConvertFile.LoadWorld(args[0]))
            {
                Console.WriteLine("Unknowen error reading Minecraft files.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Minecraft files loaded.");
            Console.WriteLine("Minecraft files parseing...");
            if (!ConvertFile.ParseWorld(xzStart, xzEnd))
            {
                Console.WriteLine("Unknowen error parcing minecraft files.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Minecraft files parsed.");
            Console.ReadLine();
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
            Console.WriteLine("3: \"XZCoordinateStart\"\t - Where will the converted map start?");
            Console.WriteLine("4: \"XZCoordinateEnd\"\t - Where will the converted map end?");
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
