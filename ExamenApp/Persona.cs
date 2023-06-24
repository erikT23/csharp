using System;

public class Persona
{
    private string? nombre;

    private int edad;

    private float estatura;

    private char? sexo;

    private bool estadoCivil;

    public Persona(string? nombre, int edad, float estatura, char? sexo, bool estadoCivil)
    {
        this.Nombre = nombre;
        this.Edad = edad;
        this.Estatura = estatura;
        this.Sexo = sexo;
        this.EstadoCivil = estadoCivil;
    }

    public string? Nombre { get => nombre; set => nombre = value; }
    public int Edad { get => edad; set => edad = value; }
    public float Estatura { get => estatura; set => estatura = value; }
    public char? Sexo { get => sexo; set => sexo = value; }
    public bool EstadoCivil { get => estadoCivil; set => estadoCivil = value; }


    public string Obtener()
    {
        Console.WriteLine("Nombre de usuario: " + (nombre ?? "N/A"));
        Console.WriteLine("Edad de usuario: " + edad);
        Console.WriteLine("Estatura Usuario: " + estatura);
        Console.WriteLine("Sexo Usuario: " + sexo);

        if (!estadoCivil)
        {
            Console.WriteLine("Soltero");
        }
        else
        {
            Console.WriteLine("Casado");
        }

        return nombre ?? string.Empty;
    }



    public string? Modificar()
    {
        Console.WriteLine("Que dato desea modificar?");
        Console.WriteLine("1.-Nombre \n 2.- Edad \n 3.-Estatura \n 4.-Sexo \n 5.-Estado Civil \n 6.-Regresar al menú anterior ");
        string? eleccionTmp = Console.ReadLine();
        int eleccion = Convert.ToInt32(eleccionTmp);
        Console.WriteLine(eleccion);


        switch (eleccion)
        {
            case 1:


                Console.WriteLine("Ingrese su nuevo nombre");
                string? NuevoNombre = Console.ReadLine();

                Console.WriteLine("Esta seguro que desea hacer el cambio? \n 1- Si \n 2 - No");
                string? confirmarTmp = Console.ReadLine();
                int confirmar = Convert.ToInt32(confirmarTmp);
                if (confirmar == 1)
                {

                    nombre = NuevoNombre;
                }
                else
                {
                    break;
                }

                break;

            case 2:
                Console.WriteLine("Ingrese su nueva edad");
                string? NuevaEdadTmp = Console.ReadLine();
                int NuevaEdad = Convert.ToInt32(NuevaEdadTmp);
                Console.WriteLine("Esta seguro que desea hacer el cambio? \n 1- Si \n 2 - No");
                string? confirmarTmp2 = Console.ReadLine();
                int confirmar2 = Convert.ToInt32(confirmarTmp2);

                if (confirmar2 == 1)
                {

                    edad = NuevaEdad;
                }
                else
                {
                    break;
                }

                break;

            case 3:
                Console.WriteLine("Ingrese su nueva estatura");
                string? NuevaEstaturaTmp = Console.ReadLine();
                float NuevaEstatura = Convert.ToInt32(NuevaEstaturaTmp);
                Console.WriteLine("Esta seguro que desea hacer el cambio? \n 1- Si \n 2 - No");
                string? confirmarTmp3 = Console.ReadLine();
                int confirmar3 = Convert.ToInt32(confirmarTmp3);

                if (confirmar3 == 1)
                {


                    estatura = NuevaEstatura;
                }
                else
                {
                    break;
                }

                break;

            case 4:
                Console.WriteLine("Ingrese su nuevo sexo");
                string? NuevoSexotmp = Console.ReadLine();
                char NuevoSexo;
                if (!char.TryParse(NuevoSexotmp, out NuevoSexo))
                {
                    Console.WriteLine("Sexo inválido. Debe ser 'F' o 'M'.");
                }
                else
                {
                    Console.WriteLine("Esta seguro que desea hacer el cambio? \n 1- Si \n 2 - No");
                    string? confirmarTmp4 = Console.ReadLine();
                    int confirmar4 = Convert.ToInt32(confirmarTmp4);

                    if (confirmar4 == 1)
                    {

                        sexo = NuevoSexo;

                    }
                    else
                    {
                        break;
                    }


                }


                break;

            case 5:
                Console.WriteLine("Ingrese su nuevo estado civil \n 1 casado \n 0 soltero");
                string? NuevoEstadoCivilTmp = Console.ReadLine();
                int NuevoEstadoCivil = Convert.ToInt32(NuevoEstadoCivilTmp);
                if (NuevoEstadoCivil == 1)
                {
                    Console.WriteLine("Esta seguro que desea hacer el cambio? \n 1- Si \n 2 - No");
                    string? confirmarTmp5 = Console.ReadLine();
                    int confirmar5 = Convert.ToInt32(confirmarTmp5);
                    if (confirmar5 == 1)
                    {
                        estadoCivil = true;
                    }
                    else
                    {
                        break;
                    }

                }
                else if (NuevoEstadoCivil == 0)
                {
                    Console.WriteLine("Esta seguro que desea hacer el cambio? \n 1- Si \n 2 - No");
                    string? confirmarTmp5 = Console.ReadLine();
                    int confirmar5 = Convert.ToInt32(confirmarTmp5);
                    if (confirmar5 == 1)
                    {
                        estadoCivil = false;
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("Opcion invalida");
                    eleccion = 5;

                }


                break;

            default:
                Console.WriteLine("Opción incorrecta. Por favor, selecciona una opción válida.");
                eleccion = 0;
                break;

        }

        return nombre;
    }
}