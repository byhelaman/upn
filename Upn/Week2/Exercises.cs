using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upn.Week2
{
    internal class Exercises
    {
        public static void EX05_PE()
        {
            double costoFijo, costoMaterial, nroUnidades, precioUnitario, costoManoObra;
            double costoTotal, ingresoTotal, costoMaterialTotal, costoManoObraTotal, utilidades;
            string mensaje, rating;

            Console.WriteLine("Ingrese el Costo Fijo: ");
            costoFijo = Double.Parse(Console.ReadLine());

            //Console.WriteLine("Ingrese el Costo de Material: ");
            //costoMaterial = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Costo de Mano de Obra: ");
            costoManoObra = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Número de Unidades a producir: ");
            nroUnidades = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Precio Unitario de venta: ");
            precioUnitario = Double.Parse(Console.ReadLine());

            //costoMaterialTotal = costoMaterial * nroUnidades;
            costoManoObraTotal = costoManoObra * nroUnidades;

            ingresoTotal = nroUnidades * precioUnitario;
            //costoTotal = costoMaterialTotal + costoManoObraTotal + costoFijo;
            costoTotal = costoManoObraTotal + costoFijo;

            utilidades = ingresoTotal - costoTotal;

            if (utilidades > 0)
            {
                rating = "GANANCIA";
                mensaje = "La empresa es rentable";
            }
            else if (utilidades == 0)
            {
                rating = "PUNTO DE EQUILIBRIO";
                mensaje = "La empresa está en punto de equilibrio";
            }
            else
            {
                rating = "PERDIDA";
                mensaje = "La empresa no es rentable";
            }

            Console.WriteLine
            (
                $"-------------------------------------\n" +
                $"Unidades: {nroUnidades}\n" +
                $"Costo Fijo: {costoFijo}\n" +
                $"Costo Total Mano de Obra: {costoManoObraTotal}\n" +
                $"Costo Total: {costoTotal}\n" +
                $"Ingresos: {ingresoTotal}\n" +
                $"Utilidades: S/{utilidades}\n" +
                $"Calificación: {rating}\n" +
                $"{mensaje}\n" +
                $"-------------------------------------"
            );

        }

        public static void EX06_PE()
        {
            double costoFijo, costoVariable, nroUnidades;
            double costoTotal, ingresoTotal, utilidades;
            string mensaje, rating;

            Console.WriteLine("Ingrese el Costo Fijo: ");
            costoFijo = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Costo Variable: ");
            costoVariable = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el Número de Unidades a producir: ");
            nroUnidades = Double.Parse(Console.ReadLine());

            ingresoTotal = 100 * Math.Sqrt(nroUnidades);
            costoTotal = (costoVariable * nroUnidades) + costoFijo;

            utilidades = ingresoTotal - costoTotal;

            if (utilidades > 0)
            {
                rating = "GANANCIA";
                mensaje = "La empresa es rentable";
            }
            else if (utilidades == 0)
            {
                rating = "PUNTO DE EQUILIBRIO";
                mensaje = "La empresa está en punto de equilibrio";
            }
            else
            {
                rating = "PERDIDA";
                mensaje = "La empresa no es rentable";
            }

            Console.WriteLine
            (
                $"-------------------------------------\n" +
                $"Unidades: {nroUnidades}\n" +
                $"Costo Fijo: {costoFijo}\n" +
                $"Costo Variable Total: {costoVariable * nroUnidades}\n" +
                $"Costo Total: {costoTotal}\n" +
                $"Ingresos: {ingresoTotal}\n" +
                $"Utilidades: S/{utilidades}\n" +
                $"Calificación: {rating}\n" +
                $"{mensaje}\n" +
                $"-------------------------------------"
            );
        }

        public static void EX07_DL()
        {
            double costoInicial, depreciacion, valorFinal;
            int vidaUtil, nroMes;
            string mensaje, rating;

            Console.WriteLine("Ingresar el Costo del Producto: ");
            costoInicial = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingresar el Tiempo de Vida Util (meses): ");
            vidaUtil = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresar el mes a evaluar: ");
            nroMes = int.Parse(Console.ReadLine());

            valorFinal = costoInicial * Math.Pow(1 - 1.0 / vidaUtil, nroMes);
            depreciacion = costoInicial - valorFinal;


            if (depreciacion > 0 && depreciacion <= 500)
            {
                rating = "A";
                mensaje = "El producto sigue conservando un buen valor";
            }
            else if (depreciacion <= 750)
            {
                rating = "B";
                mensaje = "El producto ha perdido algo de valor, pero aún es valioso";
            }
            else
            {
                rating = "C";
                mensaje = "El producto ha perdido una gran parte de su valor";
            }

            Console.WriteLine
            (
                $"-------------------------------------\n" +
                $"Valor Final del Producto: {valorFinal:F2}\n" +
                $"Depreciación Acumulada: {depreciacion:F2}\n" +
                $"Calificación: {rating}\n" +
                $"{mensaje}\n" +
                $"-------------------------------------"
            );
        }
    }
}
