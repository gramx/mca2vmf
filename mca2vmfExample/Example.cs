using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mca2vmfExample
{
    public class Example
    {
        static bool inDebug = false;
        [STAThread]
        public static void Main(string[] args)
        {
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
            if (args.Length == 0)
            {
                HelpText(args);
            }

            //Get file


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
            Console.WriteLine("1: \"PathToMCA\"\t\t - Where is the Mincraft map located?");
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
