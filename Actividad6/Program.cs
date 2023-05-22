class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la antigüedad del empleado en meses:");
        int antiguedad;
        bool antiguedadValida = false;

        do
        {
            if (!int.TryParse(Console.ReadLine(), out antiguedad))
            {
                Console.WriteLine("Error: ¡Ingrese solo números!");
            }
            else
            {
                antiguedadValida = true;
            }
        } while (!antiguedadValida);

        Console.WriteLine("Ingrese el departamento del empleado (a, b, c):");
        string departamento;
        bool departamentoValido = false;

        do
        {
            departamento = Console.ReadLine();

            if (departamento != "a" && departamento != "b" && departamento != "c")
            {
                Console.WriteLine("Error: ¡Departamento inválido!");
            }
            else
            {
                departamentoValido = true;
            }
        } while (!departamentoValido);

        Console.WriteLine("Ingrese la cantidad de hijos del empleado:");
        int cantidadHijos;
        bool cantidadHijosValida = false;

        do
        {
            if (!int.TryParse(Console.ReadLine(), out cantidadHijos))
            {
                Console.WriteLine("Error: ¡Ingrese solo números!");
            }
            else
            {
                cantidadHijosValida = true;
            }
        } while (!cantidadHijosValida);

        double bonoAntiguedad = CalcularBonoAntiguedad(departamento, antiguedad);
        double bonoHijos = CalcularBonoHijos(cantidadHijos);

        double bonoTotal = bonoAntiguedad + bonoHijos;

        Console.WriteLine("El departamento del empleado es: " + departamento);
        Console.WriteLine("El bono por antigüedad es: " + bonoAntiguedad);
        Console.WriteLine("El bono por hijos es: " + bonoHijos);
        Console.WriteLine("El bono total es: " + bonoTotal);
    }

    static double CalcularBonoAntiguedad(string departamento, int antiguedad)
    {
        double salarioMinimo = 207.44;

        if (departamento == "a")
        {
            if (antiguedad < 24)
            {
                return 5 * salarioMinimo;
            }
            else
            {
                return 8 * salarioMinimo;
            }
        }
        else if (departamento == "b")
        {
            if (antiguedad < 36)
            {
                return 9 * salarioMinimo;
            }
            else
            {
                return 12 * salarioMinimo;
            }
        }
        else if (departamento == "c")
        {
            if (antiguedad < 60)
            {
                return 14 * salarioMinimo;
            }
            else
            {
                return 17 * salarioMinimo;
            }
        }
        else
        {
            Console.WriteLine("Departamento inválido.");
            return 0;
        }
    }

    static double CalcularBonoHijos(int cantidadHijos)
    {
        double bonoPorHijo = 150;

        return bonoPorHijo * cantidadHijos;

    }
}