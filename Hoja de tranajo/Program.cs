using Hoja_de_tranajo.Clases;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca(); 
        int opcion;

        do
        {
            Console.WriteLine("\n MENÚ BIBLIOTECA ");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Prestar libro");
            Console.WriteLine("3. Mostrar libros disponibles");
            Console.WriteLine("4. Mostrar préstamos");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            bool valido = int.TryParse(Console.ReadLine(), out opcion);
            if (!valido)
            {
                Console.WriteLine("Opción no válida.");
                continue;
            }

            Console.WriteLine(); 

            switch (opcion)
            {
                case 1:
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();
                    biblioteca.RegistrarLibro(titulo, autor);
                    break;

                case 2:
                    Console.Write("Título del libro: ");
                    string tituloPrestamo = Console.ReadLine();
                    Console.Write("Nombre del usuario: ");
                    string usuario = Console.ReadLine();
                    biblioteca.PrestarLibro(tituloPrestamo, usuario);
                    break;

                case 3:
                    biblioteca.MostrarLibrosDisponibles();
                    break;

                case 4:
                    biblioteca.MostrarPrestamos();
                    break;

                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}