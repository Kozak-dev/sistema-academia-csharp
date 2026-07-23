using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SistemAcademia.Services
{
    internal class AlunoServices
    {
        List<Aluno> alunos = new List<Aluno>();

        public void CadastrarAluno(Aluno aluno)
        {
            foreach(var al in alunos)
            {
                if (al.CPF == aluno.CPF)
                {
                    Console.WriteLine("Cpf ja cadastrastrado!");
                    return;
                }
            }
            alunos.Add(aluno);
            Console.WriteLine("Aluno adicionado com sucesso!");
        }

        public void ListarAlunos()
        {
            if (alunos.Count > 0)
            {
                foreach (var al in alunos)
                {
                    al.MostrarDados();
                }
            }
            else
            {
                Console.WriteLine("Lista vazia!");
            }
        }
        public void BuscarAlunoPorCpf(string buscarAlunoCpf)
        {
            foreach(var al in alunos)
            {
                if (al.CPF == buscarAlunoCpf)
                {
                    al.MostrarDados();
                    return;
                }
            }
            Console.WriteLine("Aluno não encontrado!");
        }
        public void ExcluirAlunoPorCpf(string exluirAlunoCpf)
        {
            Aluno? alunoEncontrado = null;
            foreach (var al in alunos)
            {
                if(al.CPF == exluirAlunoCpf)
                {
                    alunoEncontrado = al;
                    break;
                }
            }
            if (alunoEncontrado !=  null)
            {
                alunos.Remove(alunoEncontrado);
                Console.WriteLine("Aluno removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado!");
            }
        }

        public Aluno? ObterAlunoPorCpf(string cpfAluno)
        {
            
            foreach (var al in alunos)
            {
                if(al.CPF == cpfAluno)
                {
                    return al;
                }
            }
            return null;
        }
    }
}
