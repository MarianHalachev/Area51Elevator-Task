

namespace Area51Elevator_Task_Threaded
{
    public class Program
    {
        static (string Name, string SecurityLevel) agent;

        static void Main(string[] args)
        {
            Random random = new Random();
            int currentFloor = 1;
            Console.WriteLine($"Current floor {currentFloor}");
            for (int i = 0; i < random.Next(1, 20); i++)
            {
                Console.WriteLine("Agent entered the elevator.");
                Console.WriteLine();

                Thread agentThread = new Thread(() => MakeAgent());
                agentThread.Start();
                agentThread.Join();

                Thread elevatorThread = new Thread(() => Elevator(agent.SecurityLevel, currentFloor));
                elevatorThread.Start();
                elevatorThread.Join();

                Console.WriteLine("====================================");
            }

            Console.WriteLine("The base is closed!");
        }

        public static void MakeAgent()
        {

            Random rnd = new Random();
            Entities entities = new Entities();
            var random = new Random();
            agent.Name = entities.agentNames[random.Next(entities.agentNames.Count)];
            agent.SecurityLevel = entities.agentsClearenceLevels[random.Next(entities.agentsClearenceLevels.Count)];
            Console.WriteLine($"Agent name: {agent.Name}");
            Console.WriteLine($"Clearence level: {agent.SecurityLevel}");
        }

        public static bool ClearanceCheck(string securityLevel, int floor)
        {
            if (agent.SecurityLevel == "Confidential" && floor == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Security check passed. The elevator door is opening and the agent leaves the elevator.");
                Console.WriteLine();
                return true;
            }

            if (agent.SecurityLevel == "Secret" && (floor == 1 || floor == 2))
            {
                Console.WriteLine();
                Console.WriteLine("Security check passed. The elevator door is opening and the agent leaves the elevator.");
                Console.WriteLine();
                return true;
            }

            if (agent.SecurityLevel == "Top-Secret" && (floor == 1 || floor == 2 || floor == 3 || floor == 4))
            {
                Console.WriteLine();
                Console.WriteLine("Security check passed. The elevator door is opening and the agent leaves the elevator.");
                Console.WriteLine();
                return true;
            }

            Console.WriteLine();
            Console.WriteLine("Security check failed. Please choose another floor!");
            return false;
        }

        public static void Elevator(string securityLevel, int currentFloor)
        {
            int selectedFloor = 0;
            do
            {
                Random rnd = new Random();
                Console.WriteLine("Choose floor: G[1], S[2], T1[3], T2[4]");
                selectedFloor = rnd.Next(1, 5);
                Console.Write($"Going to floor {selectedFloor} ");
                for (int j = 0; j < Math.Abs(selectedFloor - currentFloor); j++)
                {
                    Console.WriteLine();
                    Console.Write("-");
                    Thread.Sleep(1000);
                }

                Console.WriteLine();
                currentFloor = selectedFloor;
                Console.WriteLine($"Arrived to floor {currentFloor}");
            } while (ClearanceCheck(securityLevel, selectedFloor) == false);
        }
    }
}