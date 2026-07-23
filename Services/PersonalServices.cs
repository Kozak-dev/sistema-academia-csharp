using SistemAcademia.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SistemAcademia.Services
{
    internal class PersonalServices
    {
        List<Personal> personals = new List<Personal>();

        public void CadastrarPersonal(Personal personal)
        {
            foreach(var pl in personals)
            {
                if(pl.CPF == personal.CPF)
                {
                    Console.WriteLine("CPF personal ja cadastrado!");
                    return;
                }
            }
            personals.Add(personal);
            Console.WriteLine("Personal cadastrado com sucesso!");
            
        }

        public void ListarPersonal()
        {
            if(personals.Count == 0)
            {
                Console.WriteLine("Lista vazia!");
                return;
            }

            foreach (var pl in personals)
            {
                pl.MostrarPersonal();
                Console.WriteLine("--------------------------------------------");
            }
        }

        public void BuscarPersonalPorCpf(string acharPersonal)
        {
            foreach (var pl in personals)
            {
                if(pl.CPF == acharPersonal)
                {
                    pl.MostrarPersonal();
                    return;
                }
            }

            Console.WriteLine("Personal não encontrado.");
        }

        public void ExcluirPersonal(string excluirPersonal)
        {
            Personal? personalEncontrado = null;

            foreach (var pl in personals)
            {
                if(pl.CPF == excluirPersonal)
                {
                    personalEncontrado = pl;
                    break;
                }
            }

            if(personalEncontrado == null)
            {
                Console.WriteLine("Personal não encontrado!");
            }
            else
            {
                personals.Remove(personalEncontrado);
            }


        }

        public Personal? ObterPersonalPorCpf(string cpfPersonal)
        {
            foreach(var pl in personals)
            {
                if(pl.CPF == cpfPersonal)
                {
                    return pl;
                }
            }

            return null;
        }
    }
}
