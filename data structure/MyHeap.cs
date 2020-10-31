using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace data_structure
{
    public class MyHeap<T>
    {
        public T[] Elements { get; set; }
        public int Count { get; set; } = 0;
        public int Capacity { get; set; }
        public MyHeap(int capacity = 100)
        {
            Capacity = capacity;
            Elements = new T[Capacity];
        }
        private int Father(int index)
        {
            return (index - 1) / 2;
        }
        private int LeftSon(int index)
        {
            return 2 * index + 1;
        }

        private int RightSon(int index)
        {
            return 2 * index + 2;
        }
        public void Insert(T value)
        {
            if(Count == Capacity)
            {
                IncreaseCapacity();
            }
            int index = Count;
            Elements[Count++] = value;
            while (index != 0)
            {
                int fa = Father(index);
                if (Convert.ToDouble(value) > Convert.ToDouble(Elements[fa]))
                {
                    Swap(ref Elements[fa], ref Elements[index]);
                }
                else
                {
                    break;
                }
                index = fa;
            }
        }
        public T Pop()
        {
            if(Count == 0)
            {
                return default;
            }
            T peek = Elements[0];
            Elements[0] = Elements[Count];
            int index = 0;
            while (2 * index < Count)
            {
                int LS = LeftSon(index);
                int RS = RightSon(index);
                if (RS >= Count || Convert.ToDouble(Elements[LS]) > Convert.ToDouble(Elements[RS])) 
                {
                    if (Convert.ToDouble(Elements[index]) < Convert.ToDouble(Elements[LS]))
                    {
                        Swap(ref Elements[index], ref Elements[LS]);
                        index = LS;
                    }
                    else
                        break;
                }
                else
                {
                    if (Convert.ToDouble(Elements[index]) < Convert.ToDouble(Elements[RS]))
                    {
                        Swap(ref Elements[index],ref Elements[RS]);
                        index = RS;
                    }
                    else
                        break;
                }
            }
            Count--;
            return peek;
        }
        public T Peek()
        {
            return Elements[0];
        }
        private void Swap(ref T a,ref T b)
        {
            T c = a;
            a = b;
            b = c;
            return;
        }
        private void IncreaseCapacity()
        {
            Capacity++;
            Capacity *= 2;
            T[] newElements = new T[Capacity];
            Array.Copy(Elements, newElements, Elements.Length);
            Elements = newElements;
        }
        public void Print()
        {
            for(int i = 0; i < Count; i++)
            {
                Console.Write(Elements[i]);
            }
            Console.WriteLine();
        }
    }
}
