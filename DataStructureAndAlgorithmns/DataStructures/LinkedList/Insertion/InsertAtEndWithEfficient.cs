using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Insertion
{
    /// <summary>
    /// This suits when populating a fresh list with insertion at the end.
    /// </summary>
    internal static  class InsertAtEndWithEfficient
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            list.Push(40);
            list.Push(50);

            var tempHead = list.HeadNode;
            while(tempHead != null)
            {
                Console.WriteLine($"Node:{tempHead.Data}");
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
        public Node HeadNode { get; set; }
        public Node TailNode { get; set; }

        public void Push(int data)
        {
            var node = new Node(data);
            if(this.HeadNode == null)
            {
                this.HeadNode = node;
                this.TailNode = this.HeadNode;    
            }
            else
            {
                var tNode = this.TailNode;
               
                this.TailNode = node;
                tNode.NextNode = this.TailNode;
            }
            
        }


    }
}
