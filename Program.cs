using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using SistemAcademia.Helpers;
using SistemAcademia.Models;
using SistemAcademia.Services;

namespace SistemAcademia;

public class Program
{
    
    public static void Main()
    {
        AlunoServices alunoService = new AlunoServices();
        PersonalServices personalService = new PersonalServices();
        ExercicioServices exercicioService = new ExercicioServices();
        TreinoServices treinoService = new TreinoServices(exercicioService);
        PlanoServices planoService = new PlanoServices();
        MatriculaServices matriculaService = new MatriculaServices(alunoService, planoService);
        AvaliaçãoFisicaServices avaliaçãoFisicaServices = new AvaliaçãoFisicaServices(alunoService, personalService );
        PagamentoServices pagamentoSevice = new PagamentoServices(matriculaService);
        PresencaServices presencaService = new PresencaServices(alunoService);
        RelatorioServices relatorioService = new RelatorioServices(alunoService,matriculaService, pagamentoSevice, presencaService);
        

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
            Console.WriteLine("11. CadastrarPlano");
            Console.WriteLine("12. Listar plano");
            Console.WriteLine("13. Buscar plano por nome");
            Console.WriteLine("14. Excluir plano");
            Console.WriteLine("15. Cadastrar matricula");
            Console.WriteLine("16. Buscar Matricula");
            Console.WriteLine("17. Listar matricula");
            Console.WriteLine("18. Cancelar matricula: ");
            Console.WriteLine("19. Cadastrar avaliação fisica: ");
            Console.WriteLine("20. Listar avaliação fisica: ");
            Console.WriteLine("21. Buscar avaliação fisica: ");
            Console.WriteLine("22. Cadastrar personal ");
            Console.WriteLine("23. Listar personals ");
            Console.WriteLine("24. Achar personal por cpf ");
            Console.WriteLine("25. Excluir personal ");
            Console.WriteLine("26. Gerar pagamento ");
            Console.WriteLine("27. Listar pagamento ");
            Console.WriteLine("28. Buscar pagamento ");
            Console.WriteLine("29. Registrar Presença ");
            Console.WriteLine("30. Listar presença ");
            Console.WriteLine("31. Buscar presença ");
            Console.WriteLine("32. Listar alunos presentes ");
            Console.WriteLine("33. Listar alunos do dia ");
            Console.WriteLine("34. Relatorio de matriculas ativas ");
            Console.WriteLine("35. Relatorio de frequencia ");
            Console.WriteLine("36. Relatorio de alunos presentes ");
            Console.WriteLine("37. Relatorio de presenças do dia ");
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
                    alunoService.ExcluirAlunoPorCpf(excluirAlunoCpf);

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

                case 11:
                    planoService.CadastrarPlano();
                    break;

                case 12:
                    planoService.ListarPlano();
                    break;

                case 13:
                    string? buscarPlano = ConsoleHelpers.LerString("Digite o nome do plano que deseja ver: ");
                    planoService.BuscarPlanoPorNome(buscarPlano);
                    break;

                case 14:
                    string? excluirPlano = ConsoleHelpers.LerString("Digite o nome do plano que deseja excluir: ");
                    planoService.ExcluirPlano(excluirPlano);
                    break;

                case 15:
                    matriculaService.CadastrarMatricula();
                    break;

                case 16:
                    string buscarMatriculaPorCpf = ConsoleHelpers.LerString("Digite o cpf do aluno para ver a matricula: ");
                    matriculaService.BuscarMatricula(buscarMatriculaPorCpf);
                    break;

                case 17:
                    matriculaService.ListarMatricula();
                    break;

                case 18:
                    string cancelarMatricula = ConsoleHelpers.LerString("Digite o cpf do aluno, para cancelar a matricula");
                    matriculaService.CancelarMatricula(cancelarMatricula);
                    break;

                case 19:
                    avaliaçãoFisicaServices.CadastrarAvaliaçãoFisica();
                    break;

                case 20:
                    avaliaçãoFisicaServices.ListarAvaliação();
                    break;

                case 21:
                    string obterAlunoPorCpf = ConsoleHelpers.LerString("Digite o cpf do aluno: ");
                    break;

                case 22:

                    string nomePersonal = ConsoleHelpers.LerString("Digite o nome do personal: ");
                    string cpfPersonal = ConsoleHelpers.LerString("Digite o cpf do personal: ");
                    DateOnly dataDeNascimento = ConsoleHelpers.LerData("Digite a data de nascimento: ");
                    string cref = ConsoleHelpers.LerString("Digite o cref do personal: ");
                    string especialidade = ConsoleHelpers.LerString("Digite o especialidade do personal: ");
                    string telefone = ConsoleHelpers.LerString("Digite o telefone do personal: ");
                    string email = ConsoleHelpers.LerString("Digite o email do personal: ");
                    DateOnly dataDeContratação = ConsoleHelpers.LerData("Digite o email do personal: ");

                    Personal personal = new Personal(nomePersonal, cpfPersonal, cref, especialidade, dataDeNascimento, telefone, email, dataDeContratação);
                    personalService.CadastrarPersonal(personal);
                    break;

                case 23:
                    personalService.ListarPersonal();
                    break;

                case 24:
                    string acharPersonal = ConsoleHelpers.LerString("Digite o cpf do personal: ");
                    personalService.BuscarPersonalPorCpf(acharPersonal);
                    break;

                case 25:
                    string exluirPersonal = ConsoleHelpers.LerString("Digite o cpf do personal que deseja excluir: ");
                    personalService.ExcluirPersonal(exluirPersonal);
                    break;

                case 26:
                    pagamentoSevice.GerarPagamento();
                    break;

                case 27:
                    pagamentoSevice.ListarPagamento();

                    break;
                case 28:
                    string cpfAlunoPagamento = ConsoleHelpers.LerString("Digite o cpf aluno: ");
                    pagamentoSevice.BuscarPagamento(cpfAlunoPagamento);
                    break;
                case 29:
                    presencaService.RegistrarPresenca();
                    break;
                case 30:
                    presencaService.ListarPresenca();
                    break;
                case 31:
                    string cpfAlunoPresenca = ConsoleHelpers.LerString("Digite o cpf do aluno: ");
                    presencaService.BuscarPresencaPorCpf(cpfAlunoPresenca);
                    break;
                case 32:
                    presencaService.ListarAlunosPresentes();
                    break;
                case 33:
                    presencaService.ListarAlunosDoDia();
                    break;
                case 34:
                    relatorioService.ListarMatriculasAtivas();
                    break;
                case 35:
                    relatorioService.RelatorioFrequencia();
                    break;
                case 36:
                    relatorioService.AlunosPresentes();
                    break;
                case 37:
                    relatorioService.RelatorioPresencasDoDia();
                    break;


                    

            }

        }
    }
}
