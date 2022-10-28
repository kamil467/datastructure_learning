
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.InserAfterGivenNode
{
    internal static class InsertAfterGivenNode
    {
        public static void Run()
        {
            // construct linked list in the form 10 -> 20-> 30 -> 40
            var list = new LinkedList();
            var node1 = new Node(10);
            var node2 = new Node(20);
            var node3 = new Node(30);
            var node4 = new Node(40);

            list.Push(node1);
            list.Push(node2);
            list.Push(node3);
            list.Push(node4);

            var head = list.Head;

            while(head != null)
            {
                Console.WriteLine($"Node value is :{head.Data}");
                head = head.NextNode;
            }

            Console.WriteLine("Insert 15 after 10");
            list.Push(node1, new Node(15));
            var head1 = list.Head;
            while (head1 != null)
            {
                Console.WriteLine($"Node value is :{head1.Data}");
                head1 = head1.NextNode;
            }
            Console.ReadLine();

        }
    }


    internal class LinkedList
    {
        public Node Head { get; set; }

        public void Push(Node PreviousNode, Node node)
        {
            if (PreviousNode == null)
            {
                Console.WriteLine("Previous Node cannot be null");
                return;
            }

            node.NextNode = PreviousNode.NextNode; // set new node's next node to Previous node's next node
            PreviousNode.NextNode = node;  // set node as pervious node's next node.

        }

        public void Push(Node node)
        {
            if(this.Head == null)
            {
                this.Head = node;
                return;
            }
            var tempHead = Head;
            while(tempHead.NextNode != null)
            {
                tempHead = tempHead.NextNode;
            }
            tempHead.NextNode = node;
        }
    }

        internal class Node
        {
            public int Data { get; set; }

            public Node NextNode { get; set; }

           public Node(int data)
        {
            Data = data;
            this.NextNode = null;
        }
    }
    }

