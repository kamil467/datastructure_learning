using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.DelefromMiddle
{
    internal class DeleteFromMiddle
    {
        public static void Run()
        {
            // construct linked list in the form 10 -> 20-> 30 -> 40
            var list = new LinkedList();
            var node1 = new Node(10);
            var node2 = new Node(20);
            var node3 = new Node(30);
            var node4 = new Node(40);

            var node5 = new Node(50);
            var node6 = new Node(60);
            var node7 = new Node(70);


            list.Push(node1);
            list.Push(node2);
            list.Push(node3);
            list.Push(node4);
            list.Push(node5);
            list.Push(node6);
            list.Push(node7);



            var head = list.Head;

            while (head != null)
            {
                Console.WriteLine($"Node value is :{head.Data}");
                head = head.NextNode;
            }

            Console.WriteLine("Deletion Start");
            // list.Pop(node4, node5);
            list.PopByKey(80);
            var head1 = list.Head;

            while (head1 != null)
            {
                Console.WriteLine($"Node value is :{head1.Data}");
                head1 = head1.NextNode;
            }

        }
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
    internal class LinkedList
    {
        public Node Head { get; set; }

        /// <summary>
        /// Add element at last
        /// </summary>
        /// <param name="node"></param>
        public void Push(Node node)
        {
            if (this.Head == null)
            {
                this.Head = node;
                return;
            }
            var tempHead = Head;
            while (tempHead.NextNode != null)
            {
                tempHead = tempHead.NextNode;
            }
            tempHead.NextNode = node;
        }
       
        /// <summary>
        /// It requires pervious nod and node.
        /// </summary>
        /// <param name="previousNode"></param>
        /// <param name="toBeDeleted"></param>
        public void Pop(Node previousNode, Node toBeDeleted)
        {
            if (this.Head == null)
            {
                Console.WriteLine("list is empty");
                return;
            }
               
            if (previousNode == null || toBeDeleted == null)
                return;
            previousNode.NextNode = toBeDeleted.NextNode;
            toBeDeleted.NextNode = null;
        }

        /// <summary>
        /// This is most optimal method , we just need to pass the data(key) to delete the node.
        /// This will delete the fist occurence of node.
        /// </summary>
        /// <param name="key"></param>
        public void PopByKey(int key)
        {
            if(Head.Data==key)
            {
                // delete if head contains the key.

                Head = Head.NextNode;  // set head to next node. GC will clear the unreferenced Head object.
                return;
            }
            var tempHead = Head;
            while(tempHead.NextNode != null)
            {
                var previousNode = tempHead;  // hold previousNode
                tempHead = tempHead.NextNode;
                if(tempHead.Data == key)
                {
                    // we identify the node to be deleted.
                    // 2 step process
                    // a) Find previous node and set previous_node.next = deletedNode
                      // b) deletedNode 
                    previousNode.NextNode = tempHead.NextNode; 
                    tempHead.NextNode = null;
                    // we got the node where key is present.
                }
            }
        }
    }
}
