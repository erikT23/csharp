using System;

public class OperacionesBanco
{
    public static void Main(string[] args)
    {

        Console.WriteLine($"ingresa un numero");
        string? numTmp = Console.ReadLine();
        bool respuesta = ValidarNumero(numTmp);
        while (!respuesta)
        {
            Console.WriteLine($"ingresa un numero correcto");
            numTmp = Console.ReadLine();
            respuesta = ValidarNumero(numTmp);
        }
        double saldoCuenta = Convert.ToDouble(numTmp);


        CuentaBancaria objCuenta = new CuentaBancaria("erik", saldoCuenta);
        Console.WriteLine($"paso");

    }

    public static bool ValidarNumero(string? valor)
    {
        if (double.TryParse(valor, out double numero))
        {
            return true;
        }
        else
        {
            Console.WriteLine($"Error, se esperaba un numero");

            return false;
        }
    }
}