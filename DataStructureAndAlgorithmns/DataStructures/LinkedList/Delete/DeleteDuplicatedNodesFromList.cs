using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * /**
 * Write a function that takes a
 * list sorted in non-decreasing order and 
 * deletes any duplicate nodes from the list. 
 * The list should only be traversed once. 
For example if the linked list is 11->11->11->21->43->43->60 
then removeDuplicates() should convert the list to 11->21->43->60. 

 */
namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.Delete.DeleteDuplicatedNodesFromList
{
    internal static class DeleteDuplicatedNodesFromList
    {
        public static void Run()
        {
            var list = new LinkedList();
            list.Push(10);
            list.Push(10);
            list.Push(10);
            list.Push(10);
            list.Push(10);
            list.Push(10);
            list.Push(30);
            list.Push(30);
            list.Push(30);
            list.Push(30);
            list.Push(40);

            var node1 = new Node(10);
            var node2 = new Node(10);
            var node3 = new Node(10);
            var node4 = new Node(5);

            node1.NextNode = node2;
            node2.NextNode = node3;
            node3.NextNode = node4;


            list.RemoveDuplicatesFromUnSortedListUsingDictionary(node1);
            var tHead = list.HeadNode;  // tHedad and HeadNode both points to same address space.
            
           
            while(tHead != null)
            {
                Console.WriteLine($"Node-{tHead.Data}");
                tHead =tHead.NextNode;
            }
            // Now tHead points to null address, HeadNode still points to head address space. Power of references
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
            var tempHead = this.HeadNode;
            if(tempTailNode.Data <= data)
            {
                // new node is greater than tail node.
                this.TailNode = node; // tail refers new node.
                tempTailNode.NextNode = this.TailNode; // temp.next = tail
            }
            else if(tempHead.Data >= data)
            {
                // new node is less than head node.
                this.HeadNode = node;
                node.NextNode = tempHead;
                
            }
            else
            {
                // new node is between head and Tail
                var headNext = this.HeadNode.NextNode;
                Node prevNode = this.HeadNode.NextNode;
               while(headNext.NextNode != null)
                {
                    if (headNext.Data <= data)
                    {
                        prevNode = headNext; 
                        headNext = headNext.NextNode; // at this stage prev points to old node ,
                                                       // headNext points to next node.
                    }
                    else
                        break;

                }

                prevNode.NextNode = node;
                node.NextNode = headNext;

            }
            
        }
        
        public Node RemoveDuplicatesFromSortedList(Node head)
        {
            // currentNode, this.HeadNode and prevNode all point to same address space.
            var currentNode = head;
            Node prevNode = head;

            while (currentNode.NextNode != null)
            {
                // move current to next
                currentNode = currentNode.NextNode; // move the reference
                if (prevNode.Data == currentNode.Data)
                    prevNode.NextNode = currentNode.NextNode;  // I am updating address space of reference here that is why it is reflecting in this.headNode.
                else
                    prevNode = currentNode; // move the previous reference
            }

            return head;

        }

        // O(N^2) Brute Force apoproach. : Two loops
        public Node RemoveDuplicatesFromUnSortedListBruteForce(Node head)
        {
            var currentNode = head;

            while(currentNode != null) // do not check for next node , we need to run the loop for every node.
            {
                var nextNode = currentNode.NextNode;
                var prevNode = currentNode;
                
                while(nextNode != null)
                {
                    
                     if(nextNode.Data == currentNode.Data)
                      prevNode.NextNode = nextNode.NextNode;
                    else
                        prevNode = nextNode;
                      
                    
                    nextNode = nextNode.NextNode;

                }
                currentNode = currentNode.NextNode;
            }
            return head;
        }

        /// <summary>
        /// O(N) times using dictionary.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node RemoveDuplicatesFromUnSortedListUsingDictionary(Node head)
        {
            var current = head;

            var dictionary = new Dictionary<int, bool>();

            var previousNode = current;
            while(current != null)
            {
               
                if(!dictionary.ContainsKey(current.Data))
                {
                    dictionary.Add(current.Data, true);
                }
                else
                {
                    previousNode.NextNode = current.NextNode;
                    current = previousNode;
                }
                previousNode = current;
                current = current.NextNode;
            }
            return head;
        }

    }

}
