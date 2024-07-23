
namespace TPP.Seminarios.Concurrente.Seminario6 {

    class Program {
        static void Main(string[] args) {
            const int milisPensar = 50, milisComer = 400;
            Tenedor[] tenedor = new Tenedor[5];
            for (int i = 0; i < tenedor.Length; i++)
                tenedor[i] = new Tenedor(i);

            new Filosofo(0, milisPensar, milisComer, tenedor[0], tenedor[1]);
            new Filosofo(1, milisPensar, milisComer, tenedor[1], tenedor[2]);
            new Filosofo(2, milisPensar, milisComer, tenedor[2], tenedor[3]);
            new Filosofo(3, milisPensar, milisComer, tenedor[3], tenedor[4]);
            new Filosofo(4, milisPensar, milisComer, tenedor[4], tenedor[0]);
        }
    }
}
