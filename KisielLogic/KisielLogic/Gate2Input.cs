using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class Gate2Input
    {
        protected bool gateOutput;

        private string objectName;

        protected int[] gateType;

        protected Lever lever1;
        protected Lever lever2;
        protected AndGate andGate1;
        protected AndGate andGate2;
        protected OrGate orGate1;
        protected OrGate orGate2;
        protected NotGate notGate1;
        protected NotGate notGate2;

        protected List<AndGate> connectedAndGates;
        protected List<OrGate> connectedOrGates;
        protected List<NotGate> connectedNotGates;

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

        protected Gate2Input(string pName)
        {
            connectedAndGates = new List<AndGate>();
            connectedOrGates = new List<OrGate>();
            connectedNotGates = new List<NotGate>();

            gateType = new int[2] { -1, -1 };
            objectName = pName;
        }

        public bool ConnectInputObject(Lever pLever)
        {
            if(gateType[0] == -1)
            {
                gateType[0] = 0;
                lever1 = pLever;
                return true;
            }
            else if(gateType[1] == -1)
            {
                gateType[1] = 0;
                lever2 = pLever;
                return true;
            }
            return false;
        }
        public bool ConnectInputObject(AndGate pAndGate)
        {
            if (gateType[0] == -1)
            {
                gateType[0] = 1;
                andGate1 = pAndGate;
                return true;
            }
            else if (gateType[1] == -1)
            {
                gateType[1] = 1;
                andGate2 = pAndGate;
                return true;
            }
            return false;
        }
        public bool ConnectInputObject(OrGate pOrGate)
        {
            if (gateType[0] == -1)
            {
                gateType[0] = 2;
                orGate1 = pOrGate;
                return true;
            }
            else if (gateType[1] == -1)
            {
                gateType[1] = 2;
                orGate2 = pOrGate;
                return true;
            }
            return false;
        }
        public bool ConnectInputObject(NotGate pNotGate)
        {
            if (gateType[0] == -1)
            {
                gateType[0] = 3;
                notGate1 = pNotGate;
                return true;
            }
            else if (gateType[1] == -1)
            {
                gateType[1] = 3;
                notGate2 = pNotGate;
                return true;
            }
            return false;
        }

        protected void UpdateConnected()
        {
            foreach(AndGate and in connectedAndGates)
            {
                and.Update();
            }
            foreach(OrGate or in connectedOrGates)
            {
                or.Update();
            }
            foreach(NotGate not in connectedNotGates)
            {
                not.Update();
            }
        }
    }
}
