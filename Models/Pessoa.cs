using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SistemAcademia.Models
{
    public class Pessoa
    {
        public string Nome { get; private set;  }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public Pessoa(string nome, string cpf, string email, DateOnly dataNascimento, string telefone) 
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            DataNascimento = dataNascimento;
            Telefone = telefone;

        }
        public void MostrarDados()
        {
            Console.WriteLine($"Nome: {Nome} | CPF: {CPF} | Email: {Email} | Data de Nascimento: {DataNascimento} | Telefone: {Telefone}");

        }

    }
}
