using SistemAcademia.Helpers;
using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Services
{
   
    internal class PlanoServices
    {
        

        List<Plano> planos = new List<Plano>();

        public void CadastrarPlano()
        {
            List<string> vantagens = new List<string>();

            string? nomePlano = ConsoleHelpers.LerString("Digite o nome do plano: ");
            decimal valor = ConsoleHelpers.LerDecimal("Digite o valor ");
            int opção = ConsoleHelpers.LerInt("Digite quantas vantagens tem no plano: ");
            string? tipo = ConsoleHelpers.LerString("Digite o tipo do plano: ");
            for (int i = 0; i < opção; i++) 
            {
                string vantagem = ConsoleHelpers.LerString($"Digite a {i + 1}° vantagem: ");
                vantagens.Add(vantagem);
            }


            Plano plano = new Plano(nomePlano, valor, vantagens, tipo);
            planos.Add(plano);
        }

        public void ListarPlano()
        {
            if(planos.Count == 0)
            {
                Console.WriteLine("A lista esta vazia!");
                return;
            }
            
                foreach(Plano pl in planos)
                {
                    pl.MostrarPlano();
                    Console.WriteLine("--------------------------------------");
                }

      
        }

        public void BuscarPlanoPorNome(string buscarPlano)
        {

            foreach(Plano pl in planos)
            {
                if(pl.Nome == buscarPlano)
                {
                    pl.MostrarPlano();
                    return;
                }
            }

            Console.WriteLine("Plano não encontrado!");
        }

        public void ExcluirPlano(string excluirPlano)
        {

            Plano? planoAchado = null;
            
            foreach(Plano pl in planos)
            {
                if(pl.Nome == excluirPlano)
                {
                    planoAchado = pl;
                    break;
                }
            }

            if(planoAchado != null)
            {
                planos.Remove(planoAchado);
                Console.WriteLine("Plano excluido com sucesso!");
            }

            else
            {
                Console.WriteLine("Plano não encontrado!");
            }
        }

        public Plano? ObterPlanoPorNome(string nomePlanoParaMatricula)
        {
            foreach (Plano pl in planos)
            {
                if(pl.Nome == nomePlanoParaMatricula)
                {
                    return pl;
                }
            }
            return null;
        }


    }
}
