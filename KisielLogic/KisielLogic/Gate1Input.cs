using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    abstract class Gate1Input:Gate
    {

        protected Gate InputGate;

        protected Gate1Input(string pName):base(pName)
        {
            
        }

        /// <summary>
        /// Conects a Gates output into the input of this gate
        /// Returns True if it was able to connect and False otherwise
        /// </summary>
        /// <param name="pInputGate">The gate that outputs into this gate</param>
        /// <returns></returns>
        public override bool ConnectInputObject(Gate pInputGate)
        {
            if (InputGate == null)
            {
                InputGate = pInputGate;
                Update();
                return true;
            }
            return false;
        }
    }
}
