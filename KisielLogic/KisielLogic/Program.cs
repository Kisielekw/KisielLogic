using System;

namespace KisielLogic
{
    class Program
    {
        static void Main()
        {
            Lever switchA = new Lever("switchA");
            Lever switchB = new Lever("switchB");
            Lever switchC = new Lever("switchC");
            AndGate AB = new AndGate("A and B");
            NotGate nC = new NotGate("Not C");
            OrGate ABonC = new OrGate("AB or nC");
            NotGate nAbonC = new NotGate("not ABonC");

            switchA.ConnectOutputObject(AB);
            switchB.ConnectOutputObject(AB);
            switchC.ConnectOutputObject(nC);
            AB.ConnectOutputObject(ABonC);
            nC.ConnectOutputObject(ABonC);
            ABonC.ConnectOutputObject(nAbonC);

            switchA.ToggleLever();
            switchC.ToggleLever();

            Console.WriteLine(nAbonC.State);

            switchC.ToggleLever();

            Console.WriteLine(nAbonC.State);

        }
    }
}
