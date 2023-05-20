class Program

{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la antigüedad del empleado en meses:");

        if (!int.TryParse(Console.ReadLine(), out int antiguedad))
        {
            Console.WriteLine("Error: ¡Ingrese solo números!");
            return;
        }

        Console.WriteLine("Ingrese la cantidad de hijos del empleado:");

        if (!int.TryParse(Console.ReadLine(), out int cantidadHijos))
        {
            Console.WriteLine("Error: ¡Ingrese solo números!");
            return;
        }

        string departamento = CalcularDepartamento(antiguedad);
        double bonoAntiguedad = CalcularBonoAntiguedad(departamento, antiguedad);
        double bonoHijos = CalcularBonoHijos(cantidadHijos);

        double bonoTotal = bonoAntiguedad + bonoHijos;

        Console.WriteLine("El departamento del empleado es: " + departamento);
        Console.WriteLine("El bono por antigüedad es: " + bonoAntiguedad);
        Console.WriteLine("El bono por hijos es: " + bonoHijos);
        Console.WriteLine("El bono total es: " + bonoTotal);
    }

    static string CalcularDepartamento(int antiguedad)
    {
        if (antiguedad < 24 || (antiguedad >= 24 && antiguedad <= 35))
        {
            return "a";
        }
        else if (antiguedad < 36 || (antiguedad >= 36 && antiguedad <= 59))
        {
            return "b";
        }
        else
        {
            return "c";
        }
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



