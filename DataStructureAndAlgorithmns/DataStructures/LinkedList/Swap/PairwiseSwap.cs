using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

/**
 *https://leetcode.com/problems/swap-nodes-in-pairs/description/ 
 *Given a linked list, swap every two adjacent nodes and return its head. 
 *You must solve the problem without modifying the 
 *values in the list's nodes (i.e., only nodes themselves may be changed.)
 *Used 3 pointer solution
 ****/
namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Swap.PairWise
{
    internal static class PairwiseSwap
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            list.Push(40);
            list.Push(50);
            list.Push(60);

            var tHead = list.HeadNode;
            var result = list.PairWiseSwap(tHead);
            while (result != null)
            {
                Console.WriteLine($"Value is :{result.Data}");
                result = result.NextNode;

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
        public Node HeadNode { get; set; }

        public void Push(int data)
        {
            var node = new Node(data);
            if (this.HeadNode == null)
            {
                this.HeadNode = node;
                return;
            }
            var tempNode = this.HeadNode;

            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = node;

        }

        /// <summary>
        /// Comments added for best understanding and easy implementation.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node PairWiseSwap(Node head)
        {
            // 1-> 2-> 3-> 4-> 5
            // 2->1 ->4-> 3 ->5
            Node current = head;
            Node next = null;
            Node prev = null;

            while(current != null)
            {
                // break if it is last node
                if (current.NextNode == null)
                    break;

                next = current.NextNode;  // set next pointer to next node.
                // next = 2
               
                current.NextNode = next.NextNode;  // set current's next node to next' next node.
                // 1->3->4->5
                    //|
                   // 2
                  
                
                next.NextNode = current; // set next's next node as current // actual swapping happen  current became next node.
                // 2 -> 1 ->3 ->4 -> 5
                // next -> current

                if (prev == null)
                    head = next;
                else
                {
                    prev.NextNode = next;  // link previous node , executes only when non head nodes involved.
                }
                    prev = current; // set prev as current.
                
                current = current.NextNode;  // move the current to next node.
                // 2 ->  1  ->  3  ->  4  ->  5
                // next       current
              

            }

            return head ;
        }
    }
}
    
