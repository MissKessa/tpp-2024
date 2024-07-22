using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TPP.ObjectOrientation.DynamicTyping {

    class Program {

        static void Main() {
            //Expression[] expressions = new Expression[] { new IntegerExpression(3), new DoubleExpression(4.3), new BoolExpression(true) };
            //Operator[] operators = new Operator[] { new AdditionOperator(), new EqualToOperator(), new AndOperator() };
            //foreach (Operator op in operators)
            //    foreach (Expression op1 in expressions)
            //        foreach (Expression op2 in expressions) {
            //            Expression result = null;
            //            try {
            //                Multimethod.MultimethodEvaluate(op1, op, op2);
            //            } catch (ArgumentException) {
            //                // operation not supported (result == null)
            //            }
            //            Console.WriteLine("{0} {1} {2} = {3}", op1, op, op2, result);
            //        }
            //Q1();
            //Q2();
            //Q3();
            notPrint();

        }

        static void Q1()
        {
            IntegerExpression e1 = new IntegerExpression(1);
            IntegerExpression e2 = new IntegerExpression(1);
            AdditionOperator op = new AdditionOperator();

            Multimethod.MultimethodEvaluate(e1,op,e2);
        }
        static void Q2()
        {
            BoolExpression e1 = new BoolExpression(false);
            BoolExpression e2 = new BoolExpression(true);
            AdditionOperator op = new AdditionOperator();

            Multimethod.MultimethodEvaluate(e1, op, e2);
        }
        static void Q3()
        {
            Expression e1 = new IntegerExpression(1);
            Expression e2 = new IntegerExpression(1);
            Operator op = new AdditionOperator();

            Multimethod.MultimethodEvaluate(e1, op, e2);
        }

        static void notPrint()
        {
            // Definir el generador perezoso
            IEnumerable<int> GeneradorPerezoso()
            {
                //Console.WriteLine("Generador iniciado");
                yield return 1;
                //Console.WriteLine("Generador reanudado");
                yield return 2;
                //Console.WriteLine("Generador finalizado");
                yield return 3;
            }

            // Crear un iterador perezoso
            IEnumerable<int> IteradorPerezoso()
            {
                //Console.WriteLine("Iterador perezoso creado");
                yield return 4;
                yield return 5;
                yield return 6;
            }

            // Uso de Zip para combinar ambos sin iterar
            var gen = GeneradorPerezoso();
            var it = IteradorPerezoso();
            var combinado = gen.Zip(it, (g, i) => (g, i)).Take(3);
            Console.WriteLine(combinado.Take(0)); //empty

            // Intentar imprimir combinado
            Console.WriteLine(combinado);

            // Para ver realmente los elementos, tendríamos que iterar sobre la secuencia
            foreach (var item in combinado)
            {
                Console.WriteLine(item);
            }
        }
    }
}
