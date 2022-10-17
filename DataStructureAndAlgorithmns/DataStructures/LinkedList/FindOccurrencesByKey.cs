using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.FindOccurrencesByKey
{
    internal static  class FindOccurrencesByKey
    {
    
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            list.Push(40);
            list.Push(50);
            list.Push(20);
            list.Push(20);
            var tempHead = list.HeadNode;
            while(tempHead !=null)
            {
                Console.WriteLine($"Value is :{tempHead.Data}");
                tempHead = tempHead.NextNode;
            }

            Console.WriteLine($"Find Occurrence for number 20:{list.FindOccurrenceByKey(20)}");
            Console.WriteLine($"Recursion Find Occurrence for number 20:{list.RecursionVersion(list.HeadNode,20)}");
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
        public Node HeadNode;

        public int counter;  // defined as object level otherwise
                             // it will be overridden by recursion method if defined as local.

        public void Push(int data)
        {
            if(this.HeadNode == null)
            {
                this.HeadNode = new Node(data);
                return;
            }

            var tempHead = this.HeadNode;
            while(tempHead.NextNode != null)
            {
                tempHead = tempHead.NextNode;
            }
            tempHead.NextNode = new Node(data);
        }

        /// <summary>
        /// Without Recursion.
        /// Traverse with Counter.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int FindOccurrenceByKey(int key)
        {
            var counter = 0;
            var tempHead = this.HeadNode;
            while(tempHead != null)
            {
                if(tempHead.Data == key)
                {
                    counter++;
                }
                tempHead = tempHead.NextNode;
            }
            return counter;
        }

        public int RecursionVersion(Node head,int key)
        {
           

            var tempHead = head;

            //Breaking condition
            if (tempHead == null)
                return counter;
           
            // increment logic goes here
            if(tempHead.Data == key)
            {

                counter++;
            }

            // tail recursion approach
           return RecursionVersion(tempHead.NextNode,key);  // move head one up.

        }

    }

}
