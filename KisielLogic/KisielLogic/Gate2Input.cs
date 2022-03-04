using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    abstract class Gate2Input:Gate
    {

        protected Gate[] inputGates;

        protected Gate2Input(string pName):base(pName)
        {
            inputGates = new Gate[2];
        }

        public override bool ConnectInputObject(Gate pInputGate)
        {
            if(inputGates[0] == null)
            {
                inputGates[0] = pInputGate;
                return true;
            }
            else if(inputGates[1] == null)
            {
                inputGates[1] = pInputGate;
                return true;
            }
            return false;
        }
    }
}
