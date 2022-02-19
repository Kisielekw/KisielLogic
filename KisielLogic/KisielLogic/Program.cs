using System;

namespace KisielLogic
{
    class Program
    {
        static void Main()
        {
            Lever switchA = new Lever("SwitchA");
            Lever switchB = new Lever("SwitchB");

            AndGate andGateA = new AndGate("andGateA");

            switchA.ConnectOutputObject(andGateA);
            switchB.ConnectOutputObject(andGateA);

            Console.WriteLine(andGateA.State);

            switchA.ToggleLever();
            switchB.ToggleLever();

            Console.WriteLine(andGateA.State);

            switchB.ToggleLever();

            Console.WriteLine(andGateA.State);
        }
    }
}
