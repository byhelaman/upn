using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upn.Week8
{
    internal class Exercises
    {
        /*
            Una empresa calcula el sueldo bruto de sus trabajadores multiplicando las horas trabajadas por
            una tarifa horaria que depende de la categoría del trabajador de acuerdo a la siguiente tabla:
        
            Categoría	| Tarifa horaria
                A	    | S/. 21.00
                B	    | S/. 19.50
                C	    | S/. 17.00
                D	    | S/. 15.50

            Por ley, todo trabajador se somete a un porcentaje de descuento del sueldo bruto: 20% si el
            sueldo bruto es mayor que S/. 2500 y 15% en caso contrario.
            Diseñe un algoritmo y programa en C# que determine el sueldo bruto, el descuento y el sueldo neto
            que le corresponden a un trabajador de la empresa.
         */

        public static void SueldoTrabajador()
        {
            string categoria;
            double horasTrabajo, sueldoBruto, sueldoNeto, descuento, tarifa = 0;

            // Solicitar categoría
            do
            {
                Console.WriteLine("Ingrese su categoría: [A - D]");
                categoria = Console.ReadLine().ToLower();
            }
            while (categoria != "a" && categoria != "b" && categoria != "c" && categoria != "d");

            // Solicitar horas trabajadas
            do
            {
                Console.WriteLine("Ingrese las horas trabajadas: ");
            } while (!double.TryParse(Console.ReadLine(), out horasTrabajo) || horasTrabajo <= 0);

            // Asignar tarifa y calcular sueldo bruto
            switch (categoria)
            {
                case "a": tarifa = 21.0; break;
                case "b": tarifa = 19.5; break;
                case "c": tarifa = 17.0; break;
                case "d": tarifa = 15.5; break;
            }

            sueldoBruto = horasTrabajo * tarifa;
            descuento = sueldoBruto > 2500 ? 0.20 : 0.15;
            sueldoNeto = sueldoBruto - (sueldoBruto * descuento);

            // Mostrar resultados
            void MostrarResumen()
            {
                Console.WriteLine("\n-------- RESUMEN --------");
                Console.WriteLine($"Categoría: {categoria.ToUpper()}");
                Console.WriteLine($"Horas Trabajadas: {horasTrabajo}");
                Console.WriteLine($"Tarifa por Hora: {tarifa:C2}");
                Console.WriteLine($"Sueldo Bruto: {sueldoBruto:C2}");
                Console.WriteLine($"Descuento ({descuento:P0}): {sueldoBruto * descuento:C2}");
                Console.WriteLine($"Sueldo Neto: {sueldoNeto:C2}");
            }

            MostrarResumen();

        }

    }
}
