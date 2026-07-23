using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Personal : Pessoa
    {
        public string  CREF { get; private set; }
        public string Especialidade { get; private set; }
        public DateOnly DataDeContratação { get; private set; }

        public Personal(string nome, string cpf, string cref, string especialidade, DateOnly dataNascimento, string telefone, string email, DateOnly dataDeContratação)
            :base(nome, cpf, telefone, dataNascimento, email)
        {
            CREF = cref;
            Especialidade = especialidade;
            DataDeContratação = dataDeContratação;

        }

        public void MostrarPersonal()
        {
            MostrarDados();
            Console.WriteLine($"CREF: {CREF}");
            Console.WriteLine($"Especialidade: {Especialidade}");
            Console.WriteLine($"Data de contratação: {DataDeContratação}");

        }
    }

    
}
