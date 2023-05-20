using System;

public class Carrera
{
    public int Id
    {
        get;
        set;
    }


    private string? nombre;

    public string? Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public Carrera(String nombre)
    {
        this.nombre = nombre;
    }


}