using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***Summary
 * 1) Find the length of the linked list
2) Travel from front 
3) for each node visited check below condition.
current_node_position+Nth Position > length of list   --> 
if it is true then current_node is the Nth Node from end.
 * 
 * 
 * ***/

/** Fast Approach
/// Two Pointer Approach.
/// Nth Node position from the start will be ( list_length - position + 1)
/// Eg: Length = 10 , Nth Node = 3 then the node will be (10-3+1) = 8;
/// Using the same approach we are traversing from start , this will avoid one loop iteration for finding the length.
/// P1 - Initially it will be pointed at Nth Position from start.
/// P2 - Points to head node.
/// every iteration moves P1 and P2 by one position.
/// When P1 reaches the end then P2 will point to Nth node from end.
**/ 
namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.FindNthNodeFromEnd
{
    internal static class FindNthNodeFromEnd
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(23);
            list.Push(89);
            list.Push(50);
            list.Push(30);
            list.Push(71);

            

            var tempHead = list.HeadNode;
            while (tempHead != null)
            {
                Console.WriteLine($"Value:{tempHead.Data}");

                tempHead = tempHead.NextNode;
            }

            Console.WriteLine("Position to be found from End :5");

           // var result = list.GetNodeByPositionFromEnd(3) != null ? "Element Found" : "Not Found";

            // Console.WriteLine($"Element is {list.GetNodeByPositionFromEnd(3).Data}");
         //   Console.WriteLine(result);

            Console.WriteLine("Tow Pointer Approach");

            Console.WriteLine($"Element is:{list.GetNodeByPositionFromStart(5).Data}");

            Console.WriteLine($"GFG Solution:{list.getNthFromLast(list.HeadNode,5)}");
        }
    }


    internal class Node
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        public Node(int data)
        {
            Data = data;
            NextNode = null;
        }
    }

    internal class LinkedList
    {
        public Node HeadNode;

        public void Push(int data)
        {
            if (this.HeadNode == null)
            {
                this.HeadNode = new Node(data);
                return;
            }

            var tempNode = HeadNode;
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = new Node(data);
        }

        public Node GetNodeByPositionFromEnd(int position)
        {
            var pos_counter = 0;
            var tempHead = HeadNode;
            while (tempHead != null)
            {
                pos_counter++;
                tempHead = tempHead.NextNode;
                
            }
            // got the length of the linked list.

            tempHead = HeadNode;
            var new_counter = 0;

            if (pos_counter < position)
                return null;
            while(tempHead != null)
            {
                new_counter++;

                if ((new_counter +position) > pos_counter)
                {
                    return tempHead;
                }
                
                tempHead = tempHead.NextNode;
            }

            return null;
        }

        /// <summary>
        /// Two Pointer Approach.
        /// Nth Node position from the start will be ( list_length - position + 1)
        /// Eg: Length = 10 , Nth Node = 3 then the node will be (10-3+1) = 8;
        /// Using the same approach we are traversing from start , this will avoid one loop iteration for finding the length.
        /// P1 - Initially it will be pointed at Nth Position from start.
        /// P2 - Points to head node.
        /// every iteration moves P1 and P2 by one position.
        /// When P1 reaches the end then P2 will point to Nth node from end.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Node GetNodeByPositionFromStart(int position)
        {
            var pointer_1 = this.HeadNode;
            var pointer_2 = this.HeadNode;

            var positionCounter = 0;
            while(pointer_1 != null)
            {
                positionCounter++;
                pointer_1 = pointer_1.NextNode;
                if(positionCounter > position)
                {
                    pointer_2 = pointer_2.NextNode;
                }
            }
            return pointer_2;
        }

        public int getNthFromLast(Node head, int k)
        {
            var pointer_1 = head;
            var pointer_2 = head;

            var positionCounter = 0;
            var pValue = 0;

            while (pointer_1 != null)
            {
                positionCounter++;
                pointer_1 = pointer_1.NextNode;
                if (positionCounter > k)
                {
                    pointer_2 = pointer_2.NextNode;
                    pValue = pointer_2.Data;
                }
            }
            return pValue;
        }
    }
}
