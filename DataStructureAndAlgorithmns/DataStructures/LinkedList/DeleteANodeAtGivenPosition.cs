using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.DeleteANodeAtGivenPosition
{
    internal class DeleteANodeAtGivenPosition
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

            Console.WriteLine("Deletion at Position");
            list.PopByPosition(6);
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
        /// This method allow us to delete the node at given position
        /// /// </summary>
        /// <param name="position"></param>
        public void PopByPosition(int position)
        {
            //delete at Head.If position given as zero then delete the head.
            if (position == 0)
            {
                Head = Head.NextNode;
                Console.WriteLine("Node deleted at Head");
                return;
            }
            var tempHead = Head;
            var counter = 0;
            while(counter <= position)
            {
                var previousNode = tempHead;
                    counter++;
                    tempHead= tempHead.NextNode;
                if(counter == position)
                {
                    // this is where we have to delete the node.
                    // Find the previou node
                    // set pervious_node.next = node.next;
                    // set node.next = null

                    previousNode.NextNode = tempHead.NextNode;
                    tempHead.NextNode = null;

                }
            }
        }

       
    }
}
