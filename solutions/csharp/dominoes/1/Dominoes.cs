using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        List<int> xEdge = new List<int>();
        Dictionary<int, List<int>> xGraph = new Dictionary<int, List<int>>();
        if (!dominoes.Any()){
            return true;
        }
        foreach((int a, int b) in dominoes){
            if(!xGraph.ContainsKey(a)){
                xGraph[a] = new List<int>();
            }
            if(!xGraph.ContainsKey(b)){
                xGraph[b] = new List<int>();
            }
            xGraph[a].Add(b);
            xGraph[b].Add(a);
        }
        if(xGraph.Values.Any(xNeighbor => xNeighbor.Count %2 != 0)){
            return false;
        }
        int xStart = xGraph.Keys.First();
        HashSet<int> xVisited = new HashSet<int>();
        DFS(xStart, xGraph, xVisited);
        return xGraph.Keys.All(xEdge => xGraph[xEdge].Count == 0 || xVisited.Contains(xEdge));
    }
    private static void DFS(int vEdge,  Dictionary<int, List<int>> vGraph, HashSet<int> vVisited){
        if(!vVisited.Add(vEdge)){
            return;
        }
        foreach(int iNeighbor in vGraph[vEdge]){
            DFS(iNeighbor, vGraph, vVisited);
        }
    }
}
