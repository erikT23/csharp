using System;

class Candidato
{
    private string? nombre;
    private int numeroVotos;

    public Candidato()
    {
    }

    public Candidato(string nombre)
    {
        this.nombre = nombre;
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public int NumeroVotos
    {
        get { return numeroVotos; }
        set { numeroVotos = value; }
    }






}
