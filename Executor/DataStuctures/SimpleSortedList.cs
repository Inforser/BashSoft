namespace Executor.DataStuctures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private readonly IComparer<T> comparison;
        private T[] innerCollection;
        private int size;
        private int capacity;

        public SimpleSortedList(IComparer<T> comparison, int capacity)
        {
            this.capacity = capacity;
            this.size = 0;
            ////
            this.comparison = comparison;
            this.InitialiseInnerCollection(this.capacity);
        }       

        public SimpleSortedList(int capacity)
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparison)
            : this(comparison, DefaultSize)
        {
        }

        public SimpleSortedList() : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public int Size => this.size;
        
        public void Add(T element)
        {
            if (this.Size >= capacity)
            {
                this.Resize();
            }
            this.innerCollection[size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, this.Size, this.comparison);
        }

        

        public void AddAll(ICollection<T> elements)
        {
            var wantedCapacity = this.Size + elements.Count;
            if (wantedCapacity >= this.capacity)
            {
                this.MultiResize(wantedCapacity);
            }

            foreach (var element in elements)
            {
                this.innerCollection[this.Size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.Size, this.comparison);
        }

        public string JoinWith(string joiner)
        {
            var builder = new StringBuilder();
            foreach (var element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }

            //builder.Remove(builder.Length - 1, 1);
            builder.Remove(builder.Length - joiner.Length, joiner.Length);
            return builder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        private void InitialiseInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        private void Resize()
        {
            this.capacity *= 2;
            var newCollection = new T[this.capacity];
            Array.Copy(innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        private void MultiResize(int wantedCapacity)
        {
            while (wantedCapacity >= this.capacity)
            {
                this.capacity *= 2;
            }

            var newCollection = new T[this.capacity];
            Array.Copy(innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
