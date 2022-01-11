using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomCollections
{
    public class IntegerCollection : IEnumerable 
    {
        Element<int> head;

        public int Count { get; private set; }

        public IEnumerator GetEnumerator()
        {
            if (Count == 0) yield break;

            Element<int> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void Add(int value)
        {
            if (Count == 0)
            {
                head = new Element<int>(value);
                Count++;
            }
            else
            {
                Element<int> previous = GetLastElement();
                previous.Next = new Element<int>(value);
                Count++;
            }
        }

        private Element<int> GetLastElement()
        {
            Element<int> current = head;
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
            Element<int> current = head;

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

        public int RemoveByIndexAndReturnValue(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException($"Index out of Range. Current index = {index}. Available indexes is between 0 and {Count - 1}");


            if (index == 0)
            {
                int deletedValue = head.Value;
                head = head.Next;
                Count--;
                return deletedValue;
            }
            Element<int> current = head;

            for (int i = 0; i < Count; i++)
            {
                if (i + 1 == index)
                {
                    int deletedValue = current.Next.Value;
                    current.Next = current.Next.Next;
                    Count--;
                    return deletedValue;
                }
                current = current.Next;
            }
            throw new Exception("Not found");
        }

        public int RemoveFirstByValue(int value)
        {
            if (Count == 0) throw new Exception("List is empty");


            if (value == head.Value)
            {
                head = head.Next;
                Count--;
                return 0;
            }

            Element<int> current = head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Next != null && current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return i + 1;
                }
                current = current.Next;
            }

            throw new Exception($"This value ({value}) wasn`t found.");
        }

        public List<int> RemoveAllByValue(int value)
        {
            if (Count == 0) throw new Exception("List is empty");
            Element<int> current = head.Next;
            Element<int> previous = head;

            List<int> result = new List<int>();

            for (int i = 0; i < Count; i++)
            {
                if (current == null)
                {
                    break;
                }
                if (value == current.Value)
                {
                    result.Add(i + 1);
                    previous.Next = current.Next;
                    current = previous.Next;
                }
                else
                {
                    previous = current;
                    current = previous.Next;
                }
            }

            if (value == head.Value)
            {
                result.Add(0);
                head = head.Next;
            }

            if (result.Count == 0)
            {
                throw new Exception($"This value ({value}) wasn`t found.");
            }

            Count -= result.Count;
            return result;
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public int IndexOf(int value)
        {
            Element<int> current = head;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value == value)
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(int value)
        {
            Element<int> current = head;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value == value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        private int FindValueByIndex(int index)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException($"Index out of Range. Current index = {index}. Available indexes is between 0 and {Count - 1}");

            Element<int> current = head;
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

        private void PutValueByIndex(int index, int value)
        {
            if (index >= Count || index < 0) throw new IndexOutOfRangeException($"Index out of Range. Current index = {index}. Available indexes is between 0 and {Count - 1}");

            Element<int> current = head;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    current.Value = value;
                }
                current = current.Next;
            }
        }

        public int this[int index]
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

        public static bool operator ==(IntegerCollection list1, IntegerCollection list2)
        {
            return list1.Equals(list2);
        }
        public static bool operator !=(IntegerCollection list1, IntegerCollection list2)
        {
            return !list1.Equals(list2);
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            IntegerCollection list = (IntegerCollection)obj;
            if (Count != list.Count) return false;

            Element<int> current = head;
            foreach (int item in list)
            {
                if (item != current.Value)
                {
                    return false;
                }
                current = current.Next;
            }
            return true;
        }

    }
}
