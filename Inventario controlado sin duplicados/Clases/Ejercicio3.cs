using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario_controlado_sin_duplicados.Clases
{
    public class Inventario
    {
        class Producto
        {
            public string Nombre;
            public int Cantidad;

            public Producto(string nombre, int cantidad)
            {
                Nombre = nombre;
                Cantidad = cantidad;
            }
        }

        List<Producto> productos = new List<Producto>();

        public void AgregarProducto(string nombre, int cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("Cantidad debe ser mayor que 0.");
                return;
            }

            foreach (var p in productos)
            {
                if (p.Nombre.ToLower() == nombre.ToLower())
                {
                    p.Cantidad += cantidad;
                    Console.WriteLine("Cantidad actualizada: " + p.Cantidad);
                    return;
                }
            }

            productos.Add(new Producto(nombre, cantidad));
            Console.WriteLine("Producto agregado.");
        }

        public bool RetirarProducto(string nombre, int cantidad)
        {
            if (cantidad <= 0)
            {
                Console.WriteLine("Cantidad debe ser mayor que 0.");
                return false;
            }

            foreach (var p in productos)
            {
                if (p.Nombre.ToLower() == nombre.ToLower())
                {
                    if (p.Cantidad >= cantidad)
                    {
                        p.Cantidad -= cantidad;
                        Console.WriteLine("Producto retirado.");

                        if (p.Cantidad == 0)
                        {
                            productos.Remove(p);
                            Console.WriteLine("Producto eliminado porque ya no queda.");
                        }
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No hay suficiente cantidad.");
                        return false;
                    }
                }
            }

            Console.WriteLine("Producto no encontrado.");
            return false;
        }

        public void MostrarInventario()
        {
            Console.WriteLine("Inventario:");

            if (productos.Count == 0)
            {
                Console.WriteLine("Está vacío.");
                return;
            }

            foreach (var p in productos)
            {
                Console.WriteLine(p.Nombre + ": " + p.Cantidad);
            }
        }
    }
}