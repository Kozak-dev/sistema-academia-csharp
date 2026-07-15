using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Aluno : Pessoa

    {
        public Aluno(string nome, string cpf, string email, DateOnly dataNascimento, string telefone )
            : base (nome, cpf, email, dataNascimento, telefone)
        {
            
        }


    }
}
