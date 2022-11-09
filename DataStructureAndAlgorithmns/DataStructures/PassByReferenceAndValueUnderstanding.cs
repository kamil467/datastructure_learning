using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*A class instance is a reference type, not a value type. 
 * When a reference type is passed by value to a method, 
 * the method receives a copy of the reference to the class instance. 
 * That is, the called method receives a copy of the address of the instance,
 * and the calling method retains the original address of the instance. 
 * The class instance in the calling method has an address, 
 * the parameter in the called method has a copy of the address,
 * and both addresses refer to the same object.
 * Because the parameter contains only a copy of the address, 
 * the called method cannot change the address of the class instance in the calling method.
 * However, the called method can use the copy of the address to access the class members that 
 * both the original address and the copy of the address reference. 
 * If the called method changes a class member, the original class instance in the calling method also changes.
 * **/
namespace DataStructureAndAlgorithmns.DataStructures
{
    internal static class PassByReferenceAndValueUnderstanding
    {

        public static void Run()
        {
            A a = new A();
            a.Data = 10;
            Console.WriteLine($"Data Before Changes:{a.Data}");
            Changes(a);
            Console.WriteLine($"Data After Changes by Value:{a.Data}");
            ChangesBYRef(ref a);
            Console.WriteLine($"Data After Changes by Ref {a.Data}");

        }

        public static void Changes(A a1)
        {
            a1.Data = 20;
            a1 = null; // a still points to object.
        }

        public static void ChangesBYRef( ref A a2)
        {
            a2.Data = 30;
            a2 = null; // It makes a and a2 both null.
        }

    }

    internal class A
    {
        public int Data { get; set; }
    }
}
