using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Insertion.MoveLastToFront
{
    internal class MoveLastToFront
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
            list.Push(70);
            list.Push(80);
            list.Push(90);
            list.Push(100);


            var result = list.MoveLastNodeToFront(list.HeadNode);

            while(result != null)
            {
                Console.WriteLine($"Value is:{result.Data}");
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

        /// <summary>
        /// Push - Insert node at last.
        /// </summary>
        /// <param name="data"></param>
        public void Push(int data)
        {
            var node = new Node(data);
            if (this.HeadNode == null)
            {
                this.HeadNode = node;
                return;
            }

            var tempHead = this.HeadNode;
            while(tempHead.NextNode != null)
            {
                tempHead = tempHead.NextNode;
            }
            tempHead.NextNode = node;
        }

        public Node MoveLastNodeToFront(Node head)
        {
            Node lastNode = null;
            var current = head;
            Node prev = null;
            while(current.NextNode != null)
            {
                prev = current;
                current = current.NextNode;
            }

           // set last previous as last node.
            prev.NextNode = null; 

            // get last node.
            lastNode = current;

            //set last node as head
            lastNode.NextNode = head;


            return lastNode;
        }
    }
}
