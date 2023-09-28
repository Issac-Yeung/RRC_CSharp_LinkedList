/*
* Name: Wai Lit Yeung 
* Program: Business Information Technology
* Course: ADEV-3009 Data Structure and Algorithms
* MileStone 1: 10 Sept 2023
* MileStone 2: 21 Sept 2023
* MileStone 3: 25 Sept 2023
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestLibrary
{
    public class LinkedList<T> where T : IComparable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int size;

        /// <summary>
        /// LinkedList Constructor
        /// </summary>
        public LinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        /// <summary>
        /// Size Property
        /// </summary>
        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        /// <summary>
        /// Head Property
        /// </summary>
        public Node<T>? Head
        {
            get { return this.head; }
            set { this.head = value; }
        }

        /// <summary>
        /// Tail Property
        /// </summary>
        public Node<T>? Tail
        {
            get { return this.tail; }
            set { this.tail = value; }
        }

        /// <summary>
        /// Clear method - reset the linkedlist
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        /// <summary>
        /// IsEmpty method - Check the linkedlist is empty or not
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.size == 0;
        }

        /// <summary>
        /// GetFirst method - return first node
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T? GetFirst()
        {
            if (IsEmpty())
                throw new ApplicationException("The list is empty.");
            return head.Element;
        }

        /// <summary>
        /// GetLast - return last node
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T? GetLast()
        {
            if (IsEmpty())
                throw new ApplicationException("The list is empty.");
            return tail.Element;
        }

        /// <summary>
        /// SetFirst method - Set the first node
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public T? SetFirst(T element)
        {
            if (element == null)
                throw new ArgumentNullException("The element is null.");
            if (IsEmpty())
                throw new ApplicationException("The list is empty.");
            T? oldElement = head.Element;
            head.Element = element;
            return oldElement;
        }

        /// <summary>
        /// SetLast method - Set the last node
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public T? SetLast(T element)
        {
            if (element == null)
                throw new ArgumentNullException("The element is null.");
            T? oldElement = GetLast();
            tail.Element = element;
            return oldElement;
        }

        /// <summary>
        /// AddFirst Method - Add the first node and move the original node to next node
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddFirst(T element)
        {
            if (element == null)
                throw new ArgumentNullException("Null Element is not allowed");
            Node<T> newNode = new Node<T>(element, previousNode: null, nextNode: head);
            if (IsEmpty())
                tail = newNode;
            else
                head.Previous = newNode;
            head = newNode;
            this.size++;
        }

        /// <summary>
        /// AddLast Method - Add the last node and move the original node to previous node
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddLast(T element)
        {
            if (element == null)
                throw new ArgumentNullException("Null Element is not allowed");
            Node<T> newNode = new Node<T>(element, tail, null);
            if (IsEmpty())
                head = newNode;
            else
                tail.Next = newNode;
            tail = newNode;
            this.size++;
        }

        /// <summary>
        /// RemoveFirst
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T? RemoveFirst()
        {
            return RemoveNode(head);
        }

        /// <summary>
        /// RemoveLast
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T? RemoveLast()
        {
            return RemoveNode(tail);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T? Get(int position)
        {
            return this.GetNodeAt(position).Element;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T? Remove(int position)
        {
            Node<T>? currentNode = GetNodeAt(position);

            return RemoveNode(currentNode);
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public T? Set(T element, int position)
        {
            if (element == null)
                throw new ArgumentNullException("The element is null.");

            Node<T>? currentNode = GetNodeAt(position);
            T? oldElement = currentNode.Element;
            currentNode.Element = element;
            return oldElement;
        }

        /// <summary>
        /// AddAfter
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public void AddAfter(T element, int position)
        {
            if (element == null)
                throw new ArgumentNullException("The element is null.");

            Node<T>? currentNode = GetNodeAt(position);

            Node<T>? newNode = new Node<T>(element, previousNode: currentNode, nextNode: currentNode.Next);
            Node<T>? after = newNode.Next;
            if (after != null)
            {
                after.Previous = newNode;
            }
            else
            {
                tail = newNode;
            }
            currentNode.Next = newNode;
            this.size++;
        }

        /// <summary>
        /// AddBefore
        /// </summary>
        /// <param name="element"></param>
        /// <param name="position"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public void AddBefore(T element, int position)
        {
            if (element == null)
                throw new ArgumentNullException("The element is null.");

            Node<T>? currentNode = GetNodeAt(position);

            Node<T>? newNode = new Node<T>(element, previousNode: currentNode.Previous, nextNode: currentNode);
            if (currentNode.Previous != null)
                currentNode.Previous.Next = newNode;
            else
                head = newNode;

            currentNode.Previous = newNode;
            this.size++;
        }

        /// <summary>
        /// GetNodeAt
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        private Node<T> GetNodeAt(int position)
        {
            if (position <= 0 || position > size)
                throw new ApplicationException("Position out of range");

            Node<T> currentNode = head;
            for (int i = 1; i < position; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        /// <summary>
        /// RemoveNode
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private T RemoveNode(Node<T> currentNode)
        {
            if (IsEmpty())
                throw new ApplicationException("The list is empty.");

            T removedElement = currentNode.Element;
            if (currentNode.Previous != null)
                currentNode.Previous.Next = currentNode.Next;
            else
                head = currentNode.Next;

            if (currentNode.Next != null)
                currentNode.Next.Previous = currentNode.Previous;
            else
                tail = currentNode.Previous;

            size--;
            return removedElement;
        }

        // Milestone 3
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public T? Get(T? element)
        {
           
            return this.Get(this.GetAt(element));
        }

        /// <summary>
        /// GetAt
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        private int GetAt(T? element)
        {
            if (element == null)
                throw new ArgumentNullException("The element is null");

            Node<T> currentNode = head;
            for (int i = 1; i <= size; i++)
            {
                currentNode = GetNodeAt(i);
                if (currentNode.Element.CompareTo(element) == 0)
                    return i;
            }
            return 0;
        }

        /// <summary>
        /// AddAfter
        /// </summary>
        /// <param name="element"></param>
        /// <param name="oldElement"></param>
        public void AddAfter(T? element, T oldElement) 
        {
            int position = this.GetAt(oldElement);
            this.AddAfter(element, position);
        }

        /// <summary>
        /// AddBefore
        /// </summary>
        /// <param name="element"></param>
        /// <param name="oldElement"></param>
        public void AddBefore(T element, T oldElement) 
        {
            int position = this.GetAt(oldElement);
            this.AddBefore(element, position);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public T Remove(T element) 
        {
            return Remove(this.GetAt(element));
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <param name="element"></param>
        /// <param name="oldElement"></param>
        /// <returns></returns>
        public T Set(T element, T oldElement) 
        {
            return this.Set(element, this.GetAt(oldElement));
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="element"></param>
        public void Insert(T element) 
        {
            if (IsEmpty() || head.Element.CompareTo(element) > 0)
            {
                AddFirst(element);
                return;
            }

            if (tail.Element.CompareTo(element) < 0)
            {
                AddLast(element);
                return;
            }

            for (int i = 1; i <= this.size; i++)
            {
                if (element.CompareTo(this.Get(i)) <= 0)
                {
                    this.AddBefore(element, i);
                    return;
                }
            }
        }

        /// <summary>
        /// BubbleSort
        /// </summary>
        private void BubbleSort()
        {
            // Check if the list is empty or has only one element
            if (IsEmpty() || size == 1)
                return;

            bool swapped;
            Node<T> start = head;
            Node<T> end = null;

            do
            {
                swapped = false;
                Node<T> current = start;

                while (current.Next != end)
                {
                    if (current.Element.CompareTo(current.Next.Element) > 0)
                    {
                        // Swap the elements
                        T? temp = current.Element;
                        current.Element = current.Next.Element;
                        current.Next.Element = temp;

                        swapped = true;
                    }

                    // Move to the next node
                    current = current.Next;
                }

                // Update the end node after each pass
                end = current;

            } while (swapped);
        }

        /// <summary>
        /// SortAscending
        /// </summary>
        public void SortAscending() 
        {
            this.BubbleSort();
        }



    }
}


