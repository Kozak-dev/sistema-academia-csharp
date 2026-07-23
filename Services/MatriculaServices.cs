using SistemAcademia.Helpers;
using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace SistemAcademia.Services
{
    internal class MatriculaServices
    {
        private readonly List<Matricula> matriculas = new();

        private readonly AlunoServices _alunoServices;
        private readonly PlanoServices _planoServices;


        public MatriculaServices(AlunoServices alunoServices, PlanoServices planoServices)
        {
            _alunoServices = alunoServices;
            _planoServices = planoServices;

        }

        public void CadastrarMatricula()
        {
            _alunoServices.ListarAlunos();
            Console.WriteLine("Digite o cpf do aluno: ");
            string? cpfAluno = ConsoleHelpers.LerString("Digite o cpf do aluno: ");
            Aluno? aluno = _alunoServices.ObterAlunoPorCpf(cpfAluno);

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado!");
                return;
            }

            _planoServices.ListarPlano();
            Console.WriteLine("Digite o nome do plano: ");
            string? nomePlanoParaMatricula = ConsoleHelpers.LerString("Digite o nome do plano: ");
            Plano? plano = _planoServices.ObterPlanoPorNome(nomePlanoParaMatricula);

            if (plano == null)
            {
                Console.WriteLine("Plano não existe!");
                return;
            }
            string? unidadeParaMatricula = ConsoleHelpers.LerString("Digite a unidade: ");
            string? tipoDePagamentoParaMatricula = ConsoleHelpers.LerString("Digite o tipo de pagamento: ");
            DateOnly dataInicioParaMatricula = ConsoleHelpers.LerData("Digite a data de inicio: ");
            DateOnly dataVencimentoParaMatricula = CalcularDataVencimento(dataInicioParaMatricula, plano);
            Decimal valorContratadoParaMatricula = plano.Valor;
            string situaçãoParaMatricula = "Ativa";



            Matricula matricula = new Matricula(aluno, plano, unidadeParaMatricula, tipoDePagamentoParaMatricula, dataInicioParaMatricula, dataVencimentoParaMatricula, valorContratadoParaMatricula, situaçãoParaMatricula);
            matriculas.Add(matricula);
        }

       private DateOnly CalcularDataVencimento(DateOnly dataInicioParaMatricula, Plano plano)
        {
            if (plano.Tipo == "Mensal")
            {
                return dataInicioParaMatricula.AddMonths(1);
            }
            else if (plano.Tipo == "Trimestral")
            {
                return dataInicioParaMatricula.AddMonths(3);
            }
            else if (plano.Tipo == "Semestral")
            {
                return  dataInicioParaMatricula.AddMonths(6);
            }
            else
            {
                return dataInicioParaMatricula.AddYears(1);
            }
        }


        public void ListarMatricula()
        {
            foreach(Matricula mt in matriculas)
            {
                mt.MostrarMatricula();
            }
        }

        public void BuscarMatricula(string buscarMaticulaPorCpf)
        {
            foreach(Matricula mt in matriculas)
            {
                if(mt.Aluno.CPF == buscarMaticulaPorCpf)
                {
                    mt.MostrarMatricula();
                    return;
                }
            }
            Console.WriteLine("Matricula não encontrada!");
        }

        public void CancelarMatricula(string cancelarMatricula)
        {
           
            foreach (var mt in matriculas)
            {
                if(mt.Aluno.CPF == cancelarMatricula)
                {
                    mt.Cancelar();
                    Console.WriteLine("Matrícula cancelada com sucesso!");
                    return;
                }
            }
            Console.WriteLine("Matricula não encontradas!");         
        }

        public Matricula? ObterMatriculaPorCpf(string matriculaCpf)
        {
            foreach (Matricula mt in matriculas)
            {
                if (mt.Aluno.CPF == matriculaCpf)
                {
                    return mt;
                }
            }
            return null;

        }
        public List<Matricula> ObterMatriculas()
        {
            return matriculas;
        }


    }
}


            
            

     


    

    

