using System;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace Lab2_Assigment.List
{
    public class List //Linked List capable of storing any object (POLYMORPHIC)
    {
        public class Node {
            private Object value;
            private Node next;
            public Node() { value = null; }
            public Node(Object value) { this.value = value; }

            public Object Value { get { return value; } }
            public Node Next { get { return next; } set { next = value; } }
        }
        private Node root; 
        private int size;
        public int NumberOfElements
        {
            get { return size; }
            set { size = value; }
        }

        public List() {
            root=null;
        }
        public List(Node n)
        {
            root = n;
            size++;
        }

        public List(Object value)
        {
            root = new Node(value);
            size++;
        }

        public Boolean AddNode(Node n) //adds a given node at the end
        {
            return AddValue(n.Value);
        }

        public Boolean AddValue(Object value) //adds a given value at the end
        {
            return AddValueAtPosition(value, size);
        }

        public Boolean AddNodeAtPosition(Node n, int position) //adds a given node at the given position
        {
            return AddValueAtPosition(n.Value, size);
        }

        public virtual Boolean AddValueAtPosition(Object value, int index) //adds a given value at the given position
        {
            if (index < 0 || index > NumberOfElements)
                return false;
            Node newNode = new Node(value);

            Node currentNode = root;
            if (root == null)
            {
                root = newNode;
                size++;
                return true;
            }
            if (index == 0)
            {
                newNode.Next = currentNode;
                root = newNode;
                size++;
                return true;
            }

            for (int i = 0; i < index - 1; i++)
            {
                currentNode = currentNode.Next;
            }
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
            size++;
            return true;
        }

        public Boolean RemoveNode(Node n)
        {
            return RemoveByValue(n.Value);
        }

        public Boolean RemoveByValue(Object value)
        {
            Node node = root;
            Node nextNode = root.Next;

            if (root.Value.Equals(value))
            {
                root = nextNode;
                size--;
                return true;
            }
            for (int i = 0; i < NumberOfElements; i++)
            {
                if (nextNode.Value.Equals(value))
                {
                    node.Next = nextNode.Next;
                    size--;
                    return true;
                }
                node = node.Next;
                nextNode = nextNode.Next;
            }
            return false;
        }


        public Object RemoveByPosition(int index)
        {
            if (index < 0 || index >= NumberOfElements)
                throw new IndexOutOfRangeException($"The index isn't valid (it must be between 0 and {NumberOfElements}");

            Node node = root;
            Node nextNode = root.Next;

            if (index == 0)
            {
                root = nextNode;
                size--;
                return node.Value;
            }
            for (int i = 0; i < index - 1; i++)
            {
                node = node.Next;
                nextNode = nextNode.Next;
            }

            if (index == NumberOfElements - 1)
            {
                node.Next = null;
            }
            node.Next = nextNode.Next;
            NumberOfElements--;
            return nextNode.Value;
        }

        public Object RemoveFirst()
        {
            return RemoveByPosition(0);
        }

        public Object GetElement(int position)
        {
            return GetNode(position).Value;
        }

        public Node GetNode(int position)
        {
            if (position < 0 || position >= NumberOfElements)
            {
                throw new IndexOutOfRangeException($"The index isn't valid (it must be between 0 and {NumberOfElements}");
            }
            Node currentNode = root;
            for (int i = 0; i < position; i++)
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        public Boolean Contains(Object value)
        {
            Node current = root;
            for (int i = 0;i < NumberOfElements;i++)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current=current.Next;
            }
            return false;
        }

        public override String ToString()
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
            Node currentNode = root;
            for (int i = 0; i < NumberOfElements; i++)
            {
                aux += $"({currentNode.Value})-";
                currentNode = currentNode.Next;
            }
            return aux;
        }

        /// <summary>
        /// Used for testing: prints all the elements of the list by going through it and calling getElement()
        /// </summary>
        public void PrintAllElements()
        {
            for (int i = 0; i < NumberOfElements; i++)
            {
                Console.WriteLine(GetElement(i));
            }
        }


    }
}
