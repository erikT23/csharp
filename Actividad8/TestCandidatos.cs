class TestCandidatos
{
    static void Main(string[] args)
    {
        Candidato[] candidatos = new Candidato[3];
        string[] nombresCandidatos = new string[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Ingresa el nombre del candidato {i + 1}: ");
            nombresCandidatos[i] = Console.ReadLine();
            candidatos[i] = new Candidato(nombresCandidatos[i]);
        }

        bool votacionAbierta = true;
        int opcion;

        while (votacionAbierta)
        {
            Console.WriteLine("Menú:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}. Votar por candidato \"{nombresCandidatos[i]}\"");
            }
            Console.WriteLine("4. Cerrar casilla");

            Console.Write("Ingrese una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                case 2:
                case 3:
                    candidatos[opcion - 1].NumeroVotos++;
                    Console.WriteLine($"Voto registrado para el candidato \"{nombresCandidatos[opcion - 1]}\".");
                    break;
                case 4:
                    bool votacionCerrada = CerrarCasilla();
                    if (votacionCerrada)
                        votacionAbierta = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }

        Console.WriteLine("\nResultados de la elección:");
        int totalVotos = 0;
        int maxVotos = 0;
        int ganadorIndex = -1;
        bool empate = false;

        for (int i = 0; i < 3; i++)
        {
            totalVotos += candidatos[i].NumeroVotos;
            if (candidatos[i].NumeroVotos > maxVotos)
            {
                maxVotos = candidatos[i].NumeroVotos;
                ganadorIndex = i;
                empate = false;
            }
            else if (candidatos[i].NumeroVotos == maxVotos)
            {
                empate = true;
            }
        }

        if (totalVotos == 0)
        {
            Console.WriteLine("Urna vacía");
        }
        else if (empate)
        {
            Console.WriteLine("Se cayó el sistema");
        }
        else
        {
            Console.WriteLine($"Ganador: {candidatos[ganadorIndex].Nombre}");
            Console.WriteLine($"Votos obtenidos: {candidatos[ganadorIndex].NumeroVotos}");
            Console.WriteLine($"Porcentaje de votos: {((double)candidatos[ganadorIndex].NumeroVotos / totalVotos) * 100}%");
        }
    }
    static bool CerrarCasilla()
    {
        const string CONTRASENA = "contraseña";
        int intentosRestantes = 3;

        while (intentosRestantes > 0)
        {
            Console.Write("Ingrese la contraseña para cerrar la casilla: ");
            string contrasenaIngresada = Console.ReadLine();

            if (contrasenaIngresada == CONTRASENA)
            {
                Console.WriteLine("Casilla cerrada. Finalizando votación...");
                return true;
            }
            else
            {
                intentosRestantes--;
                Console.WriteLine($"Contraseña incorrecta. Intentos restantes: {intentosRestantes}");

                if (intentosRestantes == 0)
                {
                    Console.WriteLine("Máximo de intentos alcanzado. La votación continuará.");
                    return false;
                }
            }
        }

        return false;
    }
}