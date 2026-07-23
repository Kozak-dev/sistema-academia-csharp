using SistemAcademia.Helpers;
using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Services
{
    internal class RelatorioServices
    {
        private readonly AlunoServices _alunoServices;
        private readonly MatriculaServices _matriculaServices;
        private readonly PagamentoServices _pagamentoServices;
        private readonly PresencaServices _presencaServices;

        public RelatorioServices(AlunoServices alunoServices, MatriculaServices matriculaServices, PagamentoServices pagamentoServices, PresencaServices presencaServices)
        {
            _alunoServices = alunoServices;
            _matriculaServices = matriculaServices;
            _pagamentoServices = pagamentoServices;
            _presencaServices = presencaServices;
        }

        public void ListarMatriculasAtivas()
        {
            bool encontrou = false;
            var matriculas = _matriculaServices.ObterMatriculas();

            if (matriculas.Count == 0)
            {
                Console.WriteLine("Lista de matriculas vazia.");
                return;
            }
            foreach (var matricula in matriculas)
            {
                if (matricula.Situação == "Ativa")
                {
                    encontrou = true;
                    matricula.MostrarResumo();
                }
            }
            if (!encontrou)
            {
                Console.WriteLine("Nenhuma matrícula ativa encontrada.");
            }
        }

        public void RelatorioFrequencia()
        {
            int totalPresenca = 0;
            string cpfAluno = ConsoleHelpers.LerString("Digite o cpf do aluno");
            var presencas = _presencaServices.ObterPresenca();

            foreach (var presenca in presencas)
            {
                if (presenca.Aluno.CPF == cpfAluno)
                {
                    presenca.MostrarPresenca();
                    Console.WriteLine("-----------------------\n");
                    totalPresenca++;
                }
            }
            if (totalPresenca == 0)
            {
                Console.WriteLine("Este aluno não tem nenhuma presença.");
            }
            else
            {
                Console.WriteLine($"Total presença: {totalPresenca}");
            }


        }

        public void AlunosPresentes()
        {
            int totalPresente = 0;
            var presencas = _presencaServices.ObterPresenca();

            foreach (var presenca in presencas)
            {
                if (presenca.HoraSaida == null)
                {

                    presenca.MostrarPresenca();
                    totalPresente++;
                }
            }
            if (totalPresente == 0)
            {
                Console.WriteLine("Nenhum aluno presente.");

            }
            else
            {
                Console.WriteLine($"Total Presentes: {totalPresente}");
            }




        }

        public void RelatorioPresencasDoDia()
        {
            int alunosDia = 0;
            var presencas = _presencaServices.ObterPresenca();

            foreach (var presenca in presencas)
            {
                if(presenca.Data == DateOnly.FromDateTime(DateTime.Now))
                {
                    presenca.MostrarPresenca();
                    alunosDia++;
                }
            }

            if (alunosDia == 0)
            {
                Console.WriteLine("Nenhum aluno presente no dia de hoje.");
            }

            else {
                Console.WriteLine($"Total alunos de hoje: {alunosDia}");
            }
        }

      

    }
}
