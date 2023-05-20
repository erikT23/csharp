using System;

public class Estudiante
{

    private string? nombre;

    private string? apellidoPaterno;

    private String? apellidoMaterno;


    public string? Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }


    public Carrera? Carrera
    {
        get;
        set;
    }

    public string? ApellidoPaterno { get { return apellidoPaterno; } set { apellidoPaterno = value; } }

    public string? ApellidoMaterno { get { return apellidoPaterno; } set { apellidoMaterno = value; } }











}