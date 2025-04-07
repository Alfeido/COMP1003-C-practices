using System;
using System.Collections.Generic;

class NetworkRouting
{
    static HashSet<string> downNodes = new HashSet<string> { "B", "D" }; // Change as needed

    static bool IsUp(string node)
    {
        return !downNodes.Contains(node);
    }

    public static List<string> FindShortestPath(Dictionary<string, List<string>> graph, string start, string end)
    {
        Queue<List<string>> queue = new Queue<List<string>>();
        HashSet<string> visited = new HashSet<string>();

        queue.Enqueue(new List<string> { start });

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            var current = path[path.Count - 1];

            if (!IsUp(current)) continue;
            if (current == end) return path;

            if (!visited.Contains(current))
            {
                visited.Add(current);

                if (graph.ContainsKey(current))
                {
                    foreach (var neighbor in graph[current])
                    {
                        if (!visited.Contains(neighbor) && IsUp(neighbor))
                        {
                            var newPath = new List<string>(path) { neighbor };
                            queue.Enqueue(newPath);
                        }
                    }
                }
            }
        }

        return null;
    }

    static void Main()
    {
        var graph = new Dictionary<string, List<string>> {
            { "A", new List<string> { "B", "C", "D" } },
            { "B", new List<string> { "E" } },
            { "C", new List<string> { "E", "F" } },
            { "D", new List<string> { "G" } },
            { "E", new List<string> { "F" } },
            { "F", new List<string> { "G" } }
        };

        string start = "A";
        string end = "G";

        var path = FindShortestPath(graph, start, end);

        if (path != null)
            Console.WriteLine("Shortest Path: " + string.Join(" -> ", path));
        else
            Console.WriteLine("No available path.");
    }
}
