using System;
using System.Collections.Generic;
using Hotel.Models;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma suíte
            Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 100);

            // Cria uma lista de hóspedes
            List<Pessoa> hospedes = new List<Pessoa>();
            hospedes.Add(new Pessoa(nome: "Florentino", sobrenome: "Santos"));
            hospedes.Add(new Pessoa(nome: "João", sobrenome: "Silva"));

            // Cria uma reserva
            Reserva reserva = new Reserva(suite, diasReservados: 12);
            reserva.CadastrarHospedes(hospedes);

            Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor total da reserva: {reserva.CalcularValorDiaria():C}");
        }
    }
}