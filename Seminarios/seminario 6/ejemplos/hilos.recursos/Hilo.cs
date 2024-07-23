
namespace TPP.Seminarios.Concurrente.Seminario6 {

    /// <summary>
    /// Encapsula un hilo
    /// </summary>
    public class Hilo {

        public Recurso Recurso1 { get; private set; }
        public Recurso Recurso2 { get; private set; }


        public Hilo(Recurso recurso1, Recurso recurso2) {
            this.Recurso1 = recurso1;
            this.Recurso2 = recurso2;
        }

        /// <summary>
        /// Este método será llamado concurrentemente en la ejecución del hilo
        /// </summary>
        public void Ejecutar() {
            while (true) {
                lock (this.Recurso1) {
                    Recurso1.Procesar();
                    lock (this.Recurso2) {
                        Recurso2.Procesar();
                    }
                }
            }
        }


    }
}
