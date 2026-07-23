using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SistemAcademia.Models
{
    internal class AvaliaçãoFisica
    {
        public Aluno? Aluno { get; private set; }
        public Personal Personal { get; private set; }
        public double Peso { get; private set; }
        public double Altura { get; private set; }
        public double IMC { get; private set; }
        public double PercentualDeGordura { get; private set; }
        public string? Objetivo { get; private set; }
        public DateOnly DataDeAvaliação { get; private set; }
        public string? Observações { get; private set; }

        public AvaliaçãoFisica(Aluno aluno, Personal personal, double peso, double altura, double imc, double percentualDeGordura, string objetivo, DateOnly dataDeAvaliação, string observação)
        {
            Aluno = aluno;
            Personal = personal;
            Peso = peso;
            Altura = altura;
            IMC = imc;
            PercentualDeGordura = percentualDeGordura;
            Objetivo = objetivo;
            DataDeAvaliação = dataDeAvaliação;
            Observações = observação;
        }

        public void MostrarAvaliação()
        {
            Console.WriteLine("----------------------- Avaliação Fisica -----------------------");
            Console.WriteLine($"|   Nome do aluno: {Aluno?.Nome}");
            Console.WriteLine($"|   Nome do responsavel: {Personal.Nome}");
            Console.WriteLine($"|   Peso: {Peso}");
            Console.WriteLine($"|   Altura: {Altura}");
            Console.WriteLine($"|   IMC: {IMC}");
            Console.WriteLine($"|   Percentual de gordura: {PercentualDeGordura}");
            Console.WriteLine($"|   Objetivo: {Objetivo}");
            Console.WriteLine($"|   Data de avaliação: {DataDeAvaliação}");
            Console.WriteLine($"|   Observações: {Observações}");
            Console.WriteLine($"----------------------------------------------------------------");
        }


    }


}
