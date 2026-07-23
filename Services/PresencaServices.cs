using SistemAcademia.Helpers;
using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SistemAcademia.Services
{
    internal class PresencaServices
    {
        List<Presenca> presencas = new List<Presenca>();
        private readonly AlunoServices _alunoServices;

        public PresencaServices(AlunoServices alunoServices)
        {
            _alunoServices = alunoServices;
        }

        public void RegistrarPresenca()
        {
            _alunoServices.ListarAlunos();
            string cpfAluno = ConsoleHelpers.LerString("Digite o cpf do aluno");
            Aluno? aluno = _alunoServices.ObterAlunoPorCpf(cpfAluno);

            if(aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            Presenca? presenca = ObterPresençaAberta(aluno);

            if(presenca == null)
            {
                Presenca novaPresenca = new Presenca(aluno);
                presencas.Add(novaPresenca);
                Console.WriteLine("Entrada registrada com sucesso.");
            }
            else
            {
                presenca.RegistrarSaida();
                Console.WriteLine("Saida registrada com sucesso.");
            }
           
        }

        public void ListarPresenca()
        {
            if(presencas.Count == 0)
            {
                Console.WriteLine("Lista Presença vazia.");
                return;
            }
            foreach(var presenca in presencas)
            {
                presenca.MostrarPresenca();
                Console.WriteLine("---------------------------------");
            }

        }

        public Presenca? ObterPresençaAberta(Aluno aluno)
        {
            foreach(var presenca in presencas)
            {
                if(presenca.Aluno.CPF == aluno.CPF && presenca.HoraSaida == null)
                {

                   return presenca;
                    
                }
            }
            return null;
        }

        public void BuscarPresencaPorCpf(string cpfAlunoPresenca)
        {
            bool encontrou = false;
            foreach(var presenca in presencas)
            {
                if(presenca.Aluno.CPF == cpfAlunoPresenca)
                {
                    encontrou = true;
                    presenca.MostrarPresenca();
                }
            }
            if(!encontrou)
            Console.WriteLine("Aluno não encontrado.");
        }

        public void ListarAlunosPresentes()
        {
            foreach(var presenca in presencas)
            {
                if(presenca.HoraSaida == null)
                {
                    presenca.MostrarPresenca();
                }
            }
        }

        public void ListarAlunosDoDia()
        {
            foreach(var presenca in presencas)
            {
                if (presenca.Data == DateOnly.FromDateTime(DateTime.Now)) 
                {
                    presenca.MostrarPresenca();
                }
            }
        }

        public List<Presenca> ObterPresenca()
        {
            return presencas;
        }
    }
}
