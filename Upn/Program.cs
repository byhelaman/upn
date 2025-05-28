using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upn
{
    internal class Program
    {

        public static int frecuencia = 2500;
        public static double velocidadSonido = 334.8;

        public static int[] velocidadesMillas = {
            20, 40, 60, 80, 100, 120, 140, 160, 180, 200,
        };


        static void Main(string[] args)
        {
            Console.WriteLine($"{"V. Millas",10} {"Frecuencia",10} {"V. Km",7}");

            int n = velocidadesMillas.Length;
            double[] velocidadesKilometros = new double[n];

            for (int i = 0; i < n; i++)
            {
                velocidadesKilometros[i] = MillaAKilometro(velocidadesMillas[i]);

                if (MillaAKilometro(velocidadesMillas[i]) > 100)
                {
                    Console.WriteLine($"{velocidadesMillas[i],7} {Frecuencia(velocidadesMillas[i]),10:F2} {MillaAKilometro(velocidadesMillas[i]),10:F2} => Supera el límite de 100 km");
                }else
                {
                    Console.WriteLine($"{velocidadesMillas[i],7} {Frecuencia(velocidadesMillas[i]),10:F2} {MillaAKilometro(velocidadesMillas[i]),10:F2}");
                }


            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Velocidad Maxima: {VMaxima(velocidadesKilometros):F2} km");
            Console.WriteLine($"velocidad Minima: {VMinima(velocidadesKilometros):F2} km");

            Console.ReadLine();
        }

        public static double VMaxima(double[] arr)
        {
            double acc = arr[0];
            foreach (var valor in arr)
            {
                if (valor > acc)
                    acc = valor;
            }
            return acc;
        }

        public static double VMinima(double[] arr)
        {
            double acc = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < acc)
                    acc = arr[i];
            }
            return acc;
        }

        public static double Frecuencia(int velocidad)
        {
            return velocidad * frecuencia / velocidadSonido;
        }

        public static double MillaAKilometro(double millas)
        {
            return millas * 1.60934;
        }

    }
}
