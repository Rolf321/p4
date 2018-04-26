using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimShitty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            // setup block.
            RoadNetwork roadNetwork = new RoadNetwork();
            roadNetwork.Connections.Add(new Connection("UL")); 
            roadNetwork.Connections.Add(new Connection("UR"));
            roadNetwork.Connections.Add(new Connection("DL"));
            roadNetwork.Connections.Add(new Connection("DR"));
            roadNetwork.Connections.Add(new Connection("M"));

            roadNetwork.Roads.Add(new Road("UL_UR", 100000, 80));    
            roadNetwork.Roads.Add(new Road("UR_DR", 10000, 80));    
            roadNetwork.Roads.Add(new Road("DL_DR", 20000, 80));
            roadNetwork.Roads.Add(new Road("UL_DL", 1000, 80)); 
            roadNetwork.Roads.Add(new Road("UL_M", 11000, 50));
            roadNetwork.Roads.Add(new Road("UR_M", 20000, 50));       
            roadNetwork.Roads.Add(new Road("M_DR", 5000, 50));       
            roadNetwork.Roads.Add(new Road("M_DL", 5000, 50));      
            
            roadNetwork.Connections[0].Roads.Add(roadNetwork.Roads[0]);
            roadNetwork.Connections[0].Roads.Add(roadNetwork.Roads[3]);
            roadNetwork.Connections[0].Roads.Add(roadNetwork.Roads[4]);
            roadNetwork.Connections[1].Roads.Add(roadNetwork.Roads[0]);
            roadNetwork.Connections[1].Roads.Add(roadNetwork.Roads[1]);
            roadNetwork.Connections[1].Roads.Add(roadNetwork.Roads[5]);
            roadNetwork.Connections[2].Roads.Add(roadNetwork.Roads[2]);
            roadNetwork.Connections[2].Roads.Add(roadNetwork.Roads[3]);
            roadNetwork.Connections[2].Roads.Add(roadNetwork.Roads[7]);
            roadNetwork.Connections[3].Roads.Add(roadNetwork.Roads[1]);
            roadNetwork.Connections[3].Roads.Add(roadNetwork.Roads[2]);
            roadNetwork.Connections[3].Roads.Add(roadNetwork.Roads[6]);
            roadNetwork.Connections[4].Roads.Add(roadNetwork.Roads[4]);
            roadNetwork.Connections[4].Roads.Add(roadNetwork.Roads[5]);
            roadNetwork.Connections[4].Roads.Add(roadNetwork.Roads[6]);
            roadNetwork.Connections[4].Roads.Add(roadNetwork.Roads[7]);
            // End of setup block.

            // Release the automobiles!
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)])
            };
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));

            // AStar class informal test:
            vehicles[0].StartLocation = roadNetwork.Connections[0];
            vehicles[0].Destination = roadNetwork.Connections[1];
            AStar.DoMagicStuff(vehicles.First(),roadNetwork);

            // Simulation loop:
            while (true)
            {
                foreach (Vehicle v in vehicles)
                {
                    Console.WriteLine(v.UpdateLocation(R.Next(), roadNetwork.Connections));
                }   
                Console.ReadKey();
            }
        }
    }
}
