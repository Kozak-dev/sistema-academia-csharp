using SistemAcademia.Helpers;
using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SistemAcademia.Services
{
    internal class AvaliaçãoFisicaServices
    {
        
        List<AvaliaçãoFisica> avaliaçãoFisicas = new List<AvaliaçãoFisica>();
        private readonly AlunoServices _alunoServices;
        private readonly PersonalServices _personalServices;

        public AvaliaçãoFisicaServices(AlunoServices alunoServices, PersonalServices personalServices)
        {
            _alunoServices = alunoServices;
            _personalServices = personalServices;
            
        }

        public void CadastrarAvaliaçãoFisica()
        {
            _alunoServices.ListarAlunos();
            string cpfAluno = ConsoleHelpers.LerString("Digite o cpf do aluno: ");
            Aluno? aluno = _alunoServices?.ObterAlunoPorCpf(cpfAluno);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado!");
                return;
            }
            _personalServices.ListarPersonal();
            string cpfPersonal = ConsoleHelpers.LerString("Digite o cpf do personal");
            Personal? personal = _personalServices?.ObterPersonalPorCpf(cpfPersonal);
            if(personal == null)
            {
                Console.WriteLine("Personal não encontrado!");
                return;
            }
            
            double peso = ConsoleHelpers.LerDouble("Digite o peso");
            double altura = ConsoleHelpers.LerDouble("Digite a altura: ");
            double imc = CalcularIMC(peso, altura);
            double percentualDeGordura = ConsoleHelpers.LerDouble("Digite o percentual de gordura: ");
            string objetivo = ConsoleHelpers.LerString("Digite seu objetivo: ");
            DateOnly dataAvaliação = ConsoleHelpers.LerData("Digite a data da avaliação: ");
            string observações = ConsoleHelpers.LerString("Observações: ");

            AvaliaçãoFisica avaliaçãoFisica = new AvaliaçãoFisica(aluno, personal, peso, altura, imc, percentualDeGordura, objetivo, dataAvaliação, observações);
            avaliaçãoFisicas.Add(avaliaçãoFisica);
            Console.WriteLine("Cadastro realizado com sucesso!");
  
        }

        public void ListarAvaliação()
        {
           if(avaliaçãoFisicas.Count == 0)
            {
                Console.WriteLine("Lista vazia!");
                return;
            }
            foreach (var av in avaliaçãoFisicas)
            {
                av.MostrarAvaliação();
            }
        }
        public void BuscarAvaliaçãoFisica(string cpfAluno)
        {
            
            foreach(var av in avaliaçãoFisicas)
            {
                if(av.Aluno?.CPF == cpfAluno)
                {
                    av.MostrarAvaliação();
                    return;
                }
            }
            Console.WriteLine("Não encontrado!");
        }

        private double CalcularIMC(double peso, double altura)
        {
            return peso / (altura * altura);
        }

        public AvaliaçãoFisica? ObterAvaliacaoPorCpf(string cpfAluno)
        {
            foreach(var av in avaliaçãoFisicas)
            {
                if(av.Aluno?.CPF == cpfAluno)
                {
                    return av;
                }
            }
            return null;

        }

    }
}
