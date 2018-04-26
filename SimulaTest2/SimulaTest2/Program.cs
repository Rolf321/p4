using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulaTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            // setup block.
            RoadNetwork roadNetwork = new RoadNetwork();
            roadNetwork.Connections.Add(new Connection("ØV")); 
            roadNetwork.Connections.Add(new Connection("ØH"));
            roadNetwork.Connections.Add(new Connection("NV"));
            roadNetwork.Connections.Add(new Connection("NH"));
            roadNetwork.Connections.Add(new Connection("M"));

            roadNetwork.Roads.Add(new Road("ØV_ØH", 10000, 80));    // 0
            roadNetwork.Roads.Add(new Road("ØH_NH", 10000, 80));    // 1
            roadNetwork.Roads.Add(new Road("NV_NH", 10000, 80));    // 2
            roadNetwork.Roads.Add(new Road("ØV_NV", 10000, 80));    // 3
            roadNetwork.Roads.Add(new Road("ØV_M", 5000, 50));      // 4 
            roadNetwork.Roads.Add(new Road("ØH_M", 5000, 50));      // 5 
            roadNetwork.Roads.Add(new Road("M_NH", 5000, 50));      // 6 
            roadNetwork.Roads.Add(new Road("M_NV", 5000, 50));      // 7 
            
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
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));
            //vehicles.Add(new Vehicle(roadNetwork.Connections[R.Next(0, roadNetwork.Connections.Count)]));


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
