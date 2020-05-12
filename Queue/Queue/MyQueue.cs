using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class MyQueue<T>
    {
        private T[] array;
        private int count;
        private int first = 0;
        private int last = 0;

        public MyQueue(int length)
        {
            array = new T[length];
        }

        public void Push(T x)
        {
            if (count >= array.Length)
            {
                throw new Exception("Queue overflow");
            }

            array[last] = x;
            count++;
            last++;
            if (last == array.Length)
            {
                last = 0;
            }
        }
        public T Pop()
        {
            if (count == 0)
            {
                throw new Exception("Queue is empty");
            }
            count--;
            T tmp = array[first];
            first = (first + 1) % array.Length;
            return tmp;
        }
        public bool IsEmpty()
        {
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public T Top()
        {
            if (count == 0)
            {
                throw new Exception("Queue is empty");
            }

            return array[first];
        }

        public int Length()
        {
            if (count == 0)
            {
                return 0;
            }
            return count;
        }

        public void Clear()
        {
            count = 0;
        }
    }
}
