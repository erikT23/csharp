class CuentaBancaria
{

    private string? nombreTitular;

    private double saldoCuenta;

    private string? numeroCuenta;

    private string? nip;



    public CuentaBancaria()
    {
    }

    public CuentaBancaria(string nombreTitular, double saldoCuenta, string nip)
    {
        NombreTitular = nombreTitular;
        SaldoCuenta = saldoCuenta;
        NumeroCuenta = GenerarNumeroCuenta();
        Nip = nip;
    }


    private string GenerarNumeroCuenta()
    {
        Random random = new Random();
        string numeroCuenta = random.Next(10000000, 99999999).ToString();
        return numeroCuenta;
    }


    public void Depositar(double monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El monto del depósito debe ser mayor a $0.00 pesos.");
            return;
        }

        SaldoCuenta += monto;
        Console.WriteLine($"Se ha depositado {monto} pesos en la cuenta {NumeroCuenta}. Saldo actual: {SaldoCuenta} pesos.");
    }

    public void Retirar(double monto)
    {
        if (monto <= 0)
        {
            Console.WriteLine($"EL monto del retiro debe ser mayor a $0.00 pesos.");
            return;
        }
        if (monto > SaldoCuenta)
        {
            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
            return;
        }
        saldoCuenta -= monto;
        Console.WriteLine($"Se ha retirado {monto} pesos en la cuenta {NumeroCuenta}. Saldo actual: {SaldoCuenta} pesos.");
    }

    public void Transferir(double monto, CuentaBancaria cuentaDestino)
    {
        if (monto <= 0)
        {
            Console.WriteLine("El monto de la transferencia debe ser mayor a $0.00 pesos.");
            return;
        }

        if (monto > SaldoCuenta)
        {
            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
            return;
        }

        SaldoCuenta -= monto;
        cuentaDestino.SaldoCuenta += monto;

        Console.WriteLine($"Se ha transferido {monto} pesos de la cuenta {NumeroCuenta} a la cuenta {cuentaDestino.NumeroCuenta}.");
        Console.WriteLine($"Saldo actual de la cuenta {NumeroCuenta}: {SaldoCuenta} pesos.");
        Console.WriteLine($"Saldo actual de la cuenta destino {cuentaDestino.NumeroCuenta}: {cuentaDestino.SaldoCuenta} pesos.");
    }

    public string NombreTitular { get => nombreTitular; set => nombreTitular = value; }
    public double SaldoCuenta { get => saldoCuenta; set => saldoCuenta = value; }
    public string NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
    public string Nip { get => nip; set => nip = value; }
}