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

        public Gate1Input(string pName):base(pName)
        {
            
        }

        public override bool ConnectInputObject(Gate pInputGate)
        {
            if (InputGate != null)
            {
                InputGate = pInputGate;
                return true;
            }
            return false;
        }
    }
}
