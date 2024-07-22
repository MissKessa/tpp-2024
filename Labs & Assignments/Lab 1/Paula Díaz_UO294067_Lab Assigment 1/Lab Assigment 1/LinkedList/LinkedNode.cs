using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Assignment
{
    public partial class List
    {
        /// <summary>
        /// Node class for the LinkedList elements that are capable to store integers
        /// </summary>
        private class LinkedNode
        {
            /// <summary>
            /// Integer stored in the node
            /// </summary>
            int value;
            /// <summary>
            /// Reference to the next node of this node
            /// </summary>
            LinkedNode next;

            /// <summary>
            /// Constructor that creates the node with the number passed as parameter
            /// </summary>
            /// <param name="value">It's the numerical value for the Node</param>
            public LinkedNode(int value)
            {
                this.value = value;
                next = null;
            }

            /// <summary>
            /// Getter and setter for the value of the Node
            /// </summary>
            public int Value
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
