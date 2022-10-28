using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Palindrome
{
    /// <summary>
    /// Palindrome -Without Using Stack.
    /// Find the middle of list.
    /// Odd - middle will be only one.
    /// Even - take second middle node.
    /// Reverse the second half.
    /// Compare first and Second half - they should be identical.
    /// Finding middle - Please follow 3 pointer approach.
    /// current, previous, next
    /// </summary>
    internal static  class UsingListReverse
    {
        public static void Run()
        {
            var list = new LinkedList();
           list.Push(10);
            list.Push(20);
            list.Push(20);
            list.Push(20);
            list.Push(10);

            var tHead = list.HeadNode;

            //while(tHead != null)
            //{
            //    Console.WriteLine(tHead.Data);
            //    tHead = tHead.NextNode;
            //}
            var secondList = list.GetMiddle();

            var reversedList = list.ReverseList(secondList);

            Console.WriteLine("Reverse List");
            var IsPalindrome = true;
            while(reversedList != null)
            {
                if(reversedList.Data != tHead.Data)
                {
                    Console.WriteLine($"Not A Palindrome");
                    IsPalindrome = false;
                    break;
                }
               
                reversedList = reversedList.NextNode;
                tHead = tHead.NextNode;
            }
            Console.WriteLine($"Result : {IsPalindrome}");
           

        }
    }

    internal class Node
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        public Node(int data)
        {
            Data = data;
            NextNode = null ;
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

        public Node GetMiddle()
        {
            var p1 = this.HeadNode;
            var p2 = this.HeadNode;
           
            while(p1 != null)
            {
                p1 = p1.NextNode;

                if (p1 != null)
                {
                    p1 = p1.NextNode;

                    p2 = p2.NextNode;
                }
                    
            }

            return p2;
        }

        public Node ReverseList(Node headNode)
        {
            var current = headNode;
            Node prev = null;
            Node next = null;
            while(current != null)
            
            {
                next = current.NextNode;  // take the next node of current node.
                current.NextNode = prev;  // this is where actually revresing happens. set prev as current next (null at begining).
                prev = current;  // set current as previous node.
                current = next; // set next as current node.
            }
            headNode = prev;
             

          

            return headNode;
        }

    }

}
