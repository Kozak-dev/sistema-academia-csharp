using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Exercicio
    {
        
        public string Nome {  get; private set; }
        public string GrupoMuscular { get; private set; }
        public string Descrição { get; private set; }
        
        public Exercicio(string nome, string grupoMuscular, string descrição)
        {
            Nome = nome;
            GrupoMuscular = grupoMuscular;
            Descrição = descrição;
        }
        public void MostrarExercicio()
        {
            Console.WriteLine($"Nome: {Nome} | Grupo muscular: {GrupoMuscular} | Descrição: {Descrição}");
        }
    }
}
