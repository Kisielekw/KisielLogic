using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    abstract class Gate
    {
        protected bool state;
        protected string name;

        public bool State
        {
            get
            {
                return state;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        protected List<Gate> connectedGates;

        public Gate(string pName)
        {
            connectedGates = new List<Gate>();

            name = pName;
        }

        public abstract bool ConnectInputObject(Gate pInputGate);
        public void ConnectOutputObject(Gate pGate)
        {
            if (pGate.ConnectInputObject(this))
            {
                connectedGates.Add(pGate);
            }
            else
            {
                Console.WriteLine("Unable to Connect Objects");
            }
        }

        public abstract void Update();

        protected void UpdateConnected()
        {
            foreach (Gate gate in connectedGates)
            {
                gate.Update();
            }
        }
    }
}
