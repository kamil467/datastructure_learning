using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**Problem Statement:
 * You are given the head of a linked list, and an integer k.
Return the head of the linked list after swapping the values of the
kth node from the beginning 
and the kth node from the end (the list is 1-indexed).
Problem Link : https://leetcode.com/problems/swapping-nodes-in-a-linked-list/description/
Approach : We need Node1 , Node 2 and their previous nodes.
Node1 ,Previous1 - Look from start.
Node 2, Previous2 - should be from end.(traverse from start but break it when counter+k > list_length
Cases: Single Node- do nothing just return head, Two Nodes- swap head and tail nodes.
 * 
 * **/
namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.LeetCode_Problems.SwapNodes
{
    internal static class SwapNodes
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(7);
            list.Push(9);
            list.Push(10);
            //10 -> 15 -> 12 -> 13 -> 20 -> 14
            // 10 -> 15 -> 20-> 13 -> 12 -> 14

            var tHead = list.SwapNodes(3, list.HeadNode);

            while (tHead != null)
            {
                Console.WriteLine($"Node :{tHead.Data}");
                tHead = tHead.NextNode;
            }

        }

    }
    internal class Node
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        public Node(int Data)
        {
            this.Data = Data;
            this.NextNode = null;
        }

        public object ShallowCopy()
        {
            return (Node)this.MemberwiseClone(); 
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
        /// 
        /// </summary>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node SwapNodes(int k, Node head)
        {

            // Case 1: Single Node
            if (head.NextNode == null) return head;


            // x and y may or may not be adjacent.
            //Either x or y may be a head node.
            //Either x or y may be the last node.
            //x and / or y may not be present in the linked list.
            var current = head;
            Node prev1 = null;
            Node prev2 = null;
            Node node1 = null;
            Node node2 = null;
            Node prev = null;


            #region Extract node1, node2, prev1, prev2

            // Extract Node 1 and Previous 1
            var counter1 = 0;
            while (current != null)
            {
                counter1++;
                if (counter1 == k)
                {
                    prev1 = prev;
                    node1 = current;
                }
                prev = current;
                current = current.NextNode;
            }

            // Case 2: Two Nodes
            // Make swap head and tail nodes.
            if (counter1 == 2)
            {
                var cHead = head;
                var tail = head.NextNode;
                head.NextNode = null;
                head = tail;
                tail.NextNode = cHead;

                return head;
            }

            // Extract Node 2 and Previous 2
            var tHead = head;
            var tCounter = 0;
            prev = null;
            while(tHead != null)
            {
                tCounter++;

                if((tCounter+k) > counter1)
                {
                    prev2 = prev;
                    node2 = tHead;
                    break;
                }

                prev = tHead;
                tHead = tHead.NextNode;
            }



            #endregion


            // Swap Nodes
            if (node1 != null && node2 != null)
            {
              
                if (prev1 != null)
                    prev1.NextNode = node2;  // point previous node's next to node 2;
                else
                    head = node2;  // set node2 as head if prev1 is null. 


                if (prev2 != null)
                    prev2.NextNode = node1; // point prev2's next to node1.
                else
                    head = node1;  // set node1 as head if prev2 is null.

                var tempNext = node2.NextNode;
                node2.NextNode = node1.NextNode;
                node1.NextNode = tempNext;
            }
            return head;

        }
    }
}
