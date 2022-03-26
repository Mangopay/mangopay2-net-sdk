using System;
using System.Collections;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities
{
    public class ListPaginated<T> : ICollection<T>
    {
        private IList<T> _entities;

        /// <summary>Number of total pages.</summary>
        public int TotalPages { get; internal set; }

        /// <summary>Number of total items.</summary>
        public int TotalItems { get; internal set; }

        /// <summary>
        /// Four-elements array with links to navigation. All values are optional. Format:
        /// Links[0] -> first, 
        /// Links[1] -> previous, 
        /// Links[2] -> next, 
        /// Links[3] -> last.
        /// </summary>
        public string[] Links;

        public ListPaginated(IList<T> entities, int totalPages, int totalItems)
        {
            _entities = entities;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Links = new string[4];
        }
        public ListPaginated(IList<T> entities) : this(entities, 0, 0) { }
        public ListPaginated() : this(new List<T>(), 0, 0) { }

        
        public T this[int index]
        {
            get
            {
                return _entities[index];
            }
        }

        public void Add(T item)
        {
            _entities.Add(item);
        }

        public void Clear()
        {
            _entities.Clear();
        }

        public bool Contains(T item)
        {
            return _entities.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _entities.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _entities.Count; }
        }

        public bool IsReadOnly
        {
            get { return _entities.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return _entities.Remove(item);
        }

        public IEnumerator GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }
    }
}
