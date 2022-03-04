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

        public override void Update()
        {
            state = !InputGate.State;
            UpdateConnected();
        }
    }
}
