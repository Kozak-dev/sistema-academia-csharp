using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Plano
    {
        public string? Nome { get; private set; }
        public decimal Valor { get; private set; }
        public List<string> Vantagens { get; private set; }
        public string? Tipo { get; private set; }

        public Plano(string nome, decimal valor, List<string> vantagens, string tipo)
        {
            Nome = nome;
            Valor = valor;
            Vantagens = vantagens;
            Tipo = tipo;
        }

        public void MostrarPlano()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Valor: {Valor}");
            foreach (var vantagem in Vantagens)
            {
                Console.WriteLine($"- {vantagem}");
            }
            Console.WriteLine($"Tipo: {Tipo}");
        }
    }
    
}
