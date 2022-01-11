using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomCollections
{
    public class GenericCollection<T> : IEnumerable<T>
    {
        Element<T> head;

        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0) yield break;

            Element<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T value)
        {
            if (Count == 0)
            {
                head = new Element<T>(value);
                Count++;
            }
            else
            {
                Element<T> previous = GetLastElement();
                previous.Next = new Element<T>(value);
                Count++;
            }
        }

        private Element<T> GetLastElement()
        {
            Element<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }

        public void RemoveByIndex(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException($"Index out of Range. Current index = {index}. Available indexes is between 0 and {Count - 1}");

            if (index == 0)
            {
                head = head.Next;
                Count--;
                return;
            }
            Element<T> current = head;

            for (int i = 0; i < Count; i++)
            {
                if (i + 1 == index)
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return;
                }
                current = current.Next;
            }

            throw new Exception("Not found");
        }

        public T RemoveByIndexAndReturnValue(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException($"Index out of Range. Current index = {index}. Available indexes is between 0 and {Count - 1}");

            if (index == 0)
            {
                T deletedValue = head.Value;
                head = head.Next;
                Count--;
                return deletedValue;
            }
            Element<T> current = head;

            for (int i = 0; i < Count; i++)
            {
                if (i + 1 == index)
                {
                    T deletedValue = current.Next.Value;
                    current.Next = current.Next.Next;
                    Count--;
                    return deletedValue;
                }
                current = current.Next;
            }
            throw new Exception("Not found");
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        private T FindValueByIndex(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException($"Index out of Range. Current index = {index}. Available indexes is between 0 and {Count - 1}");

            Element<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            throw new Exception("Not found");
        }

        private void PutValueByIndex(int index, T value)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException($"Index out of Range. Current index = {index}. Available indexes is between 0 and {Count - 1}");

            Element<T> current = head;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    current.Value = value;
                }
                current = current.Next;
            }
        }

        public T this[int index]
        {
            get
            {
                return FindValueByIndex(index);
            }

            set
            {
                PutValueByIndex(index, value);
            }
        }

    }
}
