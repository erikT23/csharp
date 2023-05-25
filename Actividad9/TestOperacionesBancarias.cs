using System;

class TestOperacionesBancarias
{
    public static void Main(string[] args)
    {
        string nombreTitular;
        double saldo;

        Console.WriteLine("Ingrese el nombre del titular:");
        nombreTitular = Console.ReadLine();

        Console.WriteLine("Ingrese el saldo inicial de la cuenta:");
        string saldoInput = Console.ReadLine();

        if (double.TryParse(saldoInput, out saldo) && saldo > 0)
        {
            Console.WriteLine($"Saldo de la cuenta: {saldo}");
        }
        else
        {
            Console.WriteLine("Ingrese un valor numérico válido para el saldo de la cuenta.");
            return;
        }

        Console.WriteLine("Ingrese un NIP de 4 dígitos:");
        string nip = Console.ReadLine();

        if (nip.Length != 4 || !int.TryParse(nip, out _))
        {
            Console.WriteLine("El NIP debe ser un número de 4 dígitos.");
            return;
        }

        CuentaBancaria cuenta1 = new CuentaBancaria(nombreTitular, saldo, nip);

        Console.WriteLine($"Cuenta creada exitosamente para el titular {cuenta1.NombreTitular} con número de cuenta {cuenta1.NumeroCuenta}.");

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n----- MENÚ -----\n");
            Console.WriteLine($"1. Número de cuenta: {cuenta1.NumeroCuenta}");
            Console.WriteLine("2. Salir del cajero");

            Console.WriteLine("\nSeleccione una opción:");
            string opcionInput = Console.ReadLine();

            if (int.TryParse(opcionInput, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AutenticarCuenta(cuenta1);
                        break;
                    case 2:
                        salir = true;
                        Console.WriteLine("Saliendo del cajero...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            }
        }
    }

    public static void AutenticarCuenta(CuentaBancaria cuenta)
    {
        int intentos = 0;

        while (intentos < 3)
        {
            Console.WriteLine("\n--- AUTENTICACIÓN ---\n");
            Console.WriteLine("Ingrese su NIP:");

            string nipInput = Console.ReadLine();

            if (nipInput == cuenta.Nip)
            {
                Console.WriteLine($"Bienvenido/a, {cuenta.NombreTitular}!");
                MenuPrincipal(cuenta);
                return;
            }
            else
            {
                intentos++;
                Console.WriteLine("NIP incorrecto. Por favor, intente nuevamente.");
            }
        }

        Console.WriteLine("Se han excedido el número máximo de intentos. Volviendo al menú principal...");
    }

    public static void MenuPrincipal(CuentaBancaria cuenta)
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---\n");
            Console.WriteLine($"Cuenta: {cuenta.NumeroCuenta}");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar efectivo");
            Console.WriteLine("3. Retirar efectivo");
            Console.WriteLine("4. Transferir entre cuentas");
            Console.WriteLine("5. Cambiar NIP");
            Console.WriteLine("6. Cerrar sesión");

            Console.WriteLine("\nSeleccione una opción:");
            string opcionInput = Console.ReadLine();

            if (int.TryParse(opcionInput, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine($"Saldo actual: {cuenta.SaldoCuenta} pesos.");
                        break;
                    case 2:
                        RealizarDeposito(cuenta);
                        break;
                    case 3:
                        RealizarRetiro(cuenta);
                        break;
                    case 4:
                        RealizarTransferencia(cuenta);
                        break;
                    case 5:
                        CambiarNIP(cuenta);
                        break;
                    case 6:
                        salir = true;
                        Console.WriteLine("Cerrando sesión...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            }
        }
    }

    public static void RealizarDeposito(CuentaBancaria cuenta)
    {
        Console.WriteLine("Ingrese el monto a depositar:");
        string montoInput = Console.ReadLine();

        if (double.TryParse(montoInput, out double monto) && monto > 0)
        {
            cuenta.Depositar(monto);
        }
        else
        {
            Console.WriteLine("Ingrese un valor numérico válido para el monto.");
        }
    }

    public static void RealizarRetiro(CuentaBancaria cuenta)
    {
        Console.WriteLine("Ingrese el monto a retirar:");
        string montoInput = Console.ReadLine();

        if (double.TryParse(montoInput, out double monto) && monto > 0)
        {
            cuenta.Retirar(monto);
        }
        else
        {
            Console.WriteLine("Ingrese un valor numérico válido para el monto.");
        }
    }

    public static void RealizarTransferencia(CuentaBancaria cuenta)
    {
        Console.WriteLine("Ingrese el número de cuenta de destino:");
        string numeroCuentaDestino = Console.ReadLine();

        Console.WriteLine("Ingrese el monto a transferir:");
        string montoInput = Console.ReadLine();

        if (double.TryParse(montoInput, out double monto) && monto > 0)
        {
            CuentaBancaria cuentaDestino = ObtenerCuentaPorNumero(numeroCuentaDestino);

            if (cuentaDestino != null)
            {
                cuenta.Transferir(monto, cuentaDestino);
            }
            else
            {
                Console.WriteLine("La cuenta de destino no existe. Por favor, verifique el número de cuenta e intente nuevamente.");
            }
        }
        else
        {
            Console.WriteLine("Ingrese un valor numérico válido para el monto.");
        }
    }

    public static void CambiarNIP(CuentaBancaria cuenta)
    {
        Console.WriteLine("Ingrese el nuevo NIP:");
        string nuevoNIP = Console.ReadLine();

        if (nuevoNIP.Length != 4 || !int.TryParse(nuevoNIP, out _))
        {
            Console.WriteLine("El nuevo NIP debe ser un número de 4 dígitos.");
            return;
        }

        cuenta.Nip = nuevoNIP;
        Console.WriteLine("El NIP ha sido actualizado exitosamente.");
    }

    public static CuentaBancaria ObtenerCuentaPorNumero(string numeroCuenta)
    {
        // Aquí deberías implementar la lógica para obtener la cuenta bancaria correspondiente
        // según el número de cuenta proporcionado. Puede ser una búsqueda en una base de datos,
        // una lista de cuentas almacenadas en memoria, etc.
        // En esta implementación de ejemplo, simplemente se crea una nueva cuenta ficticia.

        // Aquí deberías reemplazar la siguiente línea con tu propia lógica para obtener la cuenta.
        CuentaBancaria cuentaDestino = new CuentaBancaria("Titular Destino", 1000, "1234");

        return cuentaDestino;
    }
}