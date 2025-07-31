using System;

abstract class Vehiculo
{
    public abstract void Encender();
    public abstract void Conducir();
}

class Carro : Vehiculo
{
    public override void Encender()
    {
        Console.WriteLine("Encendiendo carro");
    }

    public override void Conducir()
    {
        Console.WriteLine("Conduciendo carro");
    }
}

class Motocicleta : Vehiculo
{
    public override void Encender()
    {
        Console.WriteLine("Encendiendo motocicleta");
    }

    public override void Conducir()
    {
        Console.WriteLine("Conduciendo motocicleta");
    }
}

class Ejercicio4Main
{
    static void Main()
    {
        Vehiculo[] vehiculos = {
            new Carro(),
            new Motocicleta()
        };

        foreach (var v in vehiculos)
        {
            v.Encender();
            v.Conducir();
        }
    }
}
