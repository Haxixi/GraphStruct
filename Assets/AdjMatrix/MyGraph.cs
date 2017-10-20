using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGraph : MonoBehaviour
{

    private Node<string>[] nodes;

    private GraphAdjMatrix<string> graph;

    private int[] shortPath;

    void Start()
    {
        nodes = new Node<string>[5];

        graph = new GraphAdjMatrix<string>(5);

        shortPath = new int[5];

        nodes[0] = new Node<string>("a");
        graph.SetNode(0, nodes[0]);
        nodes[1] = new Node<string>("b");
        graph.SetNode(1, nodes[1]);
        nodes[2] = new Node<string>("c");
        graph.SetNode(2, nodes[2]);
        nodes[3] = new Node<string>("d");
        graph.SetNode(3, nodes[3]);
        nodes[4] = new Node<string>("e");
        graph.SetNode(4, nodes[4]);


        graph.SetEdge(graph.GetNode(0), graph.GetNode(1), 100);
        graph.SetEdge(graph.GetNode(0), graph.GetNode(3), 150);
        graph.SetEdge(graph.GetNode(0), graph.GetNode(4), 200);
        graph.SetEdge(graph.GetNode(1), graph.GetNode(2), 50);
        graph.SetEdge(graph.GetNode(2), graph.GetNode(3), 75);
        graph.SetEdge(graph.GetNode(3), graph.GetNode(4), 100);


        //for (int i = 0; i < graph.GetNumOfVertex(); i++)
        //{
        //    Debug.Log(graph.GetNode(i).Data);
        //}


        //for (int i = 0; i < graph.GetNumOfVertex(); i++)
        //{
        //    for (int j = 0; j < graph.GetNumOfVertex(); j++)
        //    {
        //        Debug.Log(graph.GetEdge(i, j));
        //    }
        //}


        //graph.Dijkstra(ref shortPath, nodes[0]);

        //for (int i = 0; i < shortPath.Length; i++)
        //{
        //    Debug.Log(shortPath[i]);
        //}

        //graph.DFSTraverse();

        //graph.BFSTraverse();

    }
}
