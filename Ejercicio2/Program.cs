using Hoja_de_tranajo.Clases;

class Program
{
    static void Main(string[] args)
    {
        Usuario usuario = new Usuario();

        try
        {
            Console.Write("Ingrese su nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese su DPI (13 dígitos): ");
            usuario.DPI = Console.ReadLine();

            Console.Write("Cree una contraseña (mínimo 6 caracteres): ");
            string pass = Console.ReadLine();
            usuario.AsignarContraseña(pass);

            Console.WriteLine("\nUsuario registrado exitosamente.");

            Console.Write("\nIngrese su contraseña para autenticar: ");
            string intento = Console.ReadLine();

            if (usuario.Autenticar(intento))
            {
                Console.WriteLine(" Autenticación exitosa.");
            }
            else
            {
                Console.WriteLine(" Contraseña incorrecta.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}