using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGraph<T>
{
    void SetNode(int index, Node<T> v);

    Node<T> GetNode(int index);

    void SetEdge(Node<T> v1, Node<T> v2, int v);

    void SetEdge(int index1, int index2);

    void SetEdge(Node<T> v1, Node<T> v2);

    void DelEdge(Node<T> v1, Node<T> v2);

    int GetEdge(int index1, int index2);

    int GetEdge(Node<T> v1, Node<T> v2);

    int GetNumOfVertex();

    int GetNumOfEdge();

    int GetIndex(Node<T> v);

    bool IsEdge(Node<T> v1, Node<T> v2);

    bool IsNode(Node<T> v);
}
