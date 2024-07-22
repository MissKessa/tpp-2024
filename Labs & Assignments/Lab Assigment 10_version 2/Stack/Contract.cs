using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal static class Contract
    {
        public static void Invariant(Boolean condition)
        {
            Debug.Assert(condition);
        }

        public static void RequiresState(Boolean condition, String message)
        {
            Requires(condition, new InvalidOperationException(message));
        }

        public static void RequiresArgument(Boolean condition, String message)
        {
            Requires(condition, new ArgumentException(message));
        }
        private static void Requires(Boolean condition, Exception exc)
        {
            if (!condition)
            {
                throw exc;
            }
        }

        public static void Ensures(Boolean condition)
        {
            Debug.Assert(condition);
        }
    }
}
