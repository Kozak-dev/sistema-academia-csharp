using SistemAcademia.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Matricula
    {
        public Aluno Aluno { get; private set; }
        public Plano Plano { get; private set; }
        public string Unidade { get; private set; }
        public string TipoDePagamento { get; private set; }
        public DateOnly DataInicio { get; private set; }
        public DateOnly DataVencimento { get; private set; }
        public Decimal ValorContratado { get; private set; }
        public string Situação { get; private set; }

        public Matricula(Aluno aluno , Plano plano, string unidade, string tipoDePagamento, DateOnly dataInicio, DateOnly dataVencimento, Decimal valorContratado, string situação)
        {
            this.Aluno = aluno;
            this.Plano = plano;
            Unidade = unidade;
            TipoDePagamento = tipoDePagamento;
            DataInicio = dataInicio;
            DataVencimento = dataVencimento;
            ValorContratado = valorContratado;
            Situação = situação;

        }

        public void MostrarMatricula()
        {
            Console.WriteLine("------------------------------Matricula Academia------------------------");
            Console.WriteLine($"Nome do aluno: {Aluno.Nome}\n");
            Console.WriteLine($"Nome: {Plano.Nome}");
            Console.WriteLine($"Vantagens: {Plano.Vantagens}");
            Console.WriteLine($"Tipo de pagamento: {Plano.Tipo}\n");
            Console.WriteLine($"Unidade: {Unidade}");
            Console.WriteLine($"Tipo de pagamento: {TipoDePagamento}");
            Console.WriteLine($"Data de inicio: {DataInicio}");
            Console.WriteLine($"Data de vencimento: {DataVencimento}");
            Console.WriteLine($"Valor contratado: {ValorContratado}");
            Console.WriteLine($"Situação: {Situação}");
        }

        public void Cancelar()
        {
            if (Situação == "Cancelada")
                return;

            Situação = "Cancelada";
        }

        public void MostrarResumo()
        {
            Console.WriteLine($"Nome: {Aluno.Nome}");
            Console.WriteLine($"Plano: {Plano.Nome}");
            Console.WriteLine($"unidade: {Unidade}");
            Console.WriteLine($"Vencimento: {DataVencimento}");
        }
    }
}
