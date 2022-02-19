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

        public void Update()
        {
            bool inputState = false;

            switch (gateType)
            {
                case 0:
                    inputState = leverInput.State;
                    break;
                case 1:
                    inputState = andGateInput.State;
                    break;
                case 2:
                    inputState = orGateInput.State;
                    break;
                case 3:
                    inputState = notGateInput.State;
                    break;
                case -1:
                    inputState = false;
                    break;
            }

            gateOutput = !inputState;
            UpdateConnected();
        }

        public void ConnectOutputObject(AndGate pAndGate)
        {
            if (pAndGate.ConnectInputObject(this))
            {
                connectedAndGates.Add(pAndGate);
            }
            else
            {
                Console.WriteLine("Unable to Connect Objects");
            }
        }
        public void ConnectOutputObject(OrGate pOrGate)
        {
            if (pOrGate.ConnectInputObject(this))
            {
                connectedOrGates.Add(pOrGate);
            }
            else
            {
                Console.WriteLine("Unable to Connect Objects");
            }
        }
        public void ConnectOutputObject(NotGate pNotGate)
        {
            if (pNotGate.ConnectInputObject(this))
            {
                connectedNotGates.Add(pNotGate);
            }
            else
            {
                Console.WriteLine("Unable to Connect Objects");
            }
        }
    }
}
