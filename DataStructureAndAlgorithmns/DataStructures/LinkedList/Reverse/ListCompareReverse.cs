using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/** Compare Two List and check if List1 is reverse of List2.
 * **/
namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Reverse
{
    internal static  class ListCompareReverse
    {
        public static void Run()
        {
            var list1 = new LinkedList();
            list1.Push(10);
            list1.Push(20);
            list1.Push(300);
            list1.Push(40);
            list1.Push(50);

          
            var list2 = new LinkedList();
            list2.Push(50);
            list2.Push(40);
            list2.Push(30);
            list2.Push(20);
            list2.Push(10);

            CompareReversal(list1.HeadNode, list2.HeadNode);

        }

        public static Node CompareReversal(Node head1, Node head2)
        {
            // Reverse head1

            var current = head1;
            Node prev = null;
            Node next = null;
            while(current != null)
            {
                next = current.NextNode; // store next
                current.NextNode = prev; // point current.next = prev;
                prev = current;  // move prev to current.
                current = next; // move current to next node. 
            }

            head1 = prev;

            var secondCurrent = head2;
            bool isReversal = true;
            while(secondCurrent != null && head1 != null)
            {
                if(secondCurrent.Data != head1.Data)
                {
                    isReversal = false;
                    break;
                }
                secondCurrent = secondCurrent.NextNode;
                head1 = head1.NextNode;
            }
            Console.WriteLine($"List Compare Reversal :{isReversal}");
            return prev;

           


        }
    }

    internal class Node
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        public Node (int data)
        {
            this.Data = data;
            this.NextNode = null;
        }
    }

    internal class LinkedList
    {
        public Node HeadNode { get; set; }

        public void Push(int data)
        {
            var node = new Node(data);
            if(this.HeadNode == null)
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

    }
}
