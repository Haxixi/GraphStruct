using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GraphAdjList<T> : IGraph<T>
{
    private VexNode<T>[] adjList;

    private bool[] visited;

    public GraphAdjList(Node<T>[] nodes)
    {
        adjList = new VexNode<T>[nodes.Length];

        visited = new bool[nodes.Length];

        for (int i = 0; i < nodes.Length; i++)
        {
            adjList[i] = new VexNode<T>(nodes[i]);
        }
    }

    public void DelEdge(Node<T> v1, Node<T> v2)
    {
        if (!IsNode(v1) || !IsNode(v2))
        {
            return;
        }

        if (IsEdge(v1, v2))
        {
            adjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
            adjListNode<T> pre = null;
            while (p != null)
            {
                if (p.Adjvex != GetIndex(v2))
                {
                    pre = p;
                    p = p.NextAdj;
                }
            }

            pre.NextAdj = p.NextAdj;

            p = adjList[GetIndex(v2)].FirstAdj;

            pre = null;

            while (p != null)
            {
                if (p.Adjvex != GetIndex(v1))
                {
                    pre = p;
                    p = p.NextAdj;
                }
            }

            pre.NextAdj = p.NextAdj;
        }
    }

    public int GetEdge(int index1, int index2)
    {
        if (!IsNode(this.GetNode(index1)) || !IsNode(this.GetNode(index2)))
        {
            return 0;
        }

        adjListNode<T> p = adjList[index1].FirstAdj;
        while (p != null)
        {
            if (p.Adjvex == index2)
            {
                return p.Info;
            }

            p = p.NextAdj;
        }

        return 0;
    }

    public int GetEdge(Node<T> v1, Node<T> v2)
    {
        if (!IsNode(v1) || !IsNode(v2))
        {
            return 0;
        }

        adjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
        while (p != null)
        {
            if (p.Adjvex == GetIndex(v2))
            {
                return p.Info;
            }

            p = p.NextAdj;
        }

        return 0;
    }

    public int GetIndex(Node<T> v)
    {
        int j = -1;

        for (int i = 0; i < adjList.Length; i++)
        {
            if (adjList[i].Data.Data.Equals(v.Data))
            {
                return i;
            }
        }
        return j;
    }

    public Node<T> GetNode(int index)
    {
        return adjList[index].Data;
    }

    public int GetNumOfEdge()
    {
        int i = 0;

        foreach (var nd in adjList)
        {
            adjListNode<T> p = nd.FirstAdj;
            while (p != null)
            {
                i++;
                p = p.NextAdj;
            }
        }

        return i / 2;
    }

    public int GetNumOfVertex()
    {
        return adjList.Length;
    }

    public bool IsEdge(Node<T> v1, Node<T> v2)
    {
        if (!IsNode(v1) || !IsNode(v2))
        {
            return false;
        }

        adjListNode<T> p = adjList[GetIndex(v1)].FirstAdj;
        while (p != null)
        {
            if (p.Adjvex == GetIndex(v2))
            {
                return true;
            }

            p = p.NextAdj;
        }

        return false;
    }

    public bool IsNode(Node<T> v)
    {
        foreach (var nd in adjList)
        {
            if (v.Equals(nd.Data))
            {
                return true;
            }
        }

        return false;
    }

    public void SetEdge(Node<T> v1, Node<T> v2, int v)
    {
        if (!IsNode(v1) || !IsNode(v2) || IsEdge(v1, v2))
        {
            return;
        }

        if (v == 0)
        {
            return;
        }

        adjListNode<T> p = new adjListNode<T>(GetIndex(v2), v);

        if (adjList[GetIndex(v1)].FirstAdj == null)
        {
            adjList[GetIndex(v1)].FirstAdj = p;
        }

        else
        {
            p.NextAdj = adjList[GetIndex(v1)].FirstAdj;
            adjList[GetIndex(v1)].FirstAdj = p;
        }

        p = new adjListNode<T>(GetIndex(v1), v);

        if (adjList[GetIndex(v2)].FirstAdj == null)
        {
            adjList[GetIndex(v2)].FirstAdj = p;
        }

        else
        {
            p.NextAdj = adjList[GetIndex(v2)].FirstAdj;
            adjList[GetIndex(v2)].FirstAdj = p;
        }
    }

    public void SetEdge(int index1, int index2)
    {
        SetEdge(GetNode(index1), GetNode(index2), 1);
    }

    public void SetEdge(Node<T> v1, Node<T> v2)
    {
        SetEdge(v1, v2, 1);
    }

    public void SetNode(int index, Node<T> v)
    {
        adjList[index] = new VexNode<T>(v);
    }


    private void DFS(int i)
    {
        visited[i] = true;

        Debug.Log(adjList[i].Data.Data);

        adjListNode<T> p = adjList[i].FirstAdj;

        while (p != null)
        {
            if (visited[p.Adjvex] == false)
            {
                DFS(p.Adjvex);
            }

            p = p.NextAdj;
        }
    }

    //邻接表深度搜索
    public void DFSTravel()
    {
        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            if (!visited[i])
            {
                DFS(i);
            }
        }
    }

    //邻接表广度搜索
    public void BFSTravel()
    {
        int tmp;

        Queue q = new Queue();

        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            visited[i] = false;
        }

        for (int i = 0; i < GetNumOfVertex(); i++)
        {
            if (!visited[i])
            {
                visited[i] = true;

                Debug.Log(adjList[i].Data.Data);

                q.Enqueue(i);

                while (q.Count > 0)
                {
                    tmp = (int)q.Dequeue();

                    adjListNode<T> p = adjList[tmp].FirstAdj;

                    while (p != null)
                    {
                        if (!visited[p.Adjvex])
                        {
                            visited[p.Adjvex] = true;

                            Debug.Log(adjList[p.Adjvex].Data.Data);

                            q.Enqueue(p.Adjvex);
                        }

                        p = p.NextAdj;
                    }
                }
            }
        }
    }
}
