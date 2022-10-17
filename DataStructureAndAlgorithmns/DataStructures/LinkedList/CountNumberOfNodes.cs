using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.CountNumberOfNodes
{
    internal static class CountNumberOfNodes
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(1);
            list.Push(2);
            list.Push(3);
            list.Push(4);
            list.Push(3);
            list.Push(4);
            list.Push(3);
            list.Push(4);
            var tempHead = list.HeadNode;
            while(tempHead != null)
            {
                Console.WriteLine($"Value is :{tempHead.Data}");
                tempHead = tempHead.NextNode;
            }

            Console.WriteLine($"Count is :{list.CountNodes()}");

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
            if(HeadNode == null)
            {
                this.HeadNode = new Node(data);
                return;
            }
            var tempHead = HeadNode;
            while(tempHead.NextNode != null)
            {
                tempHead = tempHead.NextNode;
            }
            var node = new Node(data);
            tempHead.NextNode= node;

        }

        /// <summary>
        /// Auxilary TimeComplexity: O(1)
        /// </summary>
        /// <returns></returns>
        public int CountNodes()
        {
            if(HeadNode == null)
            return 0;

            var tempHead = HeadNode;
            int counter = 0;
            while(tempHead != null)
            {
                counter++;
                tempHead = tempHead.NextNode;
            }
            return counter;
        }

        /// <summary>
        /// Recursive Auxilary method : O(N)
        /// </summary>
        /// <returns></returns>
        public int CountRecursive()
        {
            if (HeadNode == null)
                return 0;

            return 1;
        }

    }
}
