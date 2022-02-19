using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisielLogic
{
    class Lever
    {
        private bool leverPosition;
        //private Dictionary<string, AndGate> connectedAndGates;
        //private Dictionary<string, OrGate> connectedOrGates;
        //private Dictionary<string, NotGate> connectedNotGates;

        public bool State
        {
            get
            {
                return leverPosition;
            }
        }

        public Lever()
        {
            leverPosition = false;
        }

        public void ToggleLever()
        {
            leverPosition = !leverPosition;
        }
    }
}
