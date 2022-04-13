using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class NotGate:Gate1Input
    {
        public NotGate(string pName) : base(pName)
        {

        }

        public override void Update()
        {
            state = !InputGate.State;
            UpdateConnected();
        }

        public override string ToString()
        {
            string outputGates = "";
            foreach (Gate gate in connectedGates)
            {
                outputGates += "," + gate.Name;
            }
            return "NotGate," + Name + outputGates;
        }
    }
}
