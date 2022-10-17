using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.DetectLengthOfLoop
{
    /// <summary>
    /// Problem Statement : Find the length of loop in linked list.
    /// Approach : We use FloyD 2 Pointer approach for detecting the loop.
    /// Instead of breaking at the common point , we initailize counter and break it when it comes at common point.
    /// Counter will represent length of loop.
    /// </summary>
    internal static class DetectLengthOfLoop
    {
        public static void Run()
        {
            var list = new LinkedList();

            var node1 = new Node(10, null);
            var node2 = new Node(20, node1);
            var node3 = new Node(30, node2);
            var node4 = new Node(40, node3);

            node1.NextNode = node4; // change this for switching between loop and no-loop.
            list.HeadNode = node1;
            // 4 -> 3 -> 2 -> 1 -> 4
         

            Console.WriteLine($"Length of Loop is :{list.FindLengthOfLoop()}");
          
        }

    }
    internal class Node
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        public Node(int data, Node nextNode)
        {
            this.Data = data;
            this.NextNode = nextNode;
        }
    }
    internal class LinkedList
    {
        public Node HeadNode;


        public void Push(Node node)
        {
            if (this.HeadNode == null)
            {
                this.HeadNode = node;
                return;
            }

            var tempHead = this.HeadNode;
            while (tempHead.NextNode != null)
            {
                tempHead = tempHead.NextNode;
            }
            tempHead.NextNode = node;
        }





        /// <summary>
        /// Two pointer approach.
        /// P1- Move by two.
        /// P2 - move by one.
        /// If both are meets then there is a cycle in the linked list.
        /// Fastest Approach.
        /// 1 -> 2->3->4->1  : Cycle length is 5.
        /// </summary>
        /// <returns></returns>
        public int FindLengthOfLoop()
        {
            var pointer_1 = this.HeadNode;
            var pointer_2 = this.HeadNode;
            var counter = 0;
            Node commonNode = null;
            while (pointer_1 != null)
            {
                pointer_1 = pointer_1.NextNode;
                if (pointer_1 != null)
                {
                    pointer_1 = pointer_1.NextNode;
                    pointer_2 = pointer_2.NextNode;

                    if (pointer_1 == pointer_2)  // do not use Equals
                    {
                        // counter = 1; uncomment if common node to be inlcuded twice.
                        commonNode = pointer_1;
                        break;
                        // cycle detected here.
                        // common point
                    }
                }
            }
            var cHead = commonNode;
            while(cHead != null)
            {
                counter++;
                cHead = cHead.NextNode;
                if(commonNode == cHead)
                {
                    break;
                }

            }
            


            return counter;
        }





    }
}
