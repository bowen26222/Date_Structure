using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace data_structure
{
    class Test
    {
        static void Main()
        {
            TestHeap();
        }
        static void TestHeap()
        {
            MyHeap<double> myHeap = new MyHeap<double>();
            for(int i = 10; i >= 1; i--)
            {
                myHeap.Insert((double)i*0.7);
            }
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(myHeap.Pop());
            }
        }
        static void TestHash()
        {
            MyHash<string, int> myHash = new MyHash<string, int>();
            myHash.Add("a", 1);
            myHash.Add("b", 3);
            myHash.Add("c", 5);
            myHash.Add("d", 7);
            myHash.Add("e", 9);
            myHash.Add("f", 11);
            myHash.Add("g", 13);
            myHash.Add("ABC", 15);
            myHash.Print();
            myHash.Remove("ABC");
            myHash.Remove("d");
            myHash.Add("ZBW", 666);
            myHash.Print();
        }
        static void TestArray()
        {
            MyArray<int> myArray = new MyArray<int>();
            int[] a = { 0, 1, 2, 3, 4 };
            myArray.Add(a);
            for(int i = 12; i <= 17; i++)
            {
                myArray.Add(i);
            }
            myArray.RemoveAt(1);
            myArray.Romove(13);
            myArray.Insert(3, 20);
            myArray.Print();
            myArray.Clear();
            myArray.Print();
            try
            {
                myArray.Print();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void TestStack()
        {
            MyStack<string> myStack = new MyStack<string>();
            for (int i = 1; i <= 6; i++)
            {

                string num = Console.ReadLine();
                myStack.Push(num);
            }
            int length = myStack.Length;
            for (int i = 1; i <= length; i++)
            {
                Console.WriteLine(myStack.Pop());
            }
            try
            {
                myStack.Peek();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                myStack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void TestQueue()
        {
            MyQueue<int> myQueue = new MyQueue<int>();
            for (int i = 1; i <= 10; i++)
            {
                myQueue.Push(System.Int32.Parse(Console.ReadLine()));
            }
            int length = myQueue.Length;
            for(int i = 1; i <= length; i++)
            {
                Console.WriteLine(myQueue.Pop());
            }
            try
            {
                myQueue.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void TestLinkedList()
        {
            MyLinkList<int> myLinkList = new MyLinkList<int>();
            for(int i = 1; i <= 10; i++)
            {
                myLinkList.Add(i);
            }
            myLinkList.Print();
            myLinkList.Delete(5);
            myLinkList.Insert(22, 3);
            myLinkList.Print();
            Console.WriteLine(myLinkList.Find(5));
        }
    }
}
