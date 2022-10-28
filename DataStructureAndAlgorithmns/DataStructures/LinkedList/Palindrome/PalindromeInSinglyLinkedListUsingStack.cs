using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.PalindromeInSinglyLinkedList
{
    /// <summary>
    /// Check for Palindrome using Stack in Singly Linked List.
    /// </summary>    /// Steps: 
    /// 1. Popualate Linked list with nodes as usual
    /// 2. Create a empty stack.
    /// 3. Traverse list , for each iteration Push a node to Stack.
    /// 4. Trvaerse list again and for each iteration Pop a node from Stack.
    /// 5. Popped node and list node must be same.
    /// 6. If not then given linkedlist is not a palindrome.
    internal static class PalindromeInSinglyLinkedListUsingStack
    {
        public static void Run()
        {
            var linkedList = new LinkedList();
            var stack = new Stack();

            // populate list with nodes.
            linkedList.push(10);
            linkedList.push(20);
            linkedList.push(20);
            linkedList.push(10);
            //list : 10->20->30->40->NULL
            // stack 40->30->20->10-> null

            // traverse the list and push Node to stack.
            var tempHead = linkedList.HeadNode;

            while (tempHead != null)
            {
               stack.Push(tempHead.Data);
                tempHead = tempHead.NextNode;
            }

            var tHead = linkedList.HeadNode;
            var isPalindrome = true;
            while(tHead != null)
            {
                if(tHead.Data != stack.Pop().Data)
                {
                   isPalindrome = false;
                    break;
                }
                tHead = tHead.NextNode;
            }
            Console.WriteLine($"IsPalindrome :{isPalindrome}");
           
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

        public Node ShallowCopy()
        {
            return (Node)this.MemberwiseClone();
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

    internal class Stack
    {
        public Node HeadNode;
        public void Push(int data)
        {
            if(this.HeadNode == null)
            {
                // stack is empty.
                this.HeadNode = new Node(data);
                return;
            }
            var tempHead = this.HeadNode;
            var node = new Node(data);
            node.NextNode = tempHead;
            this.HeadNode = node;
        }

        /// <summary>
        /// returns head node.
        /// </summary>
        /// <returns></returns>
        public Node Pop()
        {
           var tempHead = this.HeadNode;
            this.HeadNode = tempHead.NextNode;
            return tempHead;

        }
    }


}
