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
    public class MyQueue<T>
    {
        private T[] Elements { get; set; }
        public int Back { get; set; } = -1;
        public int Front { get; set; } = 0;
        public int Capacity { get; set; }
        public MyQueue()
        {
            Capacity = 5;
            Elements = new T[Capacity];
        }
        public MyQueue(int capacity)
        {
            Capacity = capacity;
            Elements = new T[capacity];
        }
        public int Length
        {
            get { return Back + 1; }
        }
        public void Push(T element)
        {
            if (this.Length == Capacity)
            {
                IncreaseCapacity();
            }
            Back++;
            Elements[Back] = element;
        }
        public T Pop()
        {
            if (Front > Back)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T element = Elements[Front];
            Elements[Front] = default;
            Front++;
            return element;
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
