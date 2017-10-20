using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyList : MonoBehaviour
{
    private Node<string>[] nodes;

    private GraphAdjList<string> graph = null;

    void Start()
    {
        nodes = new Node<string>[8];

        graph = new GraphAdjList<string>(nodes);

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
        nodes[5] = new Node<string>("f");
        graph.SetNode(5, nodes[5]);
        nodes[6] = new Node<string>("g");
        graph.SetNode(6, nodes[6]);
        nodes[7] = new Node<string>("h");
        graph.SetNode(7, nodes[7]);


        graph.SetEdge(graph.GetNode(0), graph.GetNode(1), 100);
        graph.SetEdge(graph.GetNode(0), graph.GetNode(2), 150);
        graph.SetEdge(graph.GetNode(1), graph.GetNode(3), 200);
        graph.SetEdge(graph.GetNode(1), graph.GetNode(4), 50);
        graph.SetEdge(graph.GetNode(3), graph.GetNode(7), 75);
        graph.SetEdge(graph.GetNode(4), graph.GetNode(7), 300);
        graph.SetEdge(graph.GetNode(2), graph.GetNode(5), 300);
        graph.SetEdge(graph.GetNode(2), graph.GetNode(6), 300);
        graph.SetEdge(graph.GetNode(5), graph.GetNode(6), 300);


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


        //graph.BFSTravel();

        //graph.DFSTravel();
    }
}
