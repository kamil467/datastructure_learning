using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**Problem Summary:
 * Given a singly linked list, find the middle of the linked list. For example, 
 * if the given linked list is 1->2->3->4->5 then the output should be 3. 
If there are even nodes, 
then there would be two middle nodes, 
we need to print the second middle element. 
For example, if the given linked list is 1->2->3->4->5->6 then the output should be 4. 
 * 
 * **/
namespace DataStructureAndAlgorithmns.DataStructures.LinkedList.PrintMiddleNode
{
    internal static class PrintMiddleNode
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

            Console.WriteLine("Printing the linked list");

            var tempHead = list.HeadNode;
            while(tempHead != null)
            {
                Console.WriteLine($"Value :{tempHead.Data}");
                tempHead = tempHead.NextNode;
            }

            Console.WriteLine($"Print Middle:{list.PrintMiddle()}");
            Console.WriteLine("Two -Pointer Approach:");
            Console.WriteLine($"Print middle :{list.PrintMiddleFastApproach()}");

            Console.WriteLine($"SinglePointer With Counter:{list.PrintMiddleSinglePointerApproachWithCounter()}");
        }
    }
    internal class Node
    {
        public int Data { get; set; }

        public Node NextNode { get; set; }

        public Node(int data)
        {
            Data = data;
            NextNode = null; ;
        }
    }

    internal class LinkedList
    {
        public Node HeadNode;

        public void Push(int data)
        {
            if(this.HeadNode == null)
            {
                this.HeadNode = new Node(data);
                return;
            }

            var tempHead = HeadNode;

            while(tempHead.NextNode != null)
            {
                tempHead = tempHead.NextNode;
            }
            tempHead.NextNode = new Node(data);
        }

        //if list length is odd - print middle
        // if list length is even - print 2nd middle.
        //TimeComplexity is O(N)
        public int PrintMiddle()
        {
            // find length of the list.

            var tempHead = this.HeadNode;
            var counter = 0;
            while(tempHead!=null)
            {
                counter++;
                tempHead = tempHead.NextNode;
            }

            var positionOfMiddle = 0;
            // count is even or odd.
            // eg: assume count = 6;-> 6/2 = 3 -we need second middle.hence 3+1;

            // eg: assume count = 5 -> 5/2 = 2 -> middle would 3rd node so 2+1
            // both scenarios we need (counter/2)+1;
            positionOfMiddle = (counter/2)+1;
            

            tempHead = this.HeadNode;
            var recounter = 0;
            var valueofNode = 0;
            while(tempHead!=null)
            {
                recounter++;
                if(recounter == positionOfMiddle)
                {
                    valueofNode = tempHead.Data;
                    break;
                }
                tempHead = tempHead.NextNode;
            }


            return valueofNode;
        }

        /// <summary>
        /// Two-pointer approach.
        /// P1-Fast Pointer - move by two
        /// P2 - Slow pointer move by 1.
        /// </summary>
        /// <returns></returns>
        public int PrintMiddleFastApproach()
        {
            var fast_pointer = this.HeadNode;
            var slow_pointer = this.HeadNode;

            while (fast_pointer != null)
            {
                fast_pointer = fast_pointer.NextNode;
                if (fast_pointer != null)
                {
                    fast_pointer = fast_pointer.NextNode;

                    slow_pointer = slow_pointer.NextNode;
                }
                    
            }

            return slow_pointer.Data;
        }

        /// <summary>
        /// Faster than two-pointer
        /// </summary>
        /// <returns></returns>
        public int PrintMiddleSinglePointerApproachWithCounter()
        {
            var mid = this.HeadNode;
            var head =this.HeadNode;
            var counter = 0;

            while(head != null)
            {
              
                if (counter % 2 == 1)
                    mid = mid.NextNode;

                counter++;
                head = head.NextNode;
            }
            return mid.Data;
        }
    }

}
