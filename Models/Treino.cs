using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Treino
    {
        public List<ItemTreino> Itens { get; private set; } = new();
        public string Nome {  get; private set; }

        public Treino (string nome)
        {
            Nome = nome;
        }

        public void MostrarNomeTreino()
        {
            Console.WriteLine($"Nome do treino: {Nome} ");
        }
    }
}

