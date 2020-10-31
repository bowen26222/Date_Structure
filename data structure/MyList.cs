using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure
{
    public class MyNode<T>
    {
        public T Data { get; set; }
        public MyNode<T> Next { get; set; }
        public MyNode(T data)
        {
            this.Data = data;
            this.Next = default;
        }
        public MyNode()
        {
            this.Data = default;
            this.Next = default;
        }
    }
    public class MyLinkList<T>
    { 
        public MyNode<T> Head { get; set; }
        public MyLinkList()
        {
            Head = null;
            
        }
        public void Add(T NewNode)
        {
            MyNode<T> now = new MyNode<T>(NewNode);
            if (Head == null)
            {
                Head = now;
                return;
            }
            MyNode<T> last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = now;
        }
        public void Delete(int index)
        {
            if(Head == null)
            {
                throw new InvalidOperationException("LinkList is empty");
            }
            MyNode<T> last = Head;
            for(int i = 1; i < index; i++)
            {
                last = last.Next;
            }
            last.Next = last.Next.Next; 
        }
        public void Insert(T NewNode,int index)
        {
            MyNode<T> now = new MyNode<T>(NewNode);
            MyNode<T> last = Head;
            for (int i = 1; i < index; i++)
            {
                last = last.Next;
                if (last == null)
                {
                    throw new InvalidOperationException("index isn't valid");
                }
            }
            now.Next = last.Next;
            last.Next = now;
        }
        public T Find(int index)
        {
            MyNode<T> last = Head;
            for (int i = 1; i <= index; i++)
            {
                last = last.Next;
            }
            return last.Data;
        }
        public void Print()
        {
            for (MyNode<T> last = Head; last != null;last = last.Next )
            {
                Console.WriteLine(last.Data);
            }
        }
    }

}
