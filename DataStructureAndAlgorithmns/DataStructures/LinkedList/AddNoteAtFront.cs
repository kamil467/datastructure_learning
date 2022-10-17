using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.AddNoteAtFront
{
    /// <summary>
    /// Singly Linked List - Add node at front.
    /// </summary>
    internal static class AddNoteAtFront
    {
        public static void Run()
        {
            var myList = new MyList();
            var node1 = new Node(10);
            var node2 = new Node(20);
            var node3 = new Node(30);
            var node4 = new Node(40);

            myList.Push(node1);
            myList.Push(node2);
            myList.Push(node3);
            myList.Push(node4);
            myList.Push(new Node(100));

            var head = myList.Head;
            while(head != null)
            {
                Console.WriteLine(head.Data);
                head = head.NextNode;
            }

            Console.ReadLine();
         

        }


        internal class Node
        {
            public int Data { get; set; }

            public Node NextNode { get; set; }

            public Node(int data)
            {
                this.Data = data;
                this.NextNode = null;
            }
        }

        internal class MyList
        {
            public Node Head { get; set; }

            /// <summary>
            /// move head node to next node.
            /// make next node to head node.
            /// </summary>
            /// <param name="node"></param>
            public void Push(Node node)
            {
                node.NextNode = Head; // move the head into next
                this.Head = node; // set current node as Head.
               
            }          
            }
        }






}
