/* 
 * Nota: Este proyecto hace uso de la clase Angulo definido en el proyecto contructor.destructor
 * Para acceder desde un assembly a otro (nuestro caso), hay que a�adir la referencia a este proyecto.
 * Para ello, en el proyecto en el que deseamos a�adir la referencia, hacemos right-click en el 
 * "references" y seleccionamos a�adir referencia; elegimos la pesta�a de proyectos y seleccionamos el proyecto
 * adecuado (constructor.destructor en nuestro caso)
 * Recuerde que para hacer esto, la clase Angulo ha de ser p�blica.
 */


/// <summary>
/// Demostraci�n de uso de arrays unidimensionales
/// </summary>
/// 

using ClasesObjetos;
using System;

namespace ClasesObjetos {

    class ArrayDemo {

        /// <summary>
        /// Demostraci�n de arrays unidimensionales
        /// </summary>
        internal static void Run() {
            // * Inicializaci�n y declaraci�n de arrays

            int[] arrayEnteros; // * Declaraci�n de la referencia
            arrayEnteros = new int[10]; // * Creaci�n del objeto (todos 0)

            // * Declaraci�n, creaci�n e inicializaci�n
            bool[] arrayValoresL�gicos = { true, false };

            // * Array de Objetos
            // * Creamos la referencia
            Angulo[] cuadrante;
            // * Creamos el objeto array (5 referencias = null)
            cuadrante = new Angulo[5];
            // * Creamos cada uno de los objetos de cada referencia
            cuadrante[0] = new Angulo(0);
            cuadrante[1] = new Angulo(30);
            cuadrante[2] = new Angulo(45);
            cuadrante[3] = new Angulo(60);
            cuadrante[4] = new Angulo(90);

            // * Podemos hacerlo todo en una
            Angulo[] angulos ={ new Angulo(0),new Angulo(90),new Angulo(180),
						new Angulo(270),new Angulo(360) };

            // * Visualizamos todos (sea cual fuere su tama�o) utilizando length
            for (int i = 0; i < angulos.Length; i++) {
                Console.Write("Angulo: " + angulos[i].GetRadianes());
                Console.Write(", seno: " + angulos[i].Seno());
                Console.Write(", coseno: " + angulos[i].Coseno());
                Console.WriteLine(".");
            }

            // * Visualizamos todos con foreach
            foreach (Angulo angulo in angulos) {
                Console.WriteLine("Angulo: " + angulo.GetRadianes());
            }

        }

    }
}