using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
/*Singly Linked List can contain self loop
 * We need to detect if any such loops exists.
 * 
 * **/

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.DetectLoop
{
    /// <summary>
    /// Linked
    /// </summary>
    internal static class DetectLoop
    {
        public static void Run()
        {
            var list = new LinkedList();

            var node1 = new Node(10,null);
            var node2 = new Node(20,node1);
            var node3 = new Node(30, node2);
            var node4 = new Node(40, node3);

            node1.NextNode = node4; // change this for switching between loop and no-loop.

           // 4 -> 3 -> 2 -> 1 -> 4
           list.HeadNode = node1;
             
        
            var tempHead = list.HeadNode;
            //while (tempHead != null)
            //{
            //    //Console.WriteLine($"Value is :{tempHead.Data}");
            //    tempHead = tempHead.NextNode;
            //}

            Console.WriteLine($"Loop Detected :{list.IsLoopDetected()}");

            Console.WriteLine($"Loop Detected without dictionary:{list.IsLoopDetectedWithoutDictionary()}");
            Console.WriteLine($"Loop Detected With FLoy'D Algorithm:{list.IsLoopDetectedFloydCycleAlgorithm()}");
        }
    }
    internal class Node
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        /// <summary>
        /// Get or Set Flag. represent Object visited or not.
        /// </summary>
        public bool Flag { get; set; }
        public Node(int data,Node nextNode)
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
        /// Dictionary Collection Approach.
        /// We utized Key field to store Node object itself.
        /// Value is not utilized.
        /// </summary>
        /// <returns></returns>
        public bool IsLoopDetected()
        {
            var dictionary = new Dictionary<Node,int>();
            var tempHead = this.HeadNode;
            while(tempHead != null)
            {
                var isExists = dictionary.TryGetValue(tempHead, out int key);

                if (isExists)
                    return true;

                dictionary.Add(tempHead, tempHead.Data);
                tempHead = tempHead.NextNode;
             
            }
            return false;

        }

        /// <summary>
        /// We can detect loop without using dictionary.
        /// For that we need to change the structure of Linked List.
        /// Add a Flag in Node class.
        /// Update the flag for each object that has been visited.
        /// Check flag if it is already visited or not.If yes then loop is exists in the linked list.
        /// </summary>
        /// <returns></returns>
        public bool IsLoopDetectedWithoutDictionary()
        {
            var tempHead = this.HeadNode;
            while( tempHead != null)
            {
                if(tempHead.Flag == true)
                {
                    // loop is detected.
                    return true;

                }

                tempHead.Flag = true;  // visited
                tempHead = tempHead.NextNode; // move node
            }
            return false;

        }

        /// <summary>
        /// Two pointer approach.
        /// P1- Move by two.
        /// P2 - move by one.
        /// If both are meets then there is a cycle in the linked list.
        /// Fastest Approach
        /// </summary>
        /// <returns></returns>
        public bool IsLoopDetectedFloydCycleAlgorithm()
        {
            var pointer_1 = this.HeadNode;
            var pointer_2 = this.HeadNode;
           
            while(pointer_1 != null)
            {
                pointer_1 = pointer_1.NextNode;
                if(pointer_1 != null)
                {
                    pointer_1 = pointer_1.NextNode;
                    pointer_2 = pointer_2.NextNode;

                    if (pointer_1 == pointer_2)  // do not use Equals
                        return true; // cycle is present

                }
            }

            return false;
        }





    }
}
