using System;

namespace TPP.ObjectOrientation.InheritancePolymorphism {
    /// <summary>
	/// Autoboxing: automatic conversion of built-in types into objects (boxing)
    /// and the other way round (unboxing)
	/// </summary>
	class AutoboxingDemo {

		/// <summary>
		/// Shows both box and unbox
		/// </summary>
		/// <param name="obj">Receives an Int32 object.
        /// If an int is passed as an argument, it its automatically converted (boxing).</param>
		/// <returns>Returns and int, transparently converting the
        /// Int32 obj to the int type (unboxing).</returns>
		private static int Autoboxing(Int32 obj) {
			return obj;
		}

		static void Main() {
			// * Boxing
			int i=3;
			Int32 oi=i;
			Object o=i;
			Console.WriteLine(o); //3
			// * Unboxing
			i=oi;
			Console.WriteLine(i); //3
            i = (int)o;
            Console.WriteLine(i); //3
            // * Autoboxing by means of parameter promotion
			Console.WriteLine(  Autoboxing(i)  ); //3
		}
	}
}
