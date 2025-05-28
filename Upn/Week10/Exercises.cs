using System;

namespace Upn.Week10
{
    internal class Exercises
    {
        public static int terms = 5;
        static void Main(string[] args)
        {
            // Imprime cabecera de la tabla
            Console.WriteLine($"{"X",3} {"Fcos",10} {"FExpo",10} {"Fcos%",11} {"FExpo%",11}");

            int n = 15; // Cantidad de valores de X a evaluar
            double sumFCos = 0, sumFExpo = 0;

            // 1. Calcular la suma total de las aproximaciones 
            // Esto es necesario para calcular los porcentajes en la 2do Paso 
            for (int i = 1; i <= n; i++)
            {
                sumFCos += FCos(i);
                sumFExpo += FExpo(i);
            }

            double maxFCos = double.MinValue, minFCos = double.MaxValue;
            double maxFExpo = double.MinValue, minFExpo = double.MaxValue;
            double maxPctFCos = double.MinValue, minPctFCos = double.MaxValue;
            double maxPctFExpo = double.MinValue, minPctFExpo = double.MaxValue;

            double sumPctFCos = 0, sumPctFExpo = 0;

            // 2. Calcular los valores individuales, sus porcentajes, e imprimir la tabla
            for (int i = 1; i <= n; i++)
            {
                double fcos = FCos(i); // Aproximación del coseno de X usando serie de Taylor
                double fexpo = FExpo(i); // Aproximación de e^X usando serie de Taylor

                double pctFCos = fcos / sumFCos * 100; // Porcentaje que representa fcos respecto al total
                double pctFExpo = fexpo / sumFExpo * 100;

                // Imprime la fila correspondiente para el valor actual de X
                Console.WriteLine($"{i,3} {fcos,10:F2} {fexpo,10:F2} {pctFCos,10:F2}% {pctFExpo,10:F2}%");

                // Actualiza valores máximos y mínimos
                maxFCos = Math.Max(maxFCos, fcos);
                minFCos = Math.Min(minFCos, fcos);
                maxFExpo = Math.Max(maxFExpo, fexpo);
                minFExpo = Math.Min(minFExpo, fexpo);

                maxPctFCos = Math.Max(maxPctFCos, pctFCos);
                minPctFCos = Math.Min(minPctFCos, pctFCos);
                maxPctFExpo = Math.Max(maxPctFExpo, pctFExpo);
                minPctFExpo = Math.Min(minPctFExpo, pctFExpo);

                // Acumula porcentajes para el cálculo del promedio
                sumPctFCos += pctFCos;
                sumPctFExpo += pctFExpo;
            }

            // Imprime un separador
            Console.WriteLine(new string('-', 50));

            // Muestra los valores máximos, mínimos, sumas y promedios
            Console.WriteLine($"{"++",3} {maxFCos,10:F2} {maxFExpo,10:F2} {maxPctFCos,10:F2}% {maxPctFExpo,10:F2}%");
            Console.WriteLine($"{"--",3} {minFCos,10:F2} {minFExpo,10:F2} {minPctFCos,10:F2}% {minPctFExpo,10:F2}%");
            Console.WriteLine($"{"SUM",3} {sumFCos,10:F2} {sumFExpo,10:F2} {sumPctFCos,10:F2}% {sumPctFExpo,10:F2}%");
            Console.WriteLine($"{"PRO",3} {sumFCos / n,10:F2} {sumFExpo / n,10:F2} {sumPctFCos / n,10:F2}% {sumPctFExpo / n,10:F2}%");

            Console.ReadLine();
            Console.WriteLine(Math.Cos(6));
        }

        // Calcula el factorial de un número (n!)
        public static int Factorial(int num)
        {
            if (num == 0) return 1;
            int result = 1;
            for (int i = 1; i <= num; i++)
                result *= i;
            return result;
        }

        // Aproxima cos(x) usando la serie de Taylor hasta 'terms' términos
        public static double FCos(double x)
        {
            double sum = 0;
            double sign = 1; // Alterna el signo de los términos (positivo/negativo)
            for (int i = 0; i < terms; i++)
            {
                int exponent = 2 * i; // Los exponentes en la serie de cos(x) son pares
                double term = Math.Pow(x, exponent) / Factorial(exponent);
                sum += sign * term;
                sign *= -1; // Cambia el signo del siguiente término
            }
            return sum;
        }

        // Aproxima e^x usando la serie de Taylor hasta 'terms' términos
        public static double FExpo(double x)
        {
            double sum = 0;
            for (int i = 0; i < terms; i++)
            {
                double term = Math.Pow(x, i) / Factorial(i);
                sum += term;
            }
            return sum;
        }

    }
}
