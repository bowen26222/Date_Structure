using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace data_structure
{
    public class MyStack<T>
    {
        private T[] Elements { get; set; }
        public int Index { get; set; } = -1;
        public int Capacity { get; set; }
        public MyStack()
        {
            Capacity = 5;
            Elements = new T[Capacity];
        }
        public MyStack(int capacity)
        {
            Capacity = capacity;
            Elements = new T[capacity];
        }
        
        public int Length
        {
            get { return Index + 1; }
        }
        public void Push(T element)
        {
            if(this.Length == Capacity)
            {
                IncreaseCapacity();
            }
            Index++;
            Elements[Index] = element;
        }
        public T Pop()
        {
            if (this.Length < 1)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T element = Elements[Index];
            Elements[Index] = default;
            Index--;
            return element;
        }
        public T Peek()
        {
            if (this.Length < 1)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return Elements[Index];
        }
        private void IncreaseCapacity()
        {
            Capacity++;
            Capacity *= 2;
            T[] newElements = new T[Capacity];
            Array.Copy(Elements, newElements, Elements.Length);
            Elements = newElements;

        }
    }
}
