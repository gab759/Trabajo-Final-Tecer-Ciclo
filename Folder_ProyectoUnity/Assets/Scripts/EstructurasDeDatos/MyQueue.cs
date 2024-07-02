using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyQueue<T>
{
    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
    private Node Head;
    private Node Tail;
    public int length = 0;

    public void Enqueue(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            length = 1;
        }
        else
        {
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
            length++;
        }
        Debug.Log("Enqueued: " + newNode.Value);
    }

    public T Dequeue()
    {
        if (Head == null)
        {
            Debug.LogError("Queue is empty");
            return default(T);
        }

        T value = Head.Value;
        Head = Head.Next;

        if (Head != null)
        {
            Head.Previous = null;
        }
        else
        {
            Tail = null;
        }

        length--;
        Debug.Log("Dequeued: " + value);
        return value;
    }

    public bool IsEmpty()
    {
        return length == 0;
    }
}