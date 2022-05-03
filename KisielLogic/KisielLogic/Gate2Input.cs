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

        protected Gate2Input(string pName, string gateType):base(pName, gateType)
        {
            inputGates = new Gate[2];
        }

        /// <summary>
        /// Connects a gate to the input of this gate
        /// Returns True if it was succesfull and False otherwise
        /// </summary>
        /// <param name="pInputGate">The gate that outputs into this gate</param>
        /// <returns></returns>
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
                Update();
                return true;
            }
            return false;
        }
    }
}
