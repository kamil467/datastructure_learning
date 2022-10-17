using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.FindNthNode
{
    internal static class FindNthNode
    {
       
            public static void Run()
            {
                var list = new LinkedList();
                list.Push(10);
                list.Push(20);
                list.Push(30);

                var tempHead = list.HeadNode;
                while (tempHead != null)
                {
                    Console.WriteLine($"Value:{tempHead.Data}");

                    tempHead = tempHead.NextNode;
                }

                Console.WriteLine("Position to be found :4");

                var result = list.GetNodeByPosition(4) != null ? "Element Found" : "Not Found";
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
            while (tempNode.NextNode != null)
            {
                tempNode = tempNode.NextNode;
            }
            tempNode.NextNode = new Node(data);
        }
         
        public Node GetNodeByPosition(int position)
        {
            var pos_counter =1;
            var tempHead = HeadNode;
            while(tempHead != null)
            {    
                if(position == pos_counter)
                {
                    return tempHead;
                }
                tempHead = tempHead.NextNode;
                pos_counter++;
            }
            return null;
        }
    }

}
