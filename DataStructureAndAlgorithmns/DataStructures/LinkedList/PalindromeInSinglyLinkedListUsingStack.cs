using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.PalindromeInSinglyLinkedList
{
    internal static class PalindromeInSinglyLinkedListUsingStack
    {
        public static void Run()
        {
            var linkedList = new LinkedList();
            linkedList.push(10);
            linkedList.push(20);
            linkedList.push(30);
            linkedList.push(40);

            var tempHead = linkedList.HeadNode;
            while(tempHead!=null)
            {
                Console.WriteLine($"Data is{tempHead.Data}");
                tempHead = tempHead.NextNode;
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
        public Node HeadNode;

        /// <summary>
        /// INSERT AT TAIL.
        /// </summary>
        public void push(int data)
        {
            if (this.HeadNode == null)
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

    }


}
