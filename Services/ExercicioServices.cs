using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Services
{
    internal class ExercicioServices
    {
        List<Exercicio> exercicios = new List<Exercicio>();

        public void CadastrarExercicio(Exercicio exercicio)
        {
            foreach (var ex in exercicios) 
            {
                if (ex.Nome == exercicio.Nome)
                {
                    Console.WriteLine("Exercicio ja cadastrado!");
                    return;
                }
            } 
            exercicios.Add(exercicio);
            Console.WriteLine("Exercico adicionado com sucesso!");
        }

        public void ListarExercicios()
        {
            
               if(exercicios.Count > 0)
                {
                    foreach (Exercicio ex in exercicios)
                    {
                        ex.MostrarExercicio();
                    }
                }
                else
                {
                    Console.WriteLine("Lista de exercicio vazia!");
                }
            
        }

        public void BuscarExercicioPorNome(string buscarNomeExercicio)
        {
            foreach (Exercicio ex in exercicios)
            {
                if(ex.Nome == buscarNomeExercicio)
                {
                    ex.MostrarExercicio();
                    return;
                }
            }
            Console.WriteLine("Exercicio não encontrado!");
        }

        public void ExcluirExercicio(string excluirExercicio)
        {
            Exercicio? exercicioAchado = null;

            foreach (Exercicio ex in exercicios) 
            {
                if(ex.Nome == excluirExercicio)
                {
                    exercicioAchado = ex;
                }
            }
            if (exercicioAchado != null)
            {
                exercicios.Remove(exercicioAchado);
                Console.WriteLine("Exercicio removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Exercicio não encontrado!");
            }

        }

        public Exercicio? ObterExercicioPorNome(string nome)
        {
            foreach(var ex in exercicios)
            {
                if(ex.Nome == nome)
                {
                    return ex;
                }
            }
            return null;
        }
    }
}
