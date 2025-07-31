using System;

abstract class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }

    public abstract void MostrarPerfil();
}

class Estudiante : Persona
{
    public Estudiante(string nombre) : base(nombre) { }

    public override void MostrarPerfil()
    {
        Console.WriteLine("Estudiante: " + Nombre);
    }
}

class Maestro : Persona
{
    public Maestro(string nombre) : base(nombre) { }

    public override void MostrarPerfil()
    {
        Console.WriteLine("Maestro: " + Nombre);
    }
}

class Escuela
{
    public void MostrarPersonas(Persona[] personas)
    {
        foreach (var persona in personas)
        {
            persona.MostrarPerfil();
        }
    }
}

class Program
{
    static void Main()
    {
        Persona[] personas = {
            new Estudiante("Luis"),
            new Maestro("Ana")
        };

        var escuela = new Escuela();
        escuela.MostrarPersonas(personas);
    }
}