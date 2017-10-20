using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    private T data;

    public Node(T v)
    {
        data = v;
    }

    public T Data
    {
        get { return data; }
        set { data = value; }
    }
}

