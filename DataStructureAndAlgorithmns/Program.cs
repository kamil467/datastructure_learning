using DataStructureAndAlgorithmns.DataStructures;
using DataStructureAndAlgorithmns.DataStructures.CustomCollection;
using DataStructureAndAlgorithmns.DataStructures.LinkedList;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.AddNoteAtFront;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.Basic;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.CountNumberOfNodes;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.DelefromMiddle;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.Delete.DeleteDuplicatedNodesFromList;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.DeleteANodeAtGivenPosition;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.DeletefromEnd;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.DetectLengthOfLoop;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.DetectLoop;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.FindElement;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.FindNthNode;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.FindNthNodeFromEnd;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.FindOccurrencesByKey;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.InserAfterGivenNode;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.Insertion;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.LeetCode_Problems;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.LeetCode_Problems.SwapNodes;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.Palindrome;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.PalindromeInSinglyLinkedList;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.PrintMiddleNode;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.SortedLinkedList;
using DataStructureAndAlgorithmns.DataStructures.LinkedList.Swap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SwapNodes = DataStructureAndAlgorithmns.DataStructures.LinkedList.LeetCode_Problems.SwapNodes.SwapNodes;

namespace DataStructureAndAlgorithmns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BasicLinkedList.Run(args);
            // InsertAfterGivenNode.Run();
            //AddNoteAtFront.Run();
            // DeleteFromBegining.Run();
            //DeleteFromEnd.Run();
            // DeleteFromMiddle.Run();

            // DeleteANodeAtGivenPosition.Run();
            //  CustomLinkedList.Run();
            //SortedLinkedList.Run();
            // CountNumberOfNodes.Run();
            //FindElement.Run();
            //FindNthNode.Run();
            // FindNthNodeFromEnd.Run();
            // PrintMiddleNode.Run();

            //FindOccurrencesByKey.Run();
            // DetectLoop.Run();
            // DetectLengthOfLoop.Run();
            //PalindromeInSinglyLinkedListUsingStack.Run();
            //UsingListReverse.Run();
            //InsertAtEndWithEfficient.Run();
            //ReverseInPlace.Run();
            //DeleteDuplicatedNodesFromList.Run();
            //  PassByReferenceAndValueUnderstanding.Run();
            //  Console.WriteLine("Pivot Index is :"+ PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 }));

            // SwapNodes.Run();

            SwapNodes.Run();
            Console.ReadLine();
        }

        public static int PivotIndex(int[] nums)
        {
            bool isPrefixLoaded = false;
            for (var i = 0; i < nums.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                if (i == 0)
                {
                    i++;
                    while (i < nums.Length)
                    {
                        rightSum = rightSum + nums[i];
                        i++;
                    }
                    if (rightSum == 0)
                        return 0;

                    // reset i;
                    i = 0;
                    continue;
                }
                if (i == nums.Length - 1)
                {
                    i = 0;
                    while (i < nums.Length - 2)
                    {
                        leftSum = leftSum + nums[i];
                        i++;
                    }
                    if (leftSum == 0)
                        return nums.Length - 1;

                    // reset i;
                    break;
                }

                // elements > 0 and nums.Length -2

                // get prefix Sum
                if(!isPrefixLoaded)
                {
                    var pSum = PrefixSum(nums);

                    // update element.
                    Array.Copy(pSum, nums, nums.Length);
                    isPrefixLoaded = true;
                }
           
                int prev = i - 1;
                int next = i + 1;
                int diff1 = nums[i] - nums[prev];
                int diff2 = nums[next] - nums[i];
                if (diff1 == diff2)
                    return i;


            }

            return -1;
        }

        public static int[] PrefixSum(int[] nums)
        {
            var prefixSumArray = new int[nums.Length];
            Array.Copy(nums, prefixSumArray, nums.Length);

            //Prefix Sum Array
            for (var i = 1; i < prefixSumArray.Length; i++)
            {
                int prev = i - 1;
                prefixSumArray[i] = prefixSumArray[i] + prefixSumArray[prev];
            }
            return prefixSumArray;
        }
    }

    

}
