using System;
using System.Collections.Generic;
using System.Linq;

namespace SimShitty
{
    /// <summary>
    /// This class works as the "GPS" for a Vehicles in the simulation.
    /// Calculations are based on the A*-algorithm, where the heuristics
    /// considers the roads distance.Since no node(Connection)
    /// has direct coordinates, hueristics will be valued utilizing
    /// the Triangle Inequality Theorem(TIT).
    ///        
    /// The weight might later be changed to include time spend on the road.
    /// </summary>
    internal static class AStar
    {
        /// <summary>Nodes already visited</summary>
        private static List<Connection> _closedSet = new List<Connection>();
        /// <summary>Nodes not yet visited</summary>
        private static List<Connection> _openSet = new List<Connection>();
        /// <summary>Node_&lt;0&gt; can be reached most efficiently from Node_&lt;1&gt;</summary> 
        private static Dictionary<Connection, Connection> _cameFrom = new Dictionary<Connection, Connection>();
        /// <summary>Getting to Node_&lt;0&gt; costs double_&lt;1&gt;</summary> 
        private static Dictionary<Connection, double> _gScore = new Dictionary<Connection, double>();
        /// <summary>_gScore + heuristics for Node_&lt;0&gt; is double_&lt;1&gt;</summary>
        private static Dictionary<Connection, double> _fScore = new Dictionary<Connection, double>();

        /// <summary>
        /// The A*-pathfinding algorithm. 
        /// </summary>
        /// <param name="inputVehicle"></param>
        /// <param name="graph"></param>
        public static void DoMagicStuff(Vehicle inputVehicle, RoadNetwork graph)
        {
            /* Method description (A* Pathfinding):
             *
             * Prefix
             * - Reset all lists and dictionaries.
             *
             * 1. Populate dictionaries _gScore and _fScore.
             * 2. Take start-node from parsed Vehicle and
             *    include it in _openSet, and set its _gScore to 0.
             * 3. Calculate heuristics for start.
             * 4. While-loop: (_openSet not empty).
             * |     a. Current (Connection) = lowest _fScore from _openSet.
             * |     b. If Current is Goal = HURRAY (Give path to input (Vehicle)
             * |        and return out of method).
             * |     c. Remove Current from _openSet, add Current to _closedSet.
             * |     d. For each neighbour in Current.
             * |     |   i.   If neighbour is in _closedSet, GOTO next iteration.
             * |     |   ii.  Add neighbour to _openSet if not already there.
             * |     |   iii. Calculate weight from current to neighbour, store
             * |     |        this value temporarily.
             * |     |   iv.  If calculated wight is not lower than _gScore[neighbour]
             * |     |        then GOTO next iteration.
             * |     |   v.   _cameFrom[neighbour] = Current.
             * |     |   vi.  _gScore[neighbour] = calculated value from step iii.
             * |     |   vii. _fScore[neighbour] = _gScore[neighbour] + heuristics(neighbour).
             * 5. _openSet has been emptied, and no route from start to finish was found.
             */

            // Prefix
            _closedSet.Clear();
            _openSet.Clear();
            _cameFrom.Clear();
            _gScore.Clear();
            _fScore.Clear();

            // 1
            foreach (Connection c in graph.Connections)
            {
                _gScore.Add(c, double.PositiveInfinity);
                _fScore.Add(c, double.PositiveInfinity);
            }

            // 2
            _openSet.Add(inputVehicle.StartLocation);
            _gScore[inputVehicle.StartLocation] = 0;

            // 3 (Needs heuristics as well. Can be added when Heuristics() is done.)
            _fScore[inputVehicle.StartLocation] = _gScore[inputVehicle.StartLocation];

            // 4
            while (_openSet.Any())
            {
                // a
                Connection current = (from cPair in _fScore orderby cPair.Value select cPair.Key).Intersect(_openSet).First();

                // b
                if (current == inputVehicle?.Destination)
                {
                    //
                    inputVehicle.Route = Reconstruct_path(current);
                    return;
                }

                // c
                _openSet.Remove(current);
                _closedSet.Add(current);

                // d
                var neighbours = graph.Connections.Where(c => c.Roads.Intersect(current.Roads).Any()).ToList();
                foreach (Connection neighbour in neighbours)
                {
                    // i
                    if (_closedSet.Contains(neighbour))
                    {
                        continue;
                    }
                    
                    // ii
                    if (!_openSet.Contains(neighbour))
                    {
                        _openSet.Add(neighbour);
                    }

                    // iii & iv
                    double tempWeight = Weight(current, neighbour) + _gScore[current];
                    if (tempWeight >= _gScore[neighbour])
                    {
                        continue;
                    }

                    // v, vi & vii
                    _cameFrom[neighbour] = current;
                    _gScore[neighbour] = tempWeight;
                    _fScore[neighbour] = _gScore[neighbour]; // Add heuristics() when it's implemented.
                }
            }
            // 5
            Console.WriteLine("WARNING: Shortest path unavailable for car: " + inputVehicle);
        }

        /// <summary>
        /// Returns cost of travel from a to b.
        /// </summary>
        /// <param name="a">Connection from.</param>
        /// <param name="b">Connection to.</param>
        /// <returns>Cost of travel from a to b as value-type double.</returns>
        public static double Weight(Connection a, Connection b)
        {
            /*
             * 1. Find road connecting a and b.
             * 2. Return Length of road.
             */
            Road desiredRoad = a.Roads.Find(r => b.Roads.Contains(r));
            return desiredRoad.Length;
        }

        /// <summary>
        /// Returns heuristics from start to parsed connection. Actual heuristics has not been implementet yet, making the entire A* algorithm to effectively revert to Dijkstra.
        /// </summary>
        /// <param name="a">Connection for which to calculate Heuristics.</param>
        /// <returns>Returns heuristics-score as value-type double.</returns>
        public static double Heuristics(Connection a)
        {
            // TODO: make actual heuristics.
            return _gScore[a];
        }

        /// <summary>
        /// Path given to a Vehicle to follow, after AStar-pathfinding has found the optimal route.
        /// </summary>
        /// <param name="current">Input connection (last connection on optimal route).</param>
        /// <returns>Returns reference to Stack of connections.</returns>
        public static Stack<Connection> Reconstruct_path(Connection current)
        {
            Stack<Connection> totalPath = new Stack<Connection>();
            totalPath.Push(current);

            while (_cameFrom.ContainsKey(current))
            {
                current = _cameFrom[current];
                totalPath.Push(current);
            }
            return totalPath;
        }
    }
}