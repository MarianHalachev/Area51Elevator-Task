using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51Elevator_Task_Threaded
{
    public class Entities
    {
        public List<string> agentsClearenceLevels { get; set; } = new List<string>()
        {
            "Confidential",
            "Secret",
            "Top-Secret"
        };

        public List<string> agentNames { get; set; } = new List<string>()
        {
            //Randomly generated names
            "Smith",
            "Johnson",
            "Williams",
            "Brown",
            "Thompson",
            "Davis",
            "Martinez",
            "Anderson",
            "Taylor",
            "Garcia",
            "Jones",
            "White",
            "Harris",
            "Clark",
            "Lewis",
            "Hall",
            "Lee",
            "King",
            "Turner",
            "Scott",
            "Murphy",
            "Makarov",
            "Pinkman"

        };
    }
}
