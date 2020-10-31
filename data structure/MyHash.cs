using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace data_structure
{
    public class MyHash<TKey,TValue>
    {
        private struct Element
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;
        }
        private int[] Buckets { get; set; }
        private Element[] Elements { get; set; }
        public int Capacity { get; set; }
        public int Count { get; set; }       
        private int freeList;       
        private int freeCount;
        public MyHash(int capacity = 5)
        {
            Capacity = capacity;
            Buckets = new int[Capacity];
            for (int i = 0; i < Buckets.Length; i++) Buckets[i] = -1;
            Elements = new Element[Capacity];
            freeList = -1;
        }
        public static int GetHashCode(string key)
        {
            uint hash = 5381;
            for (int i = 0; i < key.Length; i++)
                hash = ((hash << 5) + hash) ^ key[i];
            return (int)hash;
        }
        public void Add(TKey key,TValue value)
        {
            Insert(key, value);
        }
        private void Insert(TKey key, TValue value)
        {
            int hashCode = GetHashCode(Convert.ToString(key)) & 0x7FFFFFFF;
            int targetBucket = hashCode % Buckets.Length;
            for (int i = Buckets[targetBucket]; i >= 0; i = Elements[i].next)
            {
                if (Elements[i].hashCode == hashCode && Equals(Elements[i].key, key))
                {
                    throw new InvalidOperationException("Replace the same place elememt");
                }
            }
            int index;
            if(freeCount > 0)
            {
                index = freeList;
                freeList = Elements[index].next;
                freeCount--;
            }
            else
            {
                if(Count == Elements.Length)
                {
                    IncreaseCapacity();
                    targetBucket = hashCode % Buckets.Length;
                }
                index = Count;
                Count++;
            }
            Elements[index].hashCode = hashCode;
            Elements[index].next = Buckets[targetBucket];
            Elements[index].key = key;
            Elements[index].value = value;
            Buckets[targetBucket] = index;
        }
        public void Print()
        {
            for(int i = 0; i < Count; i++)
            {
                Console.WriteLine("{0} {1}",Elements[i].key,Elements[i].value);
            }
        }
        private int GetPos(TKey key)
        {
            int hashCode = GetHashCode(Convert.ToString(key)) & 0x7FFFFFFF;
            int targetBucket = hashCode % Buckets.Length;
            int index = Buckets[targetBucket];
            for(; index!=-1;index=Elements[index].next)
            {
                if(Elements[index].hashCode == hashCode && Equals(Elements[index].key, key))
                {
                    return index;
                }
            }
            return default;
        }
        public TValue GetValue(TKey key)
        {
            int i = GetPos(key);
            if (i >= 0)
            {
                return Elements[i].value;
            }
            return default;
        }
        public bool Remove(TKey key)
        {
            if (Buckets != null) 
            {
                int hashCode = GetHashCode(Convert.ToString(key)) & 0x7FFFFFFF;
                int bucket = hashCode % Buckets.Length;
                int last = -1;
                for (int index = Buckets[bucket]; index >= 0; last = index, index=Elements[index].next){
                    if (Elements[index].hashCode == hashCode && Equals(Elements[index].key, key))
                    {
                        Console.WriteLine(key);
                        if (last < 0)
                        {
                            Buckets[bucket] = Elements[index].next;
                        }
                        else
                        {
                            Elements[last].next = Elements[index].next;
                        }
                        Elements[index].hashCode = -1;
                        Elements[index].next = freeList;
                        Elements[index].key = default;
                        Elements[index].value = default;
                        freeList = index;
                        freeCount++;
                        return true;
                    }
                }
            }
            return false;
        }
        private void IncreaseCapacity()
        {
            Capacity++;
            Capacity *= 2;
            int newSize = Capacity;
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++) newBuckets[i] = -1;
            Element[] newElements = new Element[newSize];
            Array.Copy(Elements, 0, newElements, 0, Elements.Length);
            for (int i = 0; i < Count; i++)
            {
                if (newElements[i].hashCode != -1)
                {
                     newElements[i].hashCode = (GetHashCode(Convert.ToString(newElements[i].key)) & 0x7FFFFFFF);
                }
            }
            for (int i = 0; i < Count; i++)
            {
                if (newElements[i].hashCode >= 0)
                {
                    int bucket = newElements[i].hashCode % newSize;
                    newElements[i].next = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }
            Buckets = newBuckets;
            Elements = newElements;
        }
        public void Clear()
        {
            if (Count > 0)
            {
                for (int i = 0; i < Buckets.Length; i++) Buckets[i] = -1;
                Array.Clear(Elements, 0, Count);
                freeList = -1;
                Count = 0;
                freeCount = 0;
            }
        }
    }
}
