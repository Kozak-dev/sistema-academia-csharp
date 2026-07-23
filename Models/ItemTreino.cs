using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class ItemTreino
    {
        public Exercicio? Exercicio { get; private set; }
        public int Series { get; private set; }
        public int Repeticões { get; private set; }
        public string? Descanso { get; private set; }
        public string? Observações { get; private set; }

        public ItemTreino( Exercicio exercicio, int serie, int repeticões, string descanso, string observações)
        {
            Exercicio = exercicio;
            Series = serie;
            Repeticões = repeticões;
            Descanso = descanso;
            Observações = observações;
        }

        public void MostrarItensTreino()
        {
            Console.WriteLine($"Nome do exercicio: {Exercicio?.Nome}");
            Console.WriteLine($"{Series} x {Repeticões} ");
            Console.WriteLine($"Tempo de descanso entre series: {Descanso}");
            Console.WriteLine($"Observaçoes: {Observações} ");


        }

    }
}
