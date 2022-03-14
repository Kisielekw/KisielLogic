using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class NOrGate:Gate2Input
    {
        public NOrGate(string pName) : base(pName)
        {

        }

        public override void Update()
        {
            state = !(inputGates[0].State || inputGates[1].State);

            UpdateConnected();
        }
    }
}
