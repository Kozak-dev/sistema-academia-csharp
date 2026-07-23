using System;
using System.Collections.Generic;
using System.Text;

namespace SistemAcademia.Models
{
    internal class Presenca
    {
        public Aluno Aluno { get; private set; }
        public DateOnly Data { get; private set; }
        public TimeOnly HoraEntrada { get; private set; }
        public TimeOnly? HoraSaida { get; private set; }

        public Presenca(Aluno aluno)
        {
            Aluno = aluno;
            Data = DateOnly.FromDateTime(DateTime.Now);
            HoraEntrada = TimeOnly.FromDateTime(DateTime.Now);
            HoraSaida = null;
        }

        public void RegistrarSaida()
        {
            HoraSaida = TimeOnly.FromDateTime(DateTime.Now);
        }

        public void MostrarPresenca()
        {
            Console.WriteLine($"Nome: {Aluno.Nome}");
            Console.WriteLine($"Data: {Data}");
            Console.WriteLine($"Hora Entrada: {HoraEntrada}");
            Console.WriteLine($"Hora saida: {HoraSaida}");
        }
    }
}
