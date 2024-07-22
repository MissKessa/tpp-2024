using System;
using System.Collections;
using System.Collections.Generic;

namespace ClasesObjetos {

    /// <summary>
    /// Demostraci�n de Arrays Multidimensionales en C#
    /// </summary>
    class ArraysMultidimensionales {

        static internal void Run() {
            // * Arrays multidimensionales lineales
   	        string[,] vector=new string[3,4];
            // * Length nos da 12 (producto)
            System.Console.WriteLine("N�mero de elementos: {0}.", vector.Length);
            // * Dos dimensiones
            System.Console.WriteLine("N�mero de dimensiones: {0}.", vector.Rank);

            // * Para conocer el tama�o de sus dimensiones, preguntamos con GetLength
            for (int i = 0; i < vector.GetLength(0); i++) 
                for (int j = 0; j < vector.GetLength(1); j++)
                    vector[i,j]="("+(i+1)+","+(j+1)+")";
            // * Se pueden recorrer con una �nica dimensi�n (lineales)
            foreach (string s in vector)
                Console.Write(s + '\t');
            Console.WriteLine();

            // * Arrays de Arrays
	    	// * Creaci�n de arrays multidimensionales
    		int[][] tabla=new int[10][]; // * Tabla de multiplicar
            for (int i=0;i<tabla.Length;i++)
                tabla[i]=new int[10];
            for (int i=0;i<tabla.Length;i++)
			    for (int j=0;j<tabla[i].Length;j++)
				    tabla[i][j]=(i+1)*(j+1);

    		// * Creaci�n de una matriz triangular
	    	int[][] triangular=new int[10][];
		    for (int i=0;i<triangular.Length;i++)
                triangular[i] = new int[triangular.Length-i];

            // * Visualizaci�n
		    Console.WriteLine("Tabla:");
            Mostrar(tabla);
		    Console.WriteLine("Matriz triangular:");
            Mostrar(triangular);
        }

        static void Mostrar(int[][] vector) {
                    foreach (int[] v in vector) {
                        foreach (int i in v)
                            Console.Write(i + " ");
                        Console.WriteLine();
                    }
                }
    }
}
