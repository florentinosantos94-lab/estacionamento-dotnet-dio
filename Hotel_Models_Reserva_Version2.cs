using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(Suite suite, int diasReservados)
        {
            Suite = suite;
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a quantidade de hóspedes excede a capacidade da suíte
            if (hospedes.Count > Suite.Capacidade)
            {
                throw new Exception("A quantidade de hóspedes excede a capacidade da suíte.");
            }
            Hospedes = hospedes;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                valor *= 0.9M; // desconto de 10%
            }
            return valor;
        }
    }
}