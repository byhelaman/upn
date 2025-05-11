using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upn.Week7
{
    internal class Exercises
    {
        /*
            Escriba un programa para controlar las preferencias de 20 electores en una votación con respuestas SI, NO,
            BLANCO y NULO, y generar la siguiente salida de datos:
            Además, se pide generar una gráfica horizontal considerando la cantidad de votos por cada valor con sus
            respectivos porcentajes.

            La frecuencia absoluta simple define el número de veces, que un valor aparece dentro de un intervalo o
            como respuesta. La frecuencia acumulada es ir sumando por cada intervalo o grupo de respuestas, las
            frecuencias absolutas simples. La frecuencia relativa simple es un porcentaje obtenido de establecer la
            relación entre la frecuencia absoluta simple y el total o tamaño de la muestra (en nuestro caso 20). La
            frecuencia relativa acumulada es ir sumando los porcentajes por cada intervalo o grupo de respuestas.
         */

        static void MenuVotacion()
        {
            Console.WriteLine("----- MENÚ DE OPCIONES -----");
            Console.WriteLine("-> 1. Sí");
            Console.WriteLine("-> 2. No");
            Console.WriteLine("-> 3. Voto en blanco");
            Console.WriteLine("-> 4. Voto nulo");
            Console.WriteLine("----------------------------");
        }

        public static void Votacion()
        {
            string continuar = "";
            int voto, contador = 0;
            int op_si = 0, op_no = 0, op_blanco = 0, op_nulo = 0;

            do
            {
                contador++;
                MenuVotacion();

                do
                {
                    Console.Clear();
                    MenuVotacion();

                    Console.WriteLine("Elector: " + contador);
                    Console.Write("Ingrese su voto (1-4): ");

                    string entrada = Console.ReadLine();

                    if (!int.TryParse(entrada, out voto) || voto < 1 || voto > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Debe ingresar un opcion valida");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                switch (voto)
                {
                    case 1: op_si++; break;
                    case 2: op_no++; break;
                    case 3: op_blanco++; break;
                    case 4: op_nulo++; break;
                }

            } while (contador < 20); // Continuar hasta que se registren 20 votos

            // Cálculo de frecuencias acumuladas
            int faa_si = op_si;
            int faa_no = faa_si + op_no;
            int faa_blanco = faa_no + op_blanco;
            int faa_nulo = faa_blanco + op_nulo;

            // Cálculo de frecuencias relativas simples
            double frs_si = (double)op_si / 20 * 100;
            double frs_no = (double)op_no / 20 * 100;
            double frs_blanco = (double)op_blanco / 20 * 100;
            double frs_nulo = (double)op_nulo / 20 * 100;

            // Cálculo de frecuencias relativas acumuladas
            double fra_si = frs_si;
            double fra_no = fra_si + frs_no;
            double fra_blanco = fra_no + frs_blanco;
            double fra_nulo = fra_blanco + frs_nulo;

            // Mostrar la tabla de frecuencias
            Console.WriteLine();
            Console.WriteLine("----- TABLA DE FRECUENCIAS -----");
            Console.WriteLine($"{"Valor",-10} {"Frec. Abs. Simple",-20} {"Frec. Abs. Acum.",-20} {"Frec. Rel. Simple",-20} {"Frec. Rel. Acum.",-20}");

            Console.WriteLine($"{"Si",-10} {op_si,17:F2} {faa_si,19:F2} {frs_si,20:F2}% {fra_si,18:F2}%");
            Console.WriteLine($"{"No",-10} {op_no,17:F2} {faa_no,19:F2} {frs_no,20:F2}% {fra_no,18:F2}%");
            Console.WriteLine($"{"Blanco",-10} {op_blanco,17:F2} {faa_blanco,19:F2} {frs_blanco,20:F2}% {fra_blanco,18:F2}%");
            Console.WriteLine($"{"Nulo",-10} {op_nulo,17:F2} {faa_nulo,19:F2} {frs_nulo,20:F2}% {fra_nulo,18:F2}%");
            Console.WriteLine($"{"Total",-10} {contador,17:F2}");

            // Mostrar la gráfica horizontal
            Console.WriteLine();
            Console.WriteLine("------ GRAFICA HORIZONTAL ------");

            //Console.Write($"{"Si",-10}");
            //for (int i = 0; i < op_si * 3; i++)
            //{
            //    Console.Write("█");
            //}
            //Console.WriteLine($" {fra_si}%");

            Console.WriteLine($"{"Si",-10} {new string('█', op_si * 3)} {frs_si}%");
            Console.WriteLine($"{"No",-10} {new string('█', op_no * 3)} {frs_no}%");
            Console.WriteLine($"{"Blanco",-10} {new string('█', op_blanco * 3)} {frs_blanco}%");
            Console.WriteLine($"{"Nulo",-10} {new string('█', op_nulo * 3)} {frs_nulo}%");

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();


        }

        /*
            En un condominio de 20 casas, se desea saber el pago mensual por consumo de agua, basado en el siguiente
            reporte:
            Consideraciones a tomar en cuenta para los cálculos:

            Metros cúbicos es la diferencia entre la lectura actual y la lectura anterior.

            El Importe de agua se considera según el tarifario del reporte, es decir para los primeros 20 metros
            cúbicos se cobra la tarifa de 1.499 soles, para los siguientes 30 metros cúbicos, la tarifa de 2.128
            soles y los restantes, es decir más de 50, la tarifa de 5.438 soles.

            El Importe de Alcantarillado se considera según el tarifario del reporte, es decir para los primeros
            20 metros cúbicos se cobra la tarifa de 0.935 soles, para los siguientes 30 metros cúbicos, la tarifa
            de 1.309 soles y los restantes, es decir más de 50, la tarifa de 2.592 soles.

            Para el Cargo Fijo se considera 5.04 soles por 25 metros cúbicos de consumo de agua.

            El IGV es el 18% de la suma de Importe de Agua, Importe de Alcantarillado y Cargo Fijo.
            Total Pago es la suma de Importe de Agua, Importe de Alcantarillado, Cargo Fijo e IGV.
            Además, hallar los totales según el reporte indicado

         */

        public static void MenuAgua()
        {
            Console.WriteLine("----- CONSUMO DE AGUA -----");
        }

        public static void ConsumoAgua()
        {
            int num = 20;

            double[] lecturaAnterior = new double[] {
                217, 189, 832, 243, 542, 150, 988, 677, 747, 326, 451, 900, 467, 792, 910, 223, 932, 153, 619, 866
            };
            double[] lecturaActual = new double[] {
                225, 259, 869, 273, 598, 176, 1035, 744, 800, 343, 478, 961, 488, 804, 949, 275, 999, 176, 682, 910
            };

            //double[] lecturaAnterior = new double[num];
            //double[] lecturaActual = new double[num];
            double[] metrosCubicos = new double[num];
            double[] importeAgua = new double[num];
            double[] importeAlcantarillado = new double[num];
            double[] cargoFijo = new double[num];
            double[] igv = new double[num];
            double[] totalPago = new double[num];

            double totalMetrosCubicos = 0, totalImporteAgua = 0, totalImporteAlcantarillado = 0, totalCargoFijo = 0, totalIGV = 0, totalPagoGeneral = 0;


            for (int i = 0; i < num; i++)
            {
                //do
                //{
                //    Console.Clear();
                //    MenuAgua();

                //    Console.WriteLine($"Casa: {i + 1}");
                //    Console.Write("Lectura Anterior: ");
                //    string entrada = Console.ReadLine();

                //    if (!double.TryParse(entrada, out lecturaAnterior[i]))
                //    {
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        Console.WriteLine("Error: Debe ingresar un numero valido");
                //        Console.ResetColor();
                //        Console.ReadKey();
                //    }
                //    else
                //    {
                //        break;
                //    }

                //} while (true);

                //do
                //{
                //    Console.Clear();
                //    MenuAgua();

                //    Console.WriteLine($"Casa: {i + 1}");
                //    Console.WriteLine($"Lectura Anterior: {lecturaAnterior[i]}");
                //    Console.Write("Lectura Actual: ");
                //    string entrada = Console.ReadLine();

                //    if (!double.TryParse(entrada, out lecturaActual[i]) || lecturaActual[i] < lecturaAnterior[i])
                //    {
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        Console.WriteLine("Error: Debe ingresar un numero valido");
                //        Console.ResetColor();
                //        Console.ReadKey();
                //    }
                //    else
                //    {
                //        break;
                //    }

                //} while (true);

                // Cálculo de metros cúbicos
                metrosCubicos[i] = lecturaActual[i] - lecturaAnterior[i];

                // Cálculo de importe de agua
                if (metrosCubicos[i] <= 20)
                {
                    importeAgua[i] = metrosCubicos[i] * 1.499;
                }
                else if (metrosCubicos[i] <= 50)
                {
                    importeAgua[i] = (20 * 1.499) + ((metrosCubicos[i] - 20) * 2.128);
                }
                else
                {
                    importeAgua[i] = (20 * 1.499) + (30 * 2.128) + ((metrosCubicos[i] - 50) * 5.438);
                }

                // Cálculo de importe de alcantarillado
                if (metrosCubicos[i] <= 20)
                {
                    importeAlcantarillado[i] = metrosCubicos[i] * 0.935;
                }
                else if (metrosCubicos[i] <= 50)
                {
                    importeAlcantarillado[i] = (20 * 0.935) + ((metrosCubicos[i] - 20) * 1.309);
                }
                else
                {
                    importeAlcantarillado[i] = (20 * 0.935) + (30 * 1.309) + ((metrosCubicos[i] - 50) * 2.592);
                }

                // Calculo de cargo fijo
                cargoFijo[i] = 5.04 * (metrosCubicos[i] / 25);

                // Cálculo de IGV
                igv[i] = (importeAgua[i] + importeAlcantarillado[i] + cargoFijo[i]) * 0.18;

                // Cálculo de total a pagar
                totalPago[i] = importeAgua[i] + importeAlcantarillado[i] + cargoFijo[i] + igv[i];

                // Calculo de totales
                totalMetrosCubicos += metrosCubicos[i];
                totalImporteAgua += importeAgua[i];
                totalImporteAlcantarillado += importeAlcantarillado[i];
                totalCargoFijo += cargoFijo[i];
                totalIGV += igv[i];
                totalPagoGeneral += totalPago[i];
            }

            // Mostrar el reporte
            Console.WriteLine();
            Console.WriteLine("----- REPORTE DE CONSUMO DE AGUA -----");
            Console.WriteLine();
            Console.WriteLine($"{"Casa",-8} {"L. Anterior",-12} {"L. Actual",-12} {"M. Cubicos",-12} {"Imp. Agua",-12} {"Imp. Alc.",-12} {"Cargo Fijo",-12} {"IGV (18%)",-12} {"Total Pago",10}");
            Console.WriteLine(new string('-', 116));

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"{i + 1,-8} {lecturaAnterior[i],-12} {lecturaActual[i],-12} {metrosCubicos[i],-12} {importeAgua[i],-12:C2} {importeAlcantarillado[i],-12:C2} {cargoFijo[i],-12:C2} {igv[i],-12:C2} {totalPago[i],-10:C2}");
            }

            Console.WriteLine(new string('-', 116));
            Console.WriteLine($"{"Total",-34} {totalMetrosCubicos,-12} {totalImporteAgua,-12:C2} {totalImporteAlcantarillado,-12:C2} {totalCargoFijo,-12:C2} {totalIGV,-12:C2} {totalPagoGeneral,-10:C2}");

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para salir");
            Console.ReadKey();

        }
    }
}
