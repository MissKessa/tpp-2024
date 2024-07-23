using System;
using System.Threading;

namespace TPP.Seminarios.Concurrente.Seminario6 {

    class Filosofo {
        /// <summary>
        /// ID del filósofo
        /// </summary>
        private int numeroFilosofo;

        /// <summary>
        /// El tiempo que tarda pensando
        /// </summary>
        private int milisPensar;

        /// <summary>
        /// El tiempo que tarda comiendo
        /// </summary>
        private int milisComer;

        /// <summary>
        /// Los tenedores izquierdos y derechos
        /// </summary>
        private Tenedor tenedorIzquierdo, tenedorDerecho;

        public Filosofo(int numeroFilosofo, int milisPensar, int milisComer, Tenedor tenedorIzquierdo, Tenedor tenedorDerecho) {
            this.numeroFilosofo = numeroFilosofo;
            this.milisPensar = milisPensar; this.milisComer = milisComer;
            this.tenedorIzquierdo = tenedorIzquierdo;
            this.tenedorDerecho = tenedorDerecho;

            new Thread(new ThreadStart(ComerYPensar)).Start();
        }

        private void ComerYPensar() {
            for (;;) {
                lock (this.tenedorIzquierdo) {
                    lock (this.tenedorDerecho) {
                        Console.WriteLine("El filósofo " + numeroFilosofo + " está comiendo...");
                        Thread.Sleep(milisComer);
                    }
                }
                Console.WriteLine("El filósofo " + numeroFilosofo + " está pensando...");
                Thread.Sleep(milisPensar);
            }

        }
    }
}
