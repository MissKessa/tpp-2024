using System;
using System.Threading;

namespace TPP.Seminarios.Concurrente.Seminario6 {
    /// <summary>
    /// Representa un recurso a adquirir por un hilo
    /// </summary>
    public class Recurso {

        public string Nombre { get; private set; }

        public Recurso(string nombre) {
            this.Nombre = nombre;
        }

        public void Procesar() {
            Thread.Sleep(100); // simula procesamiento...
            Console.WriteLine(Nombre + " processing...");
        }

    }
}
