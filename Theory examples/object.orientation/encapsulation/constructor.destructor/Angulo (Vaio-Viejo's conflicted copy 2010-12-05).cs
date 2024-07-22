using System;

namespace ClasesObjetos {
    /// <summary>
    /// Ejemplo de clase que ofrece primitivas de �ngulos
    /// </summary>
    public class Angulo {

        /// <summary>
        /// Radianes del �ngulo
        /// </summary>
        private double Radianes;

        /// <summary>
        /// M�todo publico para devolver los radianes de un �ngulo
        /// </summary>
        public double GetRadianes() {
            return this.Radianes;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radianes">�ngulo en radianes</param>
        public Angulo(double radianes) {
            this.Radianes = radianes;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="grados">Grados sexasegimales</param>
        public Angulo(int grados) {
            Radianes = grados / 180.0 * Math.PI;
        }

        /// <summary>
        /// Prueba de un destructor
        /// </summary>
        ~Angulo() {
            Console.WriteLine("Ejecutando el destructor de un �ngulo de {0} radianes.", Radianes);
        }

        /// <summary>
        /// Calcula el seno de un �ngulo
        /// </summary>
        /// <returns>El seno del objeto impl�cito</returns>
        public double Seno() {
            return Math.Sin(Radianes);
        }

        /// <summary>
        /// Calcula el coseno de un �ngulo
        /// </summary>
        /// <returns>El coseno del �ngulo</returns>
        public double Coseno() {
            return Math.Cos(Radianes);
        }

        /// <summary>
        /// Calcula la tangente de un �ngulo
        /// </summary>
        /// <returns>La tangente del objeto impl�cito</returns>
        public double Tangente() {
            return Seno() / Coseno();
        }


        /// <summary>
        /// Prueba de la clase
        /// </summary>
        static void Main() {
            Angulo angulo1 = new Angulo(180), // * Grados
                    angulo2 = new Angulo(Math.PI); // * Radianes
            Console.WriteLine("Seno:     {0,6:F} {1,6:F}", angulo1.Seno(), angulo2.Seno());
            Console.WriteLine("Coseno:   {0,6:F} {1,6:F}", angulo1.Coseno(), angulo2.Coseno());
            Console.WriteLine("Tangente: {0,6:F} {1,6:F}", angulo1.Tangente(), angulo2.Tangente());
        }
    }
}
