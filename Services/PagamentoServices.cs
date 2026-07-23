using SistemAcademia.Helpers;
using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace SistemAcademia.Services
{
    internal class PagamentoServices
    {
        private readonly MatriculaServices _matriculaServices;
        List<Pagamento> pagamentos = new List<Pagamento>();

        public PagamentoServices(MatriculaServices matriculaServices) 
        { 
            _matriculaServices = matriculaServices;
        }

        public void GerarPagamento()
        {
            _matriculaServices.ListarMatricula();
            string matriculaCpf = ConsoleHelpers.LerString("Digite o cpf do aluno: ");
            Matricula? matriculaAlunoCpf = _matriculaServices.ObterMatriculaPorCpf(matriculaCpf);

            if (matriculaAlunoCpf == null )
            {
                Console.WriteLine("Matricula aluno não encontrado!");
                return;
            }

            decimal valor = matriculaAlunoCpf.ValorContratado;
            DateOnly dataVencimento = matriculaAlunoCpf.DataVencimento;
            DateOnly dataPagamento = DateOnly.FromDateTime(DateTime.Now);
            string formaPagamento = ConsoleHelpers.LerString("Digite a forma de pagamento [PIX]/[CARTÃO]/[BOLETO]: ");
            string status = "Pago";

            Pagamento pagamento = new Pagamento(matriculaAlunoCpf,valor, dataVencimento, dataPagamento, formaPagamento, status );
            pagamentos.Add( pagamento );
            Console.WriteLine("Pagamento realizado com sucesso!");
    
        }

        public void ListarPagamento()
        {
            if(pagamentos.Count == 0)
            {
                Console.WriteLine("Lista de pagamento vazia.");
                return;
            }
            foreach(var pm in pagamentos)
            {
                pm.MostrarPagamento();
                Console.WriteLine("-------------------------");
            }
        }

        public void BuscarPagamento(string cpfAlunoPagamento)
        {
            foreach(var pm in pagamentos)
            {
                if(pm.Matricula.Aluno.CPF == cpfAlunoPagamento)
                {
                    pm.MostrarPagamento();
                    return;
                }
            }
            Console.WriteLine("Pagamento não encontrado.");
        }

        public Pagamento? ObterPagamento(string cpfAluno)
        {
            foreach (var pm in pagamentos)
            {
                if(pm.Matricula.Aluno.CPF == cpfAluno)
                {
                    return pm;
                }
            }
            return null;

        }
        

        
    }

}

