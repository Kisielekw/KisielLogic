using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class Lever:Gate
    {
        public Lever(string pName):base(pName)
        {
            state = false;
        }

        public override void ToggleLever()
        {
            state = !state;

            UpdateConnected();
        }

        public override void Update()
        {
            UpdateConnected();
        }

        public override bool ConnectInputObject(Gate pInputGate)
        {
            return false;
        }

        public override string ToString()
        {
            string outputGates = "";
            foreach (Gate gate in connectedGates)
            {
                outputGates += "," + gate.Name;
            }
            return "Lever," + Name + outputGates;
        }
    }
}
