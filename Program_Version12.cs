using System;
using Celular.Models;

namespace Celular
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone nokia = new Nokia(numero: "11999999999", modelo: "Nokia 3310", imei: "123456789", memoria: 32);
            Smartphone iphone = new Iphone(numero: "11988888888", modelo: "iPhone 14", imei: "987654321", memoria: 128);

            Console.WriteLine($"Celular Nokia: {nokia.Modelo}, IMEI: {nokia.IMEI}, Memória: {nokia.Memoria}GB");
            nokia.Ligar();
            nokia.InstalarAplicativo("WhatsApp");

            Console.WriteLine();

            Console.WriteLine($"Celular iPhone: {iphone.Modelo}, IMEI: {iphone.IMEI}, Memória: {iphone.Memoria}GB");
            iphone.ReceberLigacao();
            iphone.InstalarAplicativo("Instagram");
        }
    }
}