using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class OrGate:Gate2Input
    {
        public OrGate(string pName) : base(pName)
        {

        }

        public override void Update()
        {
            bool state1 = inputGates[0].State;
            bool state2 = inputGates[1].State;

            state = state1 || state2;

            UpdateConnected();
        }

        public override string ToString()
        {
            string outputGates = "";
            foreach (Gate gate in connectedGates)
            {
                outputGates += "," + gate.Name;
            }
            return "OrGate," + Name + outputGates;
        }
    }
}
