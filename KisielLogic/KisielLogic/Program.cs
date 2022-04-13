using System;
using System.Collections.Generic;
using System.IO;

namespace KisielLogic
{
    class Program
    {
        static List<Gate> listOfGates = new List<Gate>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Create a new gate");
                Console.WriteLine("2. Conect 2 gates together");
                Console.WriteLine("3. Save the currnet circuit");
                Console.WriteLine("4. Load a circuit");
                Console.WriteLine("5. Exit the program");
                int answer = SelectValue(1, 5);

                if(answer == 5)
                {
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    break;
                }
                else if(answer == 1)
                {
                    Console.WriteLine("1. Create Switch");
                    Console.WriteLine("2. Create And Gate");
                    Console.WriteLine("3. Create Or Gate");
                    Console.WriteLine("4. Create Not Gate");
                    Console.WriteLine("5. Create NAnd Gate");
                    Console.WriteLine("6. Create NOr Gate");
                    Console.WriteLine("7. Create XOr Gate");
                    answer = SelectValue(1, 7);
                    switch (answer)
                    {
                        case 1:
                            listOfGates.Add(CreateSwitch());
                            break;
                        case 2:
                            listOfGates.Add(CreateAnd());
                            break;
                        case 3:
                            listOfGates.Add(CreateOr());
                            break;
                        case 4:
                            listOfGates.Add(CreateNot());
                            break;
                        case 5:
                            listOfGates.Add(CreateNAnd());
                            break;
                        case 6:
                            listOfGates.Add(CreateNOr());
                            break;
                        case 7:
                            listOfGates.Add(CreateXOr());
                            break;
                    }
                }
                else if(answer == 2)
                {
                    Console.Write("Enter the name of the first gate: ");
                    string name = Console.ReadLine();
                    Gate gate1 = FindGate(name);
                    if (gate1 == null)
                    {
                        Console.WriteLine("No gate with this name was found");
                        Continue();
                        continue;
                    }
                    Console.Write("Enter the name of the second gate: ");
                    name = Console.ReadLine();
                    Gate gate2 = FindGate(name);
                    if(gate2 == null)
                    {
                        Console.WriteLine("No Gate with this name was found");
                        Continue();
                        continue;
                    }

                    gate1.ConnectOutputObject(gate2);
                    Console.WriteLine("Gates Conected");
                }
                else if(answer == 3)
                {
                    if(listOfGates.Count < 2)
                    {
                        Console.WriteLine("You need at least 2 Gates to save your circuit");
                        Continue();
                    }
                    string name = SelectName();
                    Directory.CreateDirectory("Circuits");
                    StreamWriter writeCircuit = new StreamWriter("Circuits\\" + name + ".gate");
                    foreach(Gate gate in listOfGates)
                    {
                        writeCircuit.WriteLine(gate);
                    }
                    writeCircuit.Close();
                }
                else if(answer == 4)
                {
                    string[] circuitFiles = Directory.GetFiles("Circuits", "*.gate");
                    Console.WriteLine("Available Circuits");
                    for(int i = 1; i <= circuitFiles.Length; i++)
                    {
                        Console.WriteLine(i + ". " + circuitFiles[i-1].Substring(9).Split('.')[0]);
                    }
                    Console.Write("Enter the name of the circuit you would like to choose: ");
                    string chooseCircuit =  Console.ReadLine();
                    if(new List<string>(circuitFiles).Contains("Circuits\\" + chooseCircuit + ".gate"))
                    {
                        LoadCircuit("Circuits\\" + chooseCircuit + ".gate");
                        Continue();
                    }
                    else
                    {
                        Console.WriteLine("This Circuit dosn't exist");
                        Continue();
                    }
                }
            }
        }

        static bool ValidNumberNumber(string pInput)
        {
            bool returnValue = true;
            if(pInput.Length < 1)
            {
                Console.WriteLine("No input please anser the question");
                returnValue =  false;
            }
            foreach(char c in pInput)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine("Value enterd is not a number");
                    returnValue = false;
                    break;
                }
            }
            return returnValue;
        }

        static int SelectValue(int pMinValue, int pMaxValue)
        {
            while (true) 
            {
                Console.Write("Select an option: ");
                string option = Console.ReadLine();
                if (ValidNumberNumber(option))
                {
                    if(int.Parse(option) < pMinValue || int.Parse(option) > pMaxValue)
                    {
                        Console.WriteLine("Value Entered not in range");
                    }
                    else
                    {
                        return int.Parse(option);
                    }
                }
            }
        }

        static string SelectName()
        {
            while (true)
            {
                Console.Write("Enter a name: ");
                string name = Console.ReadLine();
                if(name.Length < 1)
                {
                    Console.Write("The name has to be at least 1 character long");
                }
                else
                {
                    return name;
                }
            }
        }

        static Lever CreateSwitch()
        {
            string name = SelectName();
            Console.WriteLine("Switch Created");
            return new Lever(name);
        }

        static AndGate CreateAnd()
        {
            string name = SelectName();
            Console.WriteLine("And Gate Created");
            return new AndGate(name);
        }

        static OrGate CreateOr()
        {
            string name = SelectName();
            Console.WriteLine("Or Gate Created");
            return new OrGate(name);
        }

        static NotGate CreateNot()
        {
            string name = SelectName();
            Console.WriteLine("Not Gate Created");
            return new NotGate(name);
        }

        static NAndGate CreateNAnd()
        {
            string name = SelectName();
            Console.WriteLine("NAnd Gate Created");
            return new NAndGate(name);
        }

        static NOrGate CreateNOr()
        {
            string name = SelectName();
            Console.WriteLine("NOr Gate Created");
            return new NOrGate(name);
        }

        static XOrGate CreateXOr()
        {
            string name = SelectName();
            Console.WriteLine("XOr Gate Created");
            return new XOrGate(name);
        }

        static Gate FindGate(string pName)
        {
            foreach (Gate g in listOfGates)
            {
                if (g.Name == pName)
                {
                    return g;
                }
            }
            return null;
        }

        static void Continue()
        {
            Console.WriteLine("Press any button to continue: ");
            Console.ReadKey();
        }

        static bool LoadCircuit(string pPath)
        {
            string[] circuit = File.ReadAllLines(pPath);
            foreach (string gate in circuit)
            {
                string[] gateInfo = gate.Split(',');
                switch (gateInfo[0])
                {
                    case "Lever":
                        listOfGates.Add(new Lever(gateInfo[1]));
                        break;
                    case "AndGate":
                        listOfGates.Add(new AndGate(gateInfo[1]));
                        break;
                    case "OrGate":
                        listOfGates.Add(new OrGate(gateInfo[1]));
                        break;
                    case "NotGate":
                        listOfGates.Add(new NotGate(gateInfo[1]));
                        break;
                    case "NAndGate":
                        listOfGates.Add(new NAndGate(gateInfo[1]));
                        break;
                    case "NOrGate":
                        listOfGates.Add(new NOrGate(gateInfo[1]));
                        break;
                    case "XOrGate":
                        listOfGates.Add(new XOrGate(gateInfo[1]));
                        break;
                    default:
                        Console.WriteLine("Invlid file");
                        return false;
                }
            }

            foreach (string gate in circuit)
            {
                string[] gateInfo = gate.Split(',');
                for (int i = 2; i < gateInfo.Length; i++)
                {
                    Gate gate1 = FindGate(gateInfo[1]);
                    Gate gate2 = FindGate(gateInfo[i]);
                    if(gate1 == null || gate2 == null)
                    {
                        Console.WriteLine("Invalid file");
                        return false;
                    }
                    gate1.ConnectOutputObject(gate2);
                }
            }

            return true;
        }
    }
}
