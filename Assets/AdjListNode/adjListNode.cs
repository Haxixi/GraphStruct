using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjListNode<T>
{

    private int adjvex;
    private int info;
    private adjListNode<T> nextadj;

    public int Adjvex
    {
        get { return adjvex; }
        set { adjvex = value; }
    }

    public int Info
    {
        get { return info; }
        set { info = value; }
    }

    public adjListNode<T> NextAdj
    {
        get { return nextadj; }
        set { nextadj = value; }
    }

    public adjListNode(int adjvex)
    {
        this.adjvex = adjvex;
        nextadj = null;
    }

    public adjListNode(int adjvex, int info)
    {
        this.adjvex = adjvex;
        this.info = info;
        nextadj = null;
    }
}
