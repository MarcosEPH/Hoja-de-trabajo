using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoja_de_tranajo.Clases
{
    public class Libro
    {
        public string Titulo { get; }
        public string Autor { get; }
        public int Id { get; }

        public bool Disponible { get; internal set; }

        public Libro(string titulo, string autor, int id)
        {
            Titulo = titulo;
            Autor = autor;
            Id = id;
            Disponible = true;
        }
    }

    public class Biblioteca
    {
    
        private List<Libro> libros = new List<Libro>();
        private Dictionary<int, string> prestamos = new Dictionary<int, string>();
        private int siguienteId = 1;

        public bool RegistrarLibro(string titulo, string autor)
        {
            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
            {
                Console.WriteLine("Título y autor no pueden estar vacíos.");
                return false;
            }

            if (libros.Any(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Ya existe un libro con ese título.");
                return false;
            }

            Libro nuevoLibro = new Libro(titulo, autor, siguienteId++);
            libros.Add(nuevoLibro);
            Console.WriteLine("Libro registrado exitosamente.");
            return true;
        }

        public bool PrestarLibro(string titulo, string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                Console.WriteLine("Debe ingresar un nombre de usuario.");
                return false;
            }

            Libro libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (libro == null)
            {
                Console.WriteLine("El libro no existe.");
                return false;
            }

            if (!libro.Disponible)
            {
                Console.WriteLine("El libro no está disponible.");
                return false;
            }

            libro.Disponible = false;
            prestamos[libro.Id] = nombreUsuario;
            Console.WriteLine($"Libro '{libro.Titulo}' prestado a {nombreUsuario}.");
            return true;
        }

        public void MostrarLibrosDisponibles()
        {
            var disponibles = libros.Where(l => l.Disponible).ToList();

            Console.WriteLine("\nLibros disponibles:");
            if (!disponibles.Any())
            {
                Console.WriteLine("No hay libros disponibles.");
            }
            else
            {
                foreach (var libro in disponibles)
                {
                    Console.WriteLine($"- {libro.Titulo} por {libro.Autor} (ID: {libro.Id})");
                }
            }
        }

        public void MostrarPrestamos()
        {
            Console.WriteLine("\nPréstamos realizados:");
            if (!prestamos.Any())
            {
                Console.WriteLine("No hay préstamos registrados.");
                return;
            }

            foreach (var entrada in prestamos)
            {
                var libro = libros.FirstOrDefault(l => l.Id == entrada.Key);
                if (libro != null)
                {
                    Console.WriteLine($"- '{libro.Titulo}' fue prestado a {entrada.Value}");
                }
            }
        }
    }
}