using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace data_structure
{
    public class MyArray<T>
    {
        private T[] Elements { get; set; }
        public int Capacity { get; set; }
        public int Index { get; set; }
        public MyArray()
        {
            Capacity = 5;
            Elements = new T[Capacity];
        }
        public MyArray(T[] NewData)
        {
            Capacity = NewData.Length;
            Array.Copy(NewData, Elements, NewData.Length);
            IncreaseCapacity();
        }
        public void Add(T element)
        {
            if(Index == Capacity)
            {
                IncreaseCapacity();
            }
            Elements[Index++] = element;
        }
        public void Add(T[] elements)
        {
            while (Index + elements.Length >= Capacity)
            {
                IncreaseCapacity();
            }
            Array.Copy(elements, 0, Elements, Index, elements.Length);
            Index += elements.Length;
        }
        public void RemoveAt(int index)
        {
            if(index > Index)
            {
                throw new InvalidOperationException("index isn't valid");
            }
            Index--;
            if(index < Index)
            {
                Array.Copy(Elements, index + 1, Elements, index, Index - index);
            }
            Elements[Index] = default;
        }
        public void Insert(int index,T element)
        {
            if (index > Index)
            {
                throw new InvalidOperationException("index isn't valid");
            }
            if (Index == Capacity)
            {
                IncreaseCapacity();
            }
            Array.Copy(Elements, index , Elements, index + 1, Index - index);
            Elements[index] = element;
            Index++;
            if (Index == Capacity)
            {
                IncreaseCapacity();
            }
        }
        public T FindElement(int index)
        {
            if (index > Index)
            {
                throw new InvalidOperationException("index isn't valid");
            }
            return Elements[index];
        }
        public int FindIndex(int element)
        {
            return Array.IndexOf(Elements, element, 0, Index);
        }
        public bool Romove(T element)
        {
            int index = Array.IndexOf(Elements, element, 0, Index);
            if(index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;

        }
        public void Clear()
        {
            if (Index > 0)
            {
                Array.Clear(Elements, 0, Index);
                Index = 0;
            }

        }
        public void Print()
        {
            if (Index == 0)
            {
                throw new InvalidOperationException("Array is empty");
            }
            for(int i = 0; i < Index; i++)
            {
                Console.WriteLine(Elements[i]);
            }
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
