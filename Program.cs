using System.ComponentModel;
using System.ComponentModel.Design;
using SistemAcademia.Helpers;
using SistemAcademia.Models;
using SistemAcademia.Services;

namespace SistemAcademia;

public class Program
{
    
    public static void Main()
    {
        AlunoServices alunoService = new AlunoServices();
        ExercicioServices exercicioService = new ExercicioServices();
        TreinoServices treinoService = new TreinoServices(exercicioService);
        while (true)
        {
            Console.WriteLine("----------------MENU DA ACADEMIA------------------");
            Console.WriteLine("1. Cadastrar Aluno");
            Console.WriteLine("2. Listar Aluno");
            Console.WriteLine("3. Buscar aluno por cpf");
            Console.WriteLine("4. Exluir aluno por cpf");
            Console.WriteLine("5. Cadastrar exercicio");
            Console.WriteLine("6. Listar exercicios");
            Console.WriteLine("7. Buscar exercicio por nome");
            Console.WriteLine("8. Excluir exercicio");
            Console.WriteLine("9. Criar Treino");
            Console.WriteLine("10. Listar treino");
            int opcao = ConsoleHelpers.LerInt("Opção: ");

            switch (opcao)
            {
                case 1:


                    string? nomeAluno = ConsoleHelpers.LerString("Nome do aluno: ");
                    string? cpfAluno = ConsoleHelpers.LerString("CPF do aluno: ");
                    string? emailAluno = ConsoleHelpers.LerString("Email: ");
                    DateOnly dataNascimento = ConsoleHelpers.LerData("Data de nascimento do aluno: ");
                    string? telefoneAluno = ConsoleHelpers.LerString("Telefone: ");

                    Aluno aluno = new Aluno(nomeAluno, cpfAluno, emailAluno, dataNascimento, telefoneAluno);
                    alunoService.CadastrarAluno(aluno);

                    break;

                case 2:
                    Console.WriteLine("--------Lista de Alunos---------");
                    alunoService.ListarAlunos();

                    break;

                case 3:
                    string? buscarAlunoCpf = ConsoleHelpers.LerString("Digite o CPF do aluno: ");
                    alunoService.BuscarAlunoPorCpf(buscarAlunoCpf);
                    break;

                case 4:
                    string? excluirAlunoCpf = ConsoleHelpers.LerString("Digite o CPF do aluno que deseja exluir: ");
                    alunoService.ExluirAlunoPorCpf(excluirAlunoCpf);

                    break;

                case 5:
                    string? nomeExercicio = ConsoleHelpers.LerString("Digite o nome do exercicio: ");
                    string? grupoMuscular = ConsoleHelpers.LerString("Digite o grupo muscular: ");
                    string? descrição = ConsoleHelpers.LerString("Digite uma descrição sobre o exercicio: ");
                    Exercicio exercicio = new Exercicio(nomeExercicio, grupoMuscular, descrição);

                    exercicioService.CadastrarExercicio(exercicio);

                    break;

                case 6:
                    Console.WriteLine("----------LISTA DE EXERCICIOS-----------");
                    exercicioService.ListarExercicios();
                    break;

                case 7:
                    string? buscarNomeExercicio = ConsoleHelpers.LerString("Digite o nome do exercicio que deseja buscar: ");
                    exercicioService.BuscarExercicioPorNome(buscarNomeExercicio);
                    break;

                case 8:
                    string? excluirExercicio = ConsoleHelpers.LerString("Digite o nome do exercicio que deseja exluir");
                    exercicioService.ExcluirExercicio(excluirExercicio);
                    break;

                case 9:
                    treinoService.CadastrarTreino();
                    break;

                case 10:
                    treinoService.ListarTreino();
                    break;
            }

        }
    }
}
