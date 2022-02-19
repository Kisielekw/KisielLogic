using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class Gate1Input
    {
        protected bool gateOutput;
        private string objectName;

        public bool State
        {
            get
            {
                return gateOutput;
            }
        }
        public string Name
        {
            get
            {
                return objectName;
            }
        }

        protected int gateType;

        protected Lever leverInput;
        protected AndGate andGateInput;
        protected OrGate orGateInput;
        protected NotGate notGateInput;

        protected List<AndGate> connectedAndGates;
        protected List<OrGate> connectedOrGates;
        protected List<NotGate> connectedNotGates;

        public Gate1Input(string pName)
        {
            connectedAndGates = new List<AndGate>();
            connectedOrGates = new List<OrGate>();
            connectedNotGates = new List<NotGate>();

            gateType = -1;
            objectName = pName;
        }

        public bool ConnectInputObject(Lever pLever)
        {
            if (gateType == -1)
            {
                gateType = 0;
                leverInput = pLever;
                return true;
            }
            return false;
        }
        public bool ConnectInputObject(AndGate pAndGate)
        {
            if (gateType == -1)
            {
                gateType = 1;
                andGateInput = pAndGate;
                return true;
            }
            return false;
        }
        public bool ConnectInputObject(OrGate pOrGate)
        {
            if (gateType == -1)
            {
                gateType = 2;
                orGateInput = pOrGate;
                return true;
            }
            return false;
        }
        public bool ConnectInputObject(NotGate pNotGate)
        {
            if (gateType == -1)
            {
                gateType = 3;
                notGateInput = pNotGate;
                return true;
            }
            return false;
        }

        protected void UpdateConnected()
        {
            foreach (AndGate and in connectedAndGates)
            {
                and.Update();
            }
            foreach (OrGate or in connectedOrGates)
            {
                or.Update();
            }
        }

        
    }
}
