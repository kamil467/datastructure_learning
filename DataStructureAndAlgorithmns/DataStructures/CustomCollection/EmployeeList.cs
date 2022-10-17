using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///Problem Statement : Custom Linked List which maintains sorted order based on Employee salary.
///
namespace DataStructureAndAlgorithmns.DataStructures.CustomCollection
{
    /// <summary>
    ///Node class 
    /// </summary>
    /// <typeparam name="T"></typeparam>
   
   internal class EmployeeLinkNode<T> where T: IComparable<T>
    {
        public T Employee { get; set; }
        public EmployeeLinkNode<T> NextNode { get; set; }

        public EmployeeLinkNode(T employee)
        {
            Employee = employee;
            this.NextNode = null;
        }
    }

    /// <summary>
    /// custom linkedlist implementation to hold Node objects in sorted order. 
    /// </summary>
    /// <typeparam name="T">It should support the IComparable interface</typeparam>
    internal class EmployeeLinkedList<T> where T: IComparable<T>
    {
       public EmployeeLinkNode<T> HeadNode;

        public void Add(T Item)
        {
            var newENode = new EmployeeLinkNode<T>(Item);
            // head is null
            // assign item to head
            // return
            if (this.HeadNode == null)
            {
                HeadNode = newENode;
                return;
            }
            // head is not null;
            var tempHead = this.HeadNode;

            // there is only one head node.
            // current head is greater than new node 
            // we can just set new node as head and new node's next as current head
            // return.
            if (tempHead.Employee.CompareTo(Item) > 0)
            {
                // current head is greater than new node.
                newENode.NextNode = tempHead;
                this.HeadNode = newENode; // deference the tempHead.
              //  return;
            }
            else
            {
                //if we have only one node.
                // then just set new node as next node
                // return.
                // below logic can be implemented outside of this condition as well.
                if (tempHead.NextNode == null)
                {
                    tempHead.NextNode = newENode;
                    return;
                }

                //Traverse the list until it finds a node which is greater than our input node. 
                // find the previous node.
                // set previousNode.next = new node;
                // set newNode.Next = Node(which is greater than our input node).
                var previousNode = tempHead;
                while (tempHead.Employee.CompareTo(newENode.Employee) <= 0)
                {
                    // current node is less than input node.

                    previousNode = tempHead;
                    
                    // move the head to next node.
                    tempHead = tempHead.NextNode;

                    if (tempHead is null)
                        break;
                }
               
                // at this point we know the pervious node and A node which is greater than our input node.
                
                // set A node as next node of input node.
                // set previous's
                newENode.NextNode = tempHead;
                previousNode.NextNode = newENode;
                
                }

            }
        }

    
    /// <summary>
    /// Employee class which implements IComparable interface.
    /// </summary>
    internal class Employee:IComparable<Employee>
    {
        public virtual int EmpID { get; set; }
        public virtual string Name { get; set; }

        public virtual double Salary { get; set; }

        public int CompareTo(Employee other)
        {
            var employee = other;
            if (this.Salary < employee.Salary)
                return -1;
            if (this.Salary == employee.Salary)
                return 0;
            if (this.Salary > employee.Salary)
                return 1;

            return 0;
        }
    }

    internal static class CustomLinkedList
    {
        public static void Run()
        {
            var employeeNodeList = new EmployeeLinkedList<Employee>();
            // Employees Object setup

            var e1 = new Employee
            {
                EmpID = 1,
                Name = "Kamil",
                Salary = 1000
            };

            var e2 = new Employee
            {
                EmpID = 2,
                Name = "Kamil-2",
                Salary = 2000
            };

            var e3 = new Employee
            {
                EmpID = 3,
                Name = "Kamil-3",
                Salary = 800
            };

            var e4 = new Employee
            {
                EmpID = 4,
                Name = "Kamil-4",
                Salary = 500
            };
            var e5 = new Employee
            {
                EmpID = 5,
                Name = "Kamil-5",
                Salary = 1300
            };
            var e6 = new Employee
            {
                EmpID = 6,
                Name = "Kamil-6",
                Salary = 25
            };

            var e7 = new Employee
            {
                EmpID = 7,
                Name = "Kamil-7",
                Salary = 750
            };

            var e8 = new Employee
            {
                EmpID = 8,
                Name = "Kamil-8",
                Salary = 7000
            };
            //populate the list
            employeeNodeList.Add(e1);
            employeeNodeList.Add(e2);
            employeeNodeList.Add(e3);
            employeeNodeList.Add(e4);
            employeeNodeList.Add(e5);
            employeeNodeList.Add(e6);
            employeeNodeList.Add(e7);
            employeeNodeList.Add(e8);
            // read from list

            var tempHead = employeeNodeList.HeadNode;
            while(tempHead!=null)
            {
                Console.WriteLine($"EmpID-{tempHead.Employee.EmpID}-Name-{tempHead.Employee.Name}-Salary-{tempHead.Employee.Salary}");
                tempHead = tempHead.NextNode;
            }
            Console.WriteLine();

        }
    }
}
