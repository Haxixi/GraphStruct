using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.Networking;

public class GraphAdjMatrix<T> : IGraph<T>
{
    private Node<T>[] nodes;
    private int[,] matrix;
    private int numEdges;
    private bool[] visited;

    public GraphAdjMatrix(int n)
    {
        nodes = new Node<T>[n];
        matrix = new int[n, n];
        visited = new bool[n];
    }

    public void DelEdge(Node<T> v1, Node<T> v2)
    {
        if (!IsNode(v1) || !IsNode(v2))
            return;

        if (matrix[GetIndex(v1), GetIndex(v2)] == 1)
        {

            matrix[GetIndex(v1), GetIndex(v2)] = 0;
            matrix[GetIndex(v2), GetIndex(v1)] = 0;

            --numEdges;
        }
    }

    public int GetEdge(int index1, int index2)
    {
        return matrix[index1, index2];
    }

    public int GetEdge(Node<T> v1, Node<T> v2)
    {
        if (!IsNode(v1) || !IsNode(v2))
            return 0;

        return matrix[GetIndex(v1), GetIndex(v2)];
    }

    public int GetIndex(Node<T> v)
    {

        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].Equals(v))
                return i;
        }

        return -1;
    }

    public Node<T> GetNode(int index)
    {
        return nodes[index];
    }

    public int GetNumOfEdge()
    {
        return numEdges;
    }

    public int GetNumOfVertex()
    {
        return nodes.Length;
    }

    public bool IsEdge(Node<T> v1, Node<T> v2)
    {
        if (!IsNode(v1) || !IsNode(v2))
            return false;

        if (matrix[GetIndex(v1), GetIndex(v2)] == 1)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public bool IsNode(Node<T> v)
    {
        foreach (var node in nodes)
        {
            if (v.Equals(node))
                return true;
        }

        return false;
    }

    public void SetEdge(Node<T> v1, Node<T> v2, int v)
    {
        if (!IsNode(v1) || !IsNode(v2))
            return;

        matrix[GetIndex(v1), GetIndex(v2)] = v;
        matrix[GetIndex(v2), GetIndex(v1)] = v;

        ++numEdges;

        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            for (int j = i + 1; j < GetNumOfVertex(); j++)
            {
                if (matrix[i, j] == 0)
                {
                    matrix[i, j] = int.MaxValue;
                    matrix[j, i] = int.MaxValue;
                }
            }
        }
    }

    public void SetEdge(Node<T> v1, Node<T> v2)
    {
        SetEdge(v1, v2, 1);
    }

    public void SetEdge(int index1, int index2)
    {
        matrix[index1, index2] = 1;
    }

    public void SetNode(int index, Node<T> v)
    {
        nodes[index] = v;
    }


    //Dijkstra最短路径算法
    public void Dijkstra(ref int[] distance, Node<T> n)
    {
        int v = 0;

        bool[] final = new bool[nodes.Length];

        for (int i = 0; i < nodes.Length; i++)
        {
            final[i] = false;
            distance[i] = matrix[GetIndex(n), i];
        }

        distance[GetIndex(n)] = 0;

        final[GetIndex(n)] = true;

        for (int i = 0; i < nodes.Length; i++)
        {
            int min = int.MaxValue;

            for (int j = 0; j < nodes.Length; j++)
            {
                if (!final[j])
                {
                    if (distance[j] < min)
                    {
                        v = j;
                        min = distance[j];
                    }
                }
            }

            final[v] = true;

            for (int w = 0; w < nodes.Length; w++)
            {
                if (final[w] == false)
                {
                    if (matrix[v, w] != int.MaxValue && min + matrix[v, w] < distance[w])
                    {
                        distance[w] = min + matrix[v, w];
                    }
                }
            }
        }
    }

    private void DFS(int i)
    {
        visited[i] = true;

        Debug.Log(nodes[i].Data);

        for (int j = 0; j < GetNumOfVertex(); j++)
        {
            if (matrix[i, j] != int.MaxValue && !visited[j])
                DFS(j);
        }
    }

    //邻接矩阵深度搜索
    public void DFSTraverse()
    {

        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            visited[i] = false;
        }

        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            if (!visited[i])
                DFS(i);
        }

    }

    //邻接矩阵广度搜索
    public void BFSTraverse()
    {

        Queue Q = new Queue();

        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            visited[i] = false;
        }

        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            if (!visited[i])
            {
                visited[i] = true;

                Debug.Log(nodes[i].Data);

                Q.Enqueue(i);

                while (Q.Count > 0)
                {
                    i = (int) Q.Dequeue();

                    for (int j = 0; j < GetNumOfVertex(); j++)
                    {
                        if (!visited[j] && matrix[i,j] != int.MaxValue)
                        {
                            visited[j] = true;

                            Debug.Log(nodes[j].Data);

                            Q.Enqueue(j);
                        }
                    }
                }
            }
        }
    }
}
