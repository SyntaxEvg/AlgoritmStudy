using GeekBrainsTests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm.LInkL
{
    public class LinkedList<T> : ILinkedList<T>, IEnumerable
    {
        public LinkedListNode<T> head;
        int count;
        int version;

        /// <summary>
        /// Кол-во элементов в списке
        /// </summary>
        public int GetCount()
        {
            return Count;
        }
        /// <summary>
        /// добавляем элемент
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(T value)
        {
            AddLast(value);
        }
        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddNodeAfter(LinkedListNode<T> node, T value)
        {
            AddAfter(node, value);
        }
        /// <summary>
        /// удаляет по порядковому номеру
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public void RemoveNode(T index)
        {
            Remove(index);
        }
        /// <summary>
        /// удаляет выбранный элемент 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public void RemoveNode(LinkedListNode<T> node)
        {
            Remove(node);
        }
        /// <summary>
        ///  поиск элемента по его значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public LinkedListNode<T> FindNode(T searchValue)
        {
            return Find(searchValue);
        }


        public LinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (T value in collection)
            {
                this.AddLast(value);
            }
        }

        public LinkedList()
        {
        }

        int Count
        {
            get
            {
                return this.count;
            }
        }


        public LinkedListNode<T> First
        {
            get
            {
                return this.head;
            }
        }


        public LinkedListNode<T> Last
        {

            get
            {
                if (this.head != null)
                {
                    return this.head.prev;
                }
                return null;
            }
        }



        //void Add(T value)
        //{
        //	this.AddLast(value);
        //}

        LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
        {
            this.ValidateNode(node);
            LinkedListNode<T> linkedListNode = new LinkedListNode<T>(node.list, value);
            this.InsertNodeBefore(node.next, linkedListNode);
            return linkedListNode;
        }

        public void AddAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            this.ValidateNode(node);
            this.ValidateNewNode(newNode);
            this.InsertNodeBefore(node.next, newNode);
            newNode.list = this;
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
        {
            this.ValidateNode(node);
            LinkedListNode<T> linkedListNode = new LinkedListNode<T>(node.list, value);
            this.InsertNodeBefore(node, linkedListNode);
            if (node == this.head)
            {
                this.head = linkedListNode;
            }
            return linkedListNode;
        }

        public void AddBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            this.ValidateNode(node);
            this.ValidateNewNode(newNode);
            this.InsertNodeBefore(node, newNode);
            newNode.list = this;
            if (node == this.head)
            {
                this.head = newNode;
            }
        }

        public LinkedListNode<T> AddFirst(T value)
        {
            LinkedListNode<T> linkedListNode = new LinkedListNode<T>(this, value);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(linkedListNode);
            }
            else
            {
                this.InsertNodeBefore(this.head, linkedListNode);
                this.head = linkedListNode;
            }
            return linkedListNode;
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            this.ValidateNewNode(node);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InsertNodeBefore(this.head, node);
                this.head = node;
            }
            node.list = this;
        }

        LinkedListNode<T> AddLast(T value)
        {
            LinkedListNode<T> linkedListNode = new(this, value);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(linkedListNode);
            }
            else
            {
                this.InsertNodeBefore(this.head, linkedListNode);
            }
            return linkedListNode;
        }

        public void AddLast(LinkedListNode<T> node)
        {
            this.ValidateNewNode(node);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InsertNodeBefore(this.head, node);
            }
            node.list = this;
        }

        public void Clear()
        {
            LinkedListNode<T> next = this.head;
            while (next != null)
            {
                LinkedListNode<T> linkedListNode = next;
                next = next.Next;
                linkedListNode.Invalidate();
            }
            this.head = null;
            this.count = 0;
            this.version++;
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (index < 0)
            {
                throw new();
            }
            if (index > array.Length)
            {
                throw new();
            }
            if (array.Length - index < this.Count)
            {
                throw new();
            }
            LinkedListNode<T> next = this.head;
            if (next != null)
            {
                do
                {
                    array[index++] = next.item;
                    next = next.next;
                }
                while (next != this.head);
            }
        }


        LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> next = this.head;
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            if (next != null)
            {
                if (value != null)
                {
                    while (!@default.Equals(next.item, value))
                    {
                        next = next.next;
                        if (next == this.head)
                        {
                            return null;
                        }
                    }
                    return next;
                }
                while (next.item != null)
                {
                    next = next.next;
                    if (next == this.head)
                    {
                        return null;
                    }
                }
                return next;
            }
            return null;
        }


        public LinkedListNode<T> FindLast(T value)
        {
            if (this.head == null)
            {
                return null;
            }
            LinkedListNode<T> prev = this.head.prev;
            LinkedListNode<T> linkedListNode = prev;
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            if (linkedListNode != null)
            {
                if (value != null)
                {
                    while (!@default.Equals(linkedListNode.item, value))
                    {
                        linkedListNode = linkedListNode.prev;
                        if (linkedListNode == prev)
                        {
                            goto IL_61;
                        }
                    }
                    return linkedListNode;
                }
                while (linkedListNode.item != null)
                {
                    linkedListNode = linkedListNode.prev;
                    if (linkedListNode == prev)
                    {
                        goto IL_61;
                    }
                }
                return linkedListNode;
            }
        IL_61:
            return null;
        }


        public LinkedList<T>.Enumerator GetEnumerator()
        {
            return new LinkedList<T>.Enumerator(this);
        }



        public bool Remove(T value)
        {
            LinkedListNode<T> linkedListNode = this.Find(value);
            if (linkedListNode != null)
            {
                this.InternalRemoveNode(linkedListNode);
                return true;
            }
            return false;
        }

        public void Remove(LinkedListNode<T> node)
        {
            this.ValidateNode(node);
            this.InternalRemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (this.head == null)
            {
                throw new();
            }
            this.InternalRemoveNode(this.head);
        }

        public void RemoveLast()
        {
            if (this.head == null)
            {
                throw new();
            }
            this.InternalRemoveNode(this.head.prev);
        }



        void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            this.version++;
            this.count++;
        }

        void InternalInsertNodeToEmptyList(LinkedListNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            this.head = newNode;
            this.version++;
            this.count++;
        }

        internal void InternalRemoveNode(LinkedListNode<T> node)
        {
            if (node.next == node)
            {
                this.head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (this.head == node)
                {
                    this.head = node.next;
                }
            }
            node.Invalidate();
            this.count--;
            this.version++;
        }

        internal void ValidateNewNode(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            if (node.list != null)
            {
                throw new();
            }
        }

        internal void ValidateNode(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
            if (node.list != this)
            {
                throw new();
            }
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            internal Enumerator(LinkedList<T> list)
            {
                this._list = list;
                this._version = list.version;
                this._node = list.head;
                this._current = default(T);
                this._index = 0;
            }


            public T Current
            {

                get
                {
                    return this._current;
                }
            }


            object IEnumerator.Current
            {
                get
                {
                    if (this._index == 0 || this._index == this._list.Count + 1)
                    {
                        throw new();
                    }
                    return this.Current;
                }
            }

            public bool MoveNext()
            {
                if (this._version != this._list.version)
                {
                    throw new();
                }
                if (this._node == null)
                {
                    this._index = this._list.Count + 1;
                    return false;
                }
                this._index++;
                this._current = this._node.item;
                this._node = this._node.next;
                if (this._node == this._list.head)
                {
                    this._node = null;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                if (this._version != this._list.version)
                {
                    throw new();
                }
                this._current = default(T);
                this._node = this._list.head;
                this._index = 0;
            }

            public void Dispose()
            {
            }

            readonly LinkedList<T> _list;

            LinkedListNode<T> _node;

            readonly int _version;

            T _current;

            int _index;
        }
    }
}
