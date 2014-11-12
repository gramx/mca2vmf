using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynovox
{
    public class Voxset
    {
        public int[,,] IdArray {get; set;}

        public Voxset()
        {
            IdArray = new int[0, 0, 0];
        }

        public Voxset(int topX, int topZ, int topY)
        {
            IdArray = new int[topX, topZ, topY];
        }

    }
}
