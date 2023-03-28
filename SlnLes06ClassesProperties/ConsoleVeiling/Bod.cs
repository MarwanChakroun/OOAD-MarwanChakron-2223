using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVeiling
{
    public class Bod
    {
        public int aanbod { get; set; }
        public Koper deelnemer { get; set; }

        public Bod(Koper kp, int bod)
        {
            aanbod = bod;
            deelnemer = kp;
        }

        public Bod()
        {
            aanbod = 0;
        }
    }
}
