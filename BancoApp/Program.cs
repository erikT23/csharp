using System;

public class CuentaBancaria
{
    private double saldoCuenta;

    private string? nombreTitular;

    private long numeroCuenta;

   

    public string? NombreTitular { get => nombreTitular; set => nombreTitular = value; }
    public long NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
    public double SaldoCuenta { get => saldoCuenta; set => saldoCuenta = value; }

    public CuentaBancaria(double saldoCuenta, string nombreTitular)
    {
        this.SaldoCuenta = saldoCuenta;
        this.nombreTitular = nombreTitular;
        numeroCuenta = AsignarNoCuenta();
    }


    public long AsignarNoCuenta()
    {
        Random objRandom = new Random();
        return objRandom.Next(00000001, 99999999);
    }






}