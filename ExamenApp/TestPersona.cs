using System;

public class TestPersona
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido, ingresa un nombre");
        string? Nombre = Console.ReadLine();

        Console.WriteLine("Ingresa la edad");
        if (!int.TryParse(Console.ReadLine(), out int Edad))
        {
            Console.WriteLine("Edad inválida. Debe ser un número entero.");
            return;
        }

        Console.WriteLine("Ingresa la estatura con formato decimal: ejemplo 1.70");
        if (!float.TryParse(Console.ReadLine(), out float Estatura))
        {
            Console.WriteLine("Estatura inválida. Debe ser un número decimal.");
            return;
        }

        Console.WriteLine("Ingresa el sexo: F o M");
        if (!char.TryParse(Console.ReadLine(), out char Sexo))
        {
            Console.WriteLine("Sexo inválido. Debe ser 'F' o 'M'.");
            return;
        }

        Console.WriteLine("Ingresa el estado civil: S = Soltero, C = Casado");
        if (!char.TryParse(Console.ReadLine(), out char Estado))
        {
            Console.WriteLine("Estado civil inválido. Debe ser 'S' o 'C'.");
            return;
        }

        Estado = char.ToLower(Estado);
        bool EstadoCivil;
        switch (Estado)
        {
            case 'c':
                EstadoCivil = true;
                break;
            case 's':
                EstadoCivil = false;
                break;
            default:
                Console.WriteLine("Valor incorrecto, ingrese 'S' para soltero o 'C' para casado");
                return;
        }

        Persona objPersona = new Persona(Nombre, Edad, Estatura, Sexo, EstadoCivil);
        Console.WriteLine("Registro exitoso");

        int opcion = 0;

        while (opcion != 3)
        {
            Console.WriteLine("1. Mostrar los datos");
            Console.WriteLine("2. Cambiar los datos");
            Console.WriteLine("3. Salir");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción incorrecta. Por favor, ingresa un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:

                    Console.WriteLine("Datos de usuario");
                    Console.WriteLine(objPersona.Obtener());

                    break;

                case 2:

                    objPersona.Modificar();

                    break;

                case 3:
                    Console.WriteLine("¿Estás seguro de que deseas salir? (S/N)");
                    string? confirmacionSalir = Console.ReadLine();
                    if (confirmacionSalir?.ToUpper() == "S")
                    {
                        Console.WriteLine("Adiós.");
                    }
                    else
                    {
                        Console.WriteLine("Operación cancelada.");
                        opcion = 0;
                    }
                    break;

                default:
                    Console.WriteLine("Opción incorrecta. Por favor, selecciona una opción válida.");
                    opcion = 0;
                    break;
            }
        }
    }
}
