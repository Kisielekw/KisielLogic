using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class XOrGate:Gate2Input
    {
        public XOrGate(string pName) : base(pName)
        {

        }

        public override void Update()
        {
            state = inputGates[0].State ^ inputGates[1].State;
            UpdateConnected();
        }

        public override string ToString()
        {
            string outputGates = "";
            foreach (Gate gate in connectedGates)
            {
                outputGates += "," + gate.Name;
            }
            return "XOrGate," + Name + outputGates;
        }
    }
}
