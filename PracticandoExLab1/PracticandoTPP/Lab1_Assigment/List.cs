using System;
using System.Reflection;

namespace Lab1_Assigment
{
    public class List //Linked List capable of storing integers
    {
        public class Node {
            private int value;
            private Node next;
            public Node() { value = 0; }
            public Node(int value) { this.value = value; }

            public int Value { get { return value; } }
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
            root=new Node();
            size++;
        }
        public List(Node n)
        {
            root = n;
            size++;
        }

        public List(int value)
        {
            root = new Node(value);
            size++;
        }

        public Boolean AddNode(Node n) //adds a given node at the end
        {
            return AddValue(n.Value);
        }

        public Boolean AddValue(int value) //adds a given value at the end
        {
            return AddValueAtPosition(value, size);
        }

        public Boolean AddNodeAtPosition(Node n, int position) //adds a given node at the given position
        {
            return AddValueAtPosition(n.Value, size);
        }

        public Boolean AddValueAtPosition(int value, int index) //adds a given value at the given position
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

        public Boolean RemoveByValue(int value)
        {
            Node node = root;
            Node nextNode = root.Next;

            if (root.Value == value)
            {
                root = nextNode;
                size--;
                return true;
            }
            for (int i = 0; i < NumberOfElements; i++)
            {
                if (nextNode.Value == value)
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


        public int RemoveByPosition(int index)
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

        public int RemoveFirst()
        {
            return RemoveByPosition(0);
        }

        public int GetElement(int position)
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

        public String toString()
        {
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
        public void printAllElements()
        {
            for (int i = 0; i < NumberOfElements; i++)
            {
                Console.WriteLine(GetElement(i));
            }
        }


    }
}
