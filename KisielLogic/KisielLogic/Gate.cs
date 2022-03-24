using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    /// <summary>
    /// The Base abstract class to every gate and lever
    /// Contains most of the code required to connect and interact between gates
    /// </summary>
    abstract class Gate
    {
        protected bool state;
        protected string name;

        /// <summary>
        /// The curent output of the gate
        /// </summary>
        public bool State
        {
            get
            {
                return state;
            }
        }
        /// <summary>
        /// The name the user has given to the gate
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        protected List<Gate> connectedGates;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName">The you give to the gate to easily identify the gate</param>
        public Gate(string pName)
        {
            connectedGates = new List<Gate>();

            name = pName;
        }

        public abstract bool ConnectInputObject(Gate pInputGate);

        /// <summary>
        /// Connecting the output of the gate to the input of another
        /// </summary>
        /// <param name="pGate">The gate you would like to connect this gate to</param>
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

        /// <summary>
        /// Updates the gates output by looking at its input
        /// </summary>
        public abstract void Update();

        protected void UpdateConnected()
        {
            foreach (Gate gate in connectedGates)
            {
                gate.Update();
            }
        }

        public virtual void ToggleLever()
        {
            throw new Exception("Can't toggle a gate\nThis command is only available for Lever objects");
        }
    }
}
