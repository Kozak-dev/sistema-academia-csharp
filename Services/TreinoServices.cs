using SistemAcademia.Helpers;
using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SistemAcademia.Services
{
    internal class TreinoServices
    {
        List<Treino> treinos = new List<Treino>();
        private ExercicioServices exercicioServices;
        public TreinoServices(ExercicioServices exercicioServices)
        {
            this.exercicioServices = exercicioServices;

        }

        public void CadastrarTreino()
        {
            string? nomeTreino = ConsoleHelpers.LerString("Digite o nome do treino: ");
            Treino treino = new Treino(nomeTreino);

            while (true) {
                string nomeExercicio = ConsoleHelpers.LerString("Digite o nome do exercicio: ");
                Exercicio? exercicio = exercicioServices.ObterExercicioPorNome(nomeExercicio);

                if (exercicio == null)
                {
                    Console.WriteLine("Exercicio não encontrado");

                }
                else
                {

                    int serie = ConsoleHelpers.LerInt("Digite a quantidade de series: ");
                    int repetição = ConsoleHelpers.LerInt("Digite a quantidade de repeticoes: ");
                    string descanso = ConsoleHelpers.LerString("Digite o tempo de descanso: ");
                    string observação = ConsoleHelpers.LerString("Digite as observaçoes: ");

                    ItemTreino itens = new ItemTreino(exercicio, serie, repetição, descanso, observação);
                    treino.Itens.Add(itens);

                    string? opção = ConsoleHelpers.LerString("Deseja continuar adicionando exercicio? [S]/[N]");
                    if (opção == "S" || opção == "s")
                    {
                        continue;
                    }
                    else if (opção == "N" || opção == "n")
                    {
                        treinos.Add(treino);
                        Console.WriteLine("Treino criado com sucesso!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida!");
                        break;
                    }
                }
            }
        }

        public void ListarTreino()
        {
            if(treinos.Count == 0)
            {
                Console.WriteLine("Lista de trreino vazia!");
            }
            else
            {
                foreach(Treino tr in treinos)
                {
                    tr.MostrarNomeTreino();

                    foreach (ItemTreino item in tr.Itens)
                    {
                        item.MostrarItensTreino();
                        Console.WriteLine("------------------------------------------------------");
                    }
                }

            }
            
        }

    }
}

