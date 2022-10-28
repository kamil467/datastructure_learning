using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Basic
{
    /// <summary>
    /// Understand how to create and traverse in Basic Linked List - Singly Linked list
    /// </summary>
    internal static class BasicLinkedList
    {
       public static void Run(string[] args)
        {
            // populate the linked list 
            // we need to two classes 
            // 1. Node - to represent single Node block
            // 2. LinkedList - to hold all the nodes.
            // list constructed as node1 -> node2 -> node3-> node4
            var list = new KamnilLinkedList();
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);

            //list.head = node1;
            //list.head.NextNode = node2;
            //list.head.NextNode.NextNode = node3;
            //list.head.NextNode.NextNode.NextNode = node4;
            list.Push(node1);
            list.Push(node2);
            list.Push(node3);
            list.Push(node4);

            // print th elements in the linked list.
            var tempHead = list.head; // get the head node.
            while (tempHead != null)
            {
                Console.WriteLine($"Node value is :{tempHead.Data}");
                // move the node to next node.
                tempHead = tempHead.NextNode;
            }
            Console.ReadLine();


        }
    }

    /// <summary>
    /// Create Node data Structure
    /// </summary>
    internal class Node:ICloneable
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.NextNode = null;  // set next node to NULL when initialized.
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    /// <summary>
    /// represent LinkedList data structure
    /// </summary>
     class KamnilLinkedList
    {
        public Node head { get; set; }


        public void Push(Node node)
        
        {
            if (head == null)
            {
                this.head = node;
            }
            else
            {
                // identify last node in the list.
                // set last_node.next = new node;
                // var tempHead = (Node)head.Clone(); // memberwise clone
                var tempHead = head;// both are pointing to same memory location in heap
                while (tempHead.NextNode != null)
                {

                    tempHead= tempHead.NextNode;
                    // loop will exit when last node found.
                }
                tempHead.NextNode = node;  // set next node to new node.
                // set the current head from outside.
            }
         
        }

    }
}
