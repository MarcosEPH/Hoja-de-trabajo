using Inventario_controlado_sin_duplicados.Clases;

class Program
{
    static void Main()
    {
        Inventario inventario = new Inventario();
        int opcion;

        do
        {
            Console.WriteLine("\n1. Agregar producto");
            Console.WriteLine("2. Retirar producto");
            Console.WriteLine("3. Mostrar inventario");
            Console.WriteLine("0. Salir");
            Console.Write("Elige opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int cantidadAgregar))
                    {
                        inventario.AgregarProducto(nombre, cantidadAgregar);
                    }
                    else
                    {
                        Console.WriteLine("Cantidad inválida.");
                    }
                    break;

                case 2:
                    Console.Write("Nombre: ");
                    string nombreRetirar = Console.ReadLine();
                    Console.Write("Cantidad: ");
                    if (int.TryParse(Console.ReadLine(), out int cantidadRetirar))
                    {
                        inventario.RetirarProducto(nombreRetirar, cantidadRetirar);
                    }
                    else
                    {
                        Console.WriteLine("Cantidad inválida.");
                    }
                    break;

                case 3:
                    inventario.MostrarInventario();
                    break;

                case 0:
                    Console.WriteLine("Adiós.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 0);
    }
}