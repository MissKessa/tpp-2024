using System.Threading;

namespace TPP.Seminarios.Concurrente.Seminario6 {

    class Program {


        public static void Main() {
            Recurso recurso1 = new Recurso("Recurso 1"),
                    recurso2 = new Recurso("Recurso 2");
            Hilo hilo1 = new Hilo(recurso1, recurso2),
                 hilo2 = new Hilo(recurso2, recurso1);
            new Thread(hilo1.Ejecutar).Start();
            new Thread(hilo2.Ejecutar).Start();
        }

    }
}
