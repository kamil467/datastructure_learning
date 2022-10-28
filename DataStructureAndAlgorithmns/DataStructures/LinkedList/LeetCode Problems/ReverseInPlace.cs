using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
/***
 * Given the head of a singly linked list
 * and two integers left and right where left <= right,
 * reverse the nodes of the list from position left to position right,
 * and return the reversed list.
 * Inputs:
 * HeadNode:Node ,
 * Left_node_position:int,
 * right_node_position
 * Output : Node
 * Sample : 1 => 2 =>3 => 4 => 5
 * Left: 2, right:4
 * Output: 1 => 4 => 3 => 2 => 5
 * Approach: 
 * Set a counter =0
 * Traverse a linked list and break the loop when  counter == left position.
 * Keep a track of previous node.
 * Calculate Stop position by right -left;
 * Take the nodes from left position and use 3 pointer approach to reverse it.
 * Perform reversing until you reach right position.
 * pointer current points to node which positioned after right.
 * Link current to revresed node.
 * set previous_node.next = reversed node.
 * check headnode of list- It should have updated nodes link.
 * 
 * */

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.LeetCode_Problems
{
    internal static  class ReverseInPlace
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

            var result =  list.Reverse(3, 4);
            while(result!= null)
            {
                Console.WriteLine($"Value is {result.Data}");
                result = result.NextNode;
            }


        }
    }

   internal class Node
    {
        public int Data { get; set; }

        public Node NextNode {  get; set; } 

        public Node(int data)
        {
            Data = data;
            NextNode = null;
        }
    }

    internal class LinkedList
    {
        public Node HeadNode { get; set; }
        public Node TailNode { get; set; }

        /// <summary>
        /// Push at the end.
        /// </summary>
        /// <param name="data">integer data value.</param>
        public void Push(int data)
        {
            var node = new Node(data);
            if (this.HeadNode == null)
            {
                this.HeadNode = node;
                this.TailNode = this.HeadNode;
                return;
            }

            var tNode = this.TailNode;
            this.TailNode = node;
            tNode.NextNode = this.TailNode;
               
        }

        /// <summary>
        /// Reverse list between given positions.
        /// </summary>
        /// <param name="left_pos"></param>
        /// <param name="right_pos"></param>
        /// <returns></returns>
        public Node Reverse(int left_pos, int right_pos)
        {
             // do not reverse if left and right position are same.
             // do not reverse if Head is null or list is empty.
            if(left_pos == right_pos || this.HeadNode == null)
            return this.HeadNode;

            var tempHead = this.HeadNode; // take ref of head.
            var counter = 1; // set the counter as 1 - we know head is not null;
            Node preNode = null; // to track previous node.
            while(tempHead.NextNode != null)
            {
                if (counter == left_pos) 
                {
                    var stopPosition = right_pos - left_pos; // calculate stop position.
                    var result = this.Reverse(tempHead, stopPosition); // Pass splitted list and position where it should stop reversing process.
                   
                    if (preNode != null)
                        preNode.NextNode = result; // link reversed part of linked list into previous node.
                                                   // here we are actually updating the node object itself.
                                                   // so any references which points to previousNode will see the changes. 
                    else
                        this.HeadNode = result;

                    break;
                }
                preNode = tempHead; // put the current node into prev before move the pointer to next.
                tempHead = tempHead.NextNode; // move pointer to next node.
                counter++; // increment counter - node visited.


                
            }
            return this.HeadNode;
        }

        public Node Reverse(Node node, int stopPosition)
        {
            var current = node; // current point to head of the given node.
            Node prev = null;
            Node next = null;
            var counter = 0;
            while(current != null)
            {
                if (counter > stopPosition)
                {
                    // prev.NextNode = current;
                    var tPrev = prev;
                    while(tPrev.NextNode != null)
                    {
                        tPrev = tPrev.NextNode;
                    }
                    tPrev.NextNode = current;

                    break;
                }
                    

                next = current.NextNode; 
                current.NextNode = prev;
                prev = current;
                current = next;
                counter++;

            }

            return prev;
        }

   
    }


}
