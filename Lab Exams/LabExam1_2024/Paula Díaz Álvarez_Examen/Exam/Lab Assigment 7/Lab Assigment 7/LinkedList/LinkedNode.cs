using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public partial class List<T>
    {
        /// <summary>
        /// Node class for the LinkedList elements that are capable to store Objects
        /// </summary>
        private class LinkedNode
        {
            /// <summary>
            /// Value stored in the node
            /// </summary>
            T value;
            /// <summary>
            /// Reference to the next node of this node
            /// </summary>
            LinkedNode next;

            /// <summary>
            /// Constructor that creates the node with the value passed as parameter
            /// </summary>
            /// <param name="value">It's the value for the Node</param>
            public LinkedNode(T value)
            {
                this.value = value;
                next = null;
            }

            /// <summary>
            /// Getter and setter for the value of the Node
            /// </summary>
            public T Value
            {
                get { return value; }
                set { this.value = value; }
            }
            /// <summary>
            /// Getter and setter for the Next node reference
            /// </summary>
            public LinkedNode Next
            {
                get { return next; }
                set { this.next = value; }
            }
        }
    }
}
