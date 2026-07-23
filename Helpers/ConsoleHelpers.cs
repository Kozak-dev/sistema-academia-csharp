using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace SistemAcademia.Helpers
{
    internal class ConsoleHelpers
    {

        public static string LerString(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                string? texto = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(texto))
                    return texto;

                Console.WriteLine("Valor inválido.");
            }
        }

        public static int LerInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                string? texto = Console.ReadLine();

                if (int.TryParse(texto, out int numero))
                {
                    return numero;
                }

                Console.WriteLine("Digite um número válido.");
            }
        }

        public static DateOnly LerData(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                string? texto = Console.ReadLine();

                if (DateOnly.TryParse(texto, out DateOnly data))
                {
                    return data;
                }

                Console.WriteLine("Digite um número válido.");
            }
        }
        public static Decimal LerDecimal(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                string? texto = Console.ReadLine();

                if (Decimal.TryParse(texto, out  Decimal valor))
                {
                    return valor;
                }

                Console.WriteLine("Digite um número válido.");
            }
        }

        public static double LerDouble(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                string? texto = Console.ReadLine();

                if (double.TryParse(texto, out double valor))
                {
                    return valor;
                }

                Console.WriteLine("Digite um número válido.");
            }
        }

        private double CalcularIMC(double peso, double altura)
        {
            return peso / (altura * altura);
        }



    }
}

