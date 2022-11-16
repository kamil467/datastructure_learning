using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Swap
{
    internal static class SwapNodes
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(10);
            list.Push(15);
            list.Push(12);
            list.Push(13);
            list.Push(20);
            list.Push(14);
            //10 -> 15 -> 12 -> 13 -> 20 -> 14
            // 10 -> 15 -> 20-> 13 -> 12 -> 14

            var tHead = list.SwapNodes(10,20,list.HeadNode);

            while(tHead != null)
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

        public Node (int Data)
        {
            this.Data = Data;
            this.NextNode = null;
        }
        
    }

    internal class LinkedList
    {
        public Node HeadNode { get; set; }

        public void Push(int data)
        {
            var node = new Node(data);
            if(this.HeadNode == null)
            {
                this.HeadNode = node;
                return;
            }
            var tempNode = this.HeadNode;

            while(tempNode.NextNode != null)
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
        public Node SwapNodes(int pos1, int pos2, Node head)
        {
           // x and y may or may not be adjacent.
           //Either x or y may be a head node.
            //Either x or y may be the last node.
            //x and / or y may not be present in the linked list.
            var current = head;

            Node prev1 = null;
            Node prev2 = null;
            Node node1 = null;
            Node  node2 = null;
            Node prev = null;

            if (pos1 == pos2)
                return head;  // nothing to change

            #region Extract node1, node2, prev1, prev2
            while (current != null)
            {
                // search for X
                if(current.Data == pos1)
                {
                    prev1 = prev;
                  
                    node1 = current;
                }
                else if(current.Data == pos2)
                {
                    prev2 = prev;
                   
                    node2 = current;
                }
              

                prev = current;
                current = current.NextNode;
            }
            #endregion

            if (node1 != null && node2 != null)
            {
                #region X and Y are adjacent Nodes
                if (node1.NextNode.Data == node2.Data || node2.NextNode.Data == node1.Data)
                {
                    //adjacent node
                    
                    if (node1.NextNode.Data == node2.Data)
                    {
                        node1.NextNode = node2.NextNode;
                        if (prev1 != null)
                            prev1.NextNode = node2;

                        node2.NextNode = node1;
                    }

                    else if(node2.NextNode.Data == node1.Data)
                    {
                        node2.NextNode = node1.NextNode;
                        if (prev2 != null)
                            prev2.NextNode = node1;
                        node1.NextNode = node2;
                    }

                    return head;
                }
                #endregion

                //10 -> 15 -> 12 -> 13 -> 20 -> 14
                // prev1 = 15
                // prev2 = 13

                // time for swap.
                if (prev1 != null)
                    prev1.NextNode = node2;  // point previous node's next to node 2;
                else
                    head = node2;  // set node2 as head if prev1 is null. 


                if (prev2 != null)
                    prev2.NextNode = node1; // point prev2's next to node1.
                else
                    head = node1;  // set node1 as head if prev2 is null.

                var tempNext = node2.NextNode;
                node2.NextNode =  node1.NextNode;
                node1.NextNode = tempNext;

               

            }
                return head;

        }
    }
}
