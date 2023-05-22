using System;

class TestCandidatos
{
    const string Password = "secreto"; 
    const int MaxIntentos = 3; 

    static void Main(string[] args)
    {
        Candidato candidato1, candidato2, candidato3;

        Console.WriteLine("Ingrese el nombre del primer candidato:");
        string nombre1 = Console.ReadLine();
        candidato1 = new Candidato(nombre1);

        Console.WriteLine("Ingrese el nombre del segundo candidato:");
        string nombre2 = Console.ReadLine();
        candidato2 = new Candidato(nombre2);

        Console.WriteLine("Ingrese el nombre del tercer candidato:");
        string nombre3 = Console.ReadLine();
        candidato3 = new Candidato(nombre3);

        Console.WriteLine("Elecciones en proceso...");

        int totalVotos = 0;

        while (true)
        {
            Console.WriteLine("------- Menú de Votación -------");
            Console.WriteLine("1. Votar por candidato " + candidato1.Nombre);
            Console.WriteLine("2. Votar por candidato " + candidato2.Nombre);
            Console.WriteLine("3. Votar por candidato " + candidato3.Nombre);
            Console.WriteLine("4. Cerrar casilla");

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                candidato1.NumeroVotos++;
                totalVotos++;
                Console.WriteLine("¡Has votado por " + candidato1.Nombre + "!");
            }
            else if (opcion == "2")
            {
                candidato2.NumeroVotos++;
                totalVotos++;
                Console.WriteLine("¡Has votado por " + candidato2.Nombre + "!");
            }
            else if (opcion == "3")
            {
                candidato3.NumeroVotos++;
                totalVotos++;
                Console.WriteLine("¡Has votado por " + candidato3.Nombre + "!");
            }
            else if (opcion == "4")
            {
                Console.WriteLine("Ingrese la contraseña para cerrar la casilla:");
                string contraseña = Console.ReadLine();

                if (contraseña == Password)
                {
                    Console.WriteLine("Casilla cerrada. Finalizando elecciones...");
                    break;
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta. Intentos restantes: " + (MaxIntentos - 1));
                    if (MaxIntentos == 1)
                    {
                        Console.WriteLine("Máximo de intentos alcanzado. Continuando con la votación...");
                    }
                }
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, selecciona una opción válida.");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("----- Resultados de las Elecciones -----");

        if (totalVotos == 0)
        {
            Console.WriteLine("Urna vacía. Nadie acudió a votar.");
        }
        else
        {
            Candidato ganador = ObtenerGanador(candidato1, candidato2, candidato3);

            Console.WriteLine("Candidato: " + candidato1.Nombre);
            Console.WriteLine("Número de votos: " + candidato1.NumeroVotos);
            Console.WriteLine("Porcentaje de votos: " + CalcularPorcentaje(candidato1.NumeroVotos, totalVotos) + "%");
            Console.WriteLine();
            Console.WriteLine("Candidato: " + candidato2.Nombre);
            Console.WriteLine("Número de votos: " + candidato2.NumeroVotos);
            Console.WriteLine("Porcentaje de votos: " + CalcularPorcentaje(candidato2.NumeroVotos, totalVotos) + "%");
            Console.WriteLine();
            Console.WriteLine("Candidato: " + candidato3.Nombre);
            Console.WriteLine("Número de votos: " + candidato3.NumeroVotos);
            Console.WriteLine("Porcentaje de votos: " + CalcularPorcentaje(candidato3.NumeroVotos, totalVotos) + "%");
            Console.WriteLine();

            if (ganador != null)
            {
                Console.WriteLine("¡El ganador de las elecciones es: " + ganador.Nombre + "!");
            }
            else
            {
                Console.WriteLine("Se cayó el sistema. Hubo un empate entre los candidatos.");
            }
        }
    }

    static double CalcularPorcentaje(int votos, int totalVotos)
    {
        if (totalVotos == 0)
        {
            return 0.0;
        }

        return (votos * 100.0) / totalVotos;
    }

    static Candidato ObtenerGanador(Candidato candidato1, Candidato candidato2, Candidato candidato3)
    {
        if (candidato1.NumeroVotos > candidato2.NumeroVotos && candidato1.NumeroVotos > candidato3.NumeroVotos)
        {
            return candidato1;
        }
        else if (candidato2.NumeroVotos > candidato1.NumeroVotos && candidato2.NumeroVotos > candidato3.NumeroVotos)
        {
            return candidato2;
        }
        else if (candidato3.NumeroVotos > candidato1.NumeroVotos && candidato3.NumeroVotos > candidato2.NumeroVotos)
        {
            return candidato3;
        }
        else
        {
            return null;
        }
    }
}
