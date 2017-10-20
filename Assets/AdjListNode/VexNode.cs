using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VexNode<T>
{

    private Node<T> data;
    private adjListNode<T> firstadj;

    public Node<T> Data
    {
        get { return data; }
        set { data = value; }
    }

    public adjListNode<T> FirstAdj
    {
        get { return firstadj; }
        set { firstadj = value; }
    }

    public VexNode(Node<T> nd)
    {
        data = nd;
        firstadj = null;
    }

    public VexNode(Node<T> nd, adjListNode<T> alNode)
    {
        data = nd;
        firstadj = alNode;
    }
}
