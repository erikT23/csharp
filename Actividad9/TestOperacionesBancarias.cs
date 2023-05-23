using System;

class TestOperacionesBancarias
{
    public static void Main(string[] args)
    {
        // cuenta1 = new CuentaBancaria();
        string? nombreTitular;


        Console.WriteLine($"Ingresa el nombre del titular");
        nombreTitular = Console.ReadLine();
        Console.WriteLine($"Ingresa el saldo inicial de la cuenta");

        string saldoInput = Console.ReadLine();


        if (double.TryParse(saldoInput, out double saldo) & saldo > 0)
        {
            Console.WriteLine($"Saldo de la cuenta: {saldo}");
        }
        else
        {
            Console.WriteLine("Ingrese un valor numérico válido para el saldo de la cuenta.");
        }

        Console.WriteLine($"Ingrese un nip");
        string nip = Console.ReadLine();

        if (nip.ToString().Length != 4)
        {
            Console.WriteLine($"El nip debe ser de 4 digitos");
            return;
        }

        Console.WriteLine(nip);
        Console.WriteLine(nombreTitular);
        Console.WriteLine(saldo);
        CuentaBancaria cuenta1 = new CuentaBancaria(nombreTitular, saldo, nip);
        Console.WriteLine(cuenta1);






    }

}