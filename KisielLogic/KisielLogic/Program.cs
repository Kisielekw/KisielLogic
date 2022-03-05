using System;

namespace KisielLogic
{
    class Program
    {
        static void Main()
        {
            Lever Switch = new Lever("switch");
            NotGate notGate = new NotGate("not");
            Switch.ConnectOutputObject(notGate);

            Console.WriteLine(notGate.State);
        }
    }
}
