using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Pagamento
    {
        public Matricula Matricula { get; private set; }
        public decimal Valor { get; private set; }
        public DateOnly DataVencimento { get; private set; }
        public DateOnly DataPagamento { get; private set; }
        public string FormaPagamento { get; private set; }
        public string Status { get; private set; }

        public Pagamento(Matricula matricula, decimal valor, DateOnly dataVencimento, DateOnly dataPagamento,string formaPagamento, string status)
        {
            Matricula = matricula;
            Valor = valor;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            FormaPagamento = formaPagamento;
            Status = status;
        }

        public void MostrarPagamento()
        {
            Console.WriteLine($"Aluno:{Matricula.Aluno.CPF}");
            Console.WriteLine($"Valor: {Valor}");
            Console.WriteLine($"Data de vencimento: {DataVencimento}");
            Console.WriteLine($"Data de pagamento: {DataPagamento}");
            Console.WriteLine($"Forma de pagamento: {FormaPagamento}");
            Console.WriteLine($"Status: {Status}");
        }

    }
}
