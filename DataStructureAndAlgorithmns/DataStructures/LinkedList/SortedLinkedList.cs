using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.SortedLinkedList
{
    internal static class SortedLinkedList
    {
        public static void Run()
        {
            //defines nodes
            var node1 = new Node(1);
            var node2 = new Node(5);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(8);    
            var node6 = new Node(6);
            var node7 = new Node(10);
            var node8 = new Node(2);
            var node9 = new Node(9);
            var node10 = new Node(7);

            var list = new LinkedList();
            
            //populate the list
            list.Add(node1);
            list.Add(node2);
            list.Add(node3);
            list.Add(node4);
            list.Add(node5);
            list.Add(node6);
            list.Add(node7);
            list.Add(node8);
            list.Add(node9);
            list.Add(node10);


            // read from list
            var head = list.HeadNode;
            while(head != null)
            {
                Console.WriteLine($"Value:{head.Data}");
                head = head.NextNode;
            }

        }
    }
    internal class Node
    {
        /// <summary>
        /// Data value property
        /// </summary>
        public int Data { get; set; }

        /// <summary>
        /// Reference to next Node.
        /// </summary>
        public Node NextNode { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.NextNode = null;
        }
    }
   
    internal class LinkedList
    {
        public Node HeadNode;

        public void Add(Node node)
        {
            // set input node as HeadNode if NULL.
            if(this.HeadNode == null)
            {
                this.HeadNode = node;
                return;
            }

            // set input node as HeadNode if data of head node is greater than input node.
            if (this.HeadNode.Data > node.Data)
            {
                node.NextNode = this.HeadNode;
                this.HeadNode = node;

            }
            else
            {
                if(this.HeadNode.NextNode ==  null)
                {
                    this.HeadNode.NextNode = node;
                    return;
                }

                var previousNode = this.HeadNode;
                var tempNode = this.HeadNode;
                while ( tempNode !=null  && tempNode.Data < node.Data)
                {
                    // traverse the node;
                    previousNode = tempNode;
                    tempNode = tempNode.NextNode;
                    // if (tempNode is null)
                       // break;
                }
                node.NextNode = tempNode;
                previousNode.NextNode = node;
            }
        }
    }

}
