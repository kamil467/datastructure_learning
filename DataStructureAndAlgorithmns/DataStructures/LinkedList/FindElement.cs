using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.FindElement
{
    internal static class FindElement
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(10);
            list.Push(20);
            list.Push(30);

            var tempHead = list.HeadNode;
            while(tempHead != null)
            {
                Console.WriteLine($"Value:{tempHead.Data}");
             
                tempHead = tempHead.NextNode;
            }

            Console.WriteLine("Data to be found :30");

            var result = list.GetNode(30) != null ? "Element Found" :"Not Found";
           Console.WriteLine(result);
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
            while(tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = new Node(data);
        }

        public Node GetNode(int data)
        {
            var tempNode = HeadNode;
            while(tempNode != null)
            {
                if (tempNode.Data == data)
                {
                    return tempNode;
                }
                tempNode = tempNode.NextNode;
            }

            return null;
        }
    }
}
