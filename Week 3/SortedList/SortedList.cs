using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    internal class SortedList<T> : IList<T> where T:IComparable
    {
        private T[] innerArray;
        private int count;
        private int capacity;
        public T this[int index] { 
            get => innerArray[index]; 
            set => innerArray[index] = value; 
        }

        public SortedList(int capacity)
        {
            count = 0;
            this.capacity = capacity;
            innerArray = new T[capacity];
        }

        public int Count => Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            // Do not insert if full
            if (IsFull) return;

            // Strategy:
            // Compare the item with the last (largest element)
            // If the item is larger

            int j = capacity - 2;
            while (j > 0 && innerArray[j].CompareTo(item) < 0)
            {
                innerArray[j + 1] = innerArray[j];
                j--;
            }
            innerArray[j + 1] = item;
        }

        public void Clear()
        {
            count = 0;
            innerArray = new T[capacity];
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (innerArray[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            // Do not insert if full
            if (IsFull) return;

            // Strategy:
            // Compare the item with the last (largest element)
            // If the item is larger

            int j = capacity - 1;
            while (j >= 0 && innerArray[index].CompareTo(item) > 0)
            {
                innerArray[j - 1] = innerArray[j];
                j--;
            }
            innerArray[j] = item;
            count++;
        }

        public bool Remove(T item)
        {
            // Do not remove if empty
            if (IsEmpty) return false;

            int indexToRemove = IndexOf(item);
            // Shift everything to the left, starting at the next element.
            for (int i = indexToRemove + 1; i < count; i++)
            {
                innerArray[i] = innerArray[i + 1];
            }
            count--;
            return true;
        }

        public bool IsEmpty => count == 0;
        public bool IsFull => count == capacity;

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string composedString = "";
            for (int i = capacity - count - 1; i >= 0; i--)
            {
                composedString += innerArray[i].ToString() + " ";
            }
            return composedString;
        }
    }
}
