using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LinkedList
{
    /// <summary>
    /// Linked List class capable of collecting LinkedNodes
    /// </summary>
    public partial class List<T>:IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.NumberOfElements; i++)
                yield return GetElement(i);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// It's the root of the List (the first node)
        /// </summary>
        LinkedNode root;
        /// <summary>
        /// The current number of nodes in the List
        /// </summary>
        int numberOfElements;

        /// <summary>
        /// Default constructor of the List.
        /// </summary>
        public List()
        {
            root = null;
        }
        /// <summary>
        /// Constructor of the List. It sets the value of the root as the given one
        /// </summary>
        /// <param name="value">It's the value for the root</param>
        public List(T value)
        {
            root = new LinkedNode(value);
            numberOfElements++;
        }

        /// <summary>
        /// Getter for the number of nodes of the list
        /// </summary>
        public int NumberOfElements
        {
            get { return numberOfElements; }
        }


        /// <summary>
        /// Adds a new node, with the value passed as parameter, to the last position of the list
        /// </summary>
        /// <param name="value">It's the value for the new node to be added</param>
        /// <returns>true as allways it's added</returns>
        public Boolean Add(T value)
        {
            return Add(value, numberOfElements);
        }

        /// <summary>
        /// Adds a new node, with the value passed as parameter, to the given index
        /// </summary>
        /// <param name="value">It's the value for the new node to be added</param>
        /// <param name="index">It's the index for the new node</param>
        /// <returns>true if the node has been added</returns>
        public virtual Boolean Add(T value, int index)
        {
            if (index < 0 || index > numberOfElements)
                return false;
            LinkedNode newNode = new(value); //same as new LinkedNode(value)

            LinkedNode currentNode = root;
            if (root == null)
            {
                root = newNode;
                numberOfElements++;
                return true;
            } if (index == 0)
            {
                newNode.Next = currentNode;
                root = newNode;
                numberOfElements++;
                return  true;
            }

            for (int i = 0; i< index-1; i++)
            {
                currentNode = currentNode.Next;
            }
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
            numberOfElements++;
            return true;
        }

        /// <summary>
        /// Removes the node with the value passed as parameter
        /// </summary>
        /// <param name="value">It's the value of the node wanted to be removed</param>
        /// <returns>true if the node with that value was removed sucessfully</returns>
        public Boolean Remove(T value)
        { //this is the remove(T value)
            LinkedNode node = root;
            LinkedNode nextNode = root.Next;

            if (root.Value.Equals(value))
            {
                root = nextNode;
                numberOfElements--;
                return true;
            }
            for (int i = 0; i < numberOfElements; i++)
            {
                if (nextNode.Value.Equals(value))
                {
                    node.Next = nextNode.Next;
                    numberOfElements--;
                    return true;
                }
                node = node.Next;
                nextNode = nextNode.Next;
            }
            return false;
        }

        /// <summary>
        /// Removes the node with the value passed as parameter
        /// </summary>
        /// <param name="value">It's the value of the node wanted to be removed</param>
        /// <returns>the node with that value if it was removed sucessfully</returns>
        public T RemoveByPosition(int index)
        { 
            if (index < 0 || index >= numberOfElements)
                throw new IndexOutOfRangeException($"The index isn't valid (it must be between 0 and {numberOfElements}");

            LinkedNode node = root;
            LinkedNode nextNode = root.Next;

            if (index == 0)
            {
                root = nextNode;
                numberOfElements--;
                return node.Value;
            }
            for (int i = 0; i < index -1 ; i++)
            { 
                node = node.Next;
                nextNode = nextNode.Next;
            }

            if (index== numberOfElements - 1)
            {
                node.Next = null;
            }
            node.Next = nextNode.Next;
            numberOfElements--;
            return nextNode.Value;
        }

        /// <summary>
        /// Removes the root
        /// </summary>
        /// <returns>returns the root value (not null)</returns>
        public T RemoveFirst()
        {
            return RemoveByPosition(0);
        }

        /// <summary>
        /// Returns the value of the node at the given index
        /// </summary>
        /// <param name="index">It's the index of the node to be retrieved</param>
        /// <returns>The value of the node</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T GetElement(int index)
        {
            if (index < 0 || index >= numberOfElements)
            {
                throw new IndexOutOfRangeException($"The index isn't valid (it must be between 0 and {numberOfElements}");
            }
            LinkedNode currentNode = root;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Value;
        }

        /// <summary>
        /// It returns a string representing the list as: (value)-(value)-....
        /// </summary>
        /// <returns>The string representing the list</returns>
        override
        public String ToString()
        {
            NumberFormatInfo nfi = new()
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ""
            };
            CultureInfo ci = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            ci.NumberFormat = nfi;
            Thread.CurrentThread.CurrentCulture = ci;

            String aux = "";
            LinkedNode currentNode = root;
            for (int i = 0; i < numberOfElements; i++)
            {
                aux += $"({currentNode.Value})-";
                currentNode = currentNode.Next;
            }
            return aux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">It's the value to see if it's in the LinkedList</param>
        /// <returns>if the value is in the LinkedList</returns>
        public Boolean Contains(T value)
        {
            LinkedNode node = root;
            for (int i=0; i < numberOfElements; i++)
            {
                if(node.Value.Equals(value))
                    return true;
                node = node.Next;
            }
            return false;
        }
    }
}
