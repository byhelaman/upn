using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upn.Week3
{
    internal class Exercises
    {
        public static void EX01_RD()
        {
            double donacion, medicinaGeneral, ginecologia, pediatria, traumatologia;

            Console.Write("Ingrese el monto de la donación: ");
            donacion = double.Parse(Console.ReadLine());

            medicinaGeneral = donacion * 0.50;
            ginecologia = donacion * 0.30;
            pediatria = medicinaGeneral * 0.03;
            traumatologia = donacion - (medicinaGeneral + ginecologia + pediatria);

            Console.WriteLine
            (
                $"-------------------------------------\n" +
                $"Distribución de la donación:\n" +
                $"-------------------------------------\n" +
                $"Medicina General: {medicinaGeneral:F2}\n" +
                $"Ginecología: {ginecologia:F2}\n" +
                $"Pediatría: {pediatria:F2}\n" +
                $"Traumatología: {traumatologia}\n" +
                $"-------------------------------------"
            );

        }

        public static void EX02_TP()
        {
            double velocidad;
            string tipoParticula;

            Console.Write("Ingrese la velocidad (m/s): ");
            velocidad = double.Parse(Console.ReadLine());

            if (velocidad >= 7 && velocidad < 10)
            {
                tipoParticula = "Humos metalúrgicos";
            }
            else if (velocidad >= 10 && velocidad < 13)
            {
                tipoParticula = "Muy finas y de muy baja densidad aparente";
            }
            else if (velocidad >= 13 && velocidad < 18)
            {
                tipoParticula = "Finas y secas de materiales de baja densidad";
            }
            else if (velocidad >= 18 && velocidad < 20)
            {
                tipoParticula = "Densidad media o baja, húmedas";
            }
            else if (velocidad >= 20 && velocidad <= 23)
            {
                tipoParticula = "Gruesas de alta densidad";
            }
            else if (velocidad > 23)
            {
                tipoParticula = "Muy alta densidad o húmedas";
            }
            else
            {
                tipoParticula = "Error: Velocidad fuera del rango válido.";
            }

            Console.WriteLine
            (
                $"-------------------------------------\n" +
                $"Tipo de partícula: {tipoParticula}\n" +
                $"-------------------------------------"
            );
        }

        public static void EX03_CC()
        {
            double ingresoMensual, costoCasa, cuotaInicial, resto, cuotaMensual;
            int numeroCuotas;

            Console.Write("Ingrese el ingreso mensual del comprador (S/): ");
            ingresoMensual = double.Parse(Console.ReadLine());

            Console.Write("Ingrese el costo total de la casa (S/): ");
            costoCasa = double.Parse(Console.ReadLine());

            if (ingresoMensual < 2250)
            {
                cuotaInicial = costoCasa * 0.15;
                numeroCuotas = 120;
            }
            else
            {
                cuotaInicial = costoCasa * 0.30;
                numeroCuotas = 75;
            }

            resto = costoCasa - cuotaInicial;
            cuotaMensual = resto / numeroCuotas;

            Console.WriteLine
            (
                "-----------------------------------------------\n" +
                $"Detalle de Financiamiento de Casa\n" +
                $"Ingreso mensual del comprador: {ingresoMensual:F2}\n" +
                $"Costo total de la casa: {costoCasa:F2}\n" +
                $"Cuota inicial a pagar: {cuotaInicial:F2}\n" +
                $"Número de cuotas mensuales: {numeroCuotas}\n" +
                $"Valor de cada cuota mensual:{cuotaMensual:F2}\n" +
                "-----------------------------------------------"
            );
        }
    }
}
