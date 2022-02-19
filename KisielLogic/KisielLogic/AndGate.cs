using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class AndGate : Gate2Input
    {

        public AndGate(string pName) : base(pName)
        {

        }

        public void Update()
        {
            bool state1 = false;
            bool state2 = false;

            switch (gateType[0])
            {
                case 0:
                    state1 = lever1.State;
                    break;
                case 1:
                    state1 = andGate1.State;
                    break;
                case 2:
                    state1 = orGate1.State;
                    break;
                case -1:
                    state1 = false;
                    break;
            }
            switch (gateType[1])
            {
                case 0:
                    state2 = lever2.State;
                    break;
                case 1:
                    state2 = andGate2.State;
                    break;
                case 2:
                    state2 = orGate2.State;
                    break;
                case -1:
                    state2 = false;
                    break;
            }

            gateOutput = state1 && state2;

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
