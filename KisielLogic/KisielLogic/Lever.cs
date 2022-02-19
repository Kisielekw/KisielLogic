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

        private string objectName;

        private List<AndGate> connectedAndGates;
        private List<OrGate> connectedOrGates;
        //private Dictionary<string, NotGate> connectedNotGates;

        public bool State
        {
            get
            {
                return leverPosition;
            }
        }
        public string Name
        {
            get
            {
                return objectName;
            }
        }

        public Lever(string pName)
        {
            connectedAndGates = new List<AndGate>();
            connectedOrGates = new List<OrGate>();

            objectName = pName;
            leverPosition = false;
        }

        private void UpdateConnected()
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

        public void ToggleLever()
        {
            leverPosition = !leverPosition;

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
    }
}
