using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Delete.DeleteDuplicatedNodesFromList
{
    internal static class DeleteDuplicatedNodesFromList
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(10);
            list.Push(20);
            list.Push(30);
            list.Push(40);

            var tHead = list.HeadNode;
            while(tHead != null)
            {
                Console.WriteLine($"Node-{tHead.Data}");
                tHead =tHead.NextNode;
            }

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
        public Node HeadNode { get; set; }

        public Node TailNode { get; set; }

        public void Push(int data)
        {
            var node = new Node(data);
            if (this.HeadNode == null)
            {
                this.HeadNode = node;
                this.TailNode = this.HeadNode;
                return;
            }
            var tempTailNode = this.TailNode; // temp refers tailnode
            this.TailNode = node; // tail refers new node.
            tempTailNode.NextNode = this.TailNode; // temp.next = tail
        }

    }

}
