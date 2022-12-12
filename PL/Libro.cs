using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Libro
    {
        public static void Add()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingresa los datos del libro");

            Console.WriteLine("Nombre");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Fecha de publicacion");
            libro.FechaPublicacion   = Console.ReadLine();

            Console.WriteLine("Edicion");
            libro.Edicion = Console.ReadLine();

            libro.Autor = new ML.Autor();
            Console.WriteLine("Id del Autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            libro.Editorial = new ML.Editorial();
            Console.WriteLine("Id de la Editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            libro.Genero = new ML.Genero();
            Console.WriteLine("Id del Genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                //result.Message = "Se ingresaron los datos correctamente";
                Console.WriteLine(result.Message);
            }

        }

        public static void Update()
        {
            ML.Libro libro = new ML.Libro();

            Console.WriteLine("Ingresa el Id del libro del cual quieras modificar");

            Console.WriteLine("ID libro");
            libro.IdLibro = int.Parse(Console.ReadLine());

            Console.WriteLine("Nombre");
            libro.Nombre = Console.ReadLine();

            Console.WriteLine("Numero de paginas");
            libro.NumeroPaginas = int.Parse(Console.ReadLine());

            Console.WriteLine("Fecha de publicacion");
            libro.FechaPublicacion = Console.ReadLine();

            Console.WriteLine("Edicion");
            libro.Edicion = Console.ReadLine();

            libro.Autor = new ML.Autor();
            Console.WriteLine("Id del Autor");
            libro.Autor.IdAutor = int.Parse(Console.ReadLine());

            libro.Editorial = new ML.Editorial();
            Console.WriteLine("Id de la Editorial");
            libro.Editorial.IdEditorial = int.Parse(Console.ReadLine());

            libro.Genero = new ML.Genero();
            Console.WriteLine("Id del Genero");
            libro.Genero.IdGenero = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Update(libro);

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }

        }
        public static void Delete()
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("Ingresa el Id del libro para ELIMINAR");
            libro.IdLibro = int.Parse(Console.ReadLine());

            ML.Result result = BL.Libro.Delete(libro.IdLibro);

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
        }


        public static void GetAll()
        {
            ML.Result result=BL.Libro.GetAll();
            if (result.Correct)
            {
                foreach (ML.Libro libro in result.Objects)
                {
                    Console.WriteLine("El ID es: " + libro.IdLibro);
                    Console.WriteLine("El nombre es: " + libro.Nombre);
                    Console.WriteLine("El numero de paginas es: " + libro.NumeroPaginas);
                    Console.WriteLine("Fecha de publicacion: " + libro.FechaPublicacion);
                    Console.WriteLine("La edicion es: " + libro.Edicion);
                    Console.WriteLine("El Id del autor es: " + libro.Autor.IdAutor);
                    Console.WriteLine("La Id de la editorial es: " + libro.Editorial.IdEditorial);
                    Console.WriteLine("El Id del genero es: " + libro.Genero.IdGenero);
                    Console.WriteLine("-----------------------------------");
                }
            }

        }


        public static void GetAllById()
        {
            ML.Libro libro = new ML.Libro();
            Console.WriteLine("Ingresa el Id del libro");
            libro.IdLibro = int.Parse(Console.ReadLine());
            ML.Result result = BL.Libro.GetAllById(libro.IdLibro);
            if (result.Correct)
            {

                libro =(ML.Libro)result.Object;
                Console.WriteLine("El ID es: " + libro.IdLibro);
                Console.WriteLine("El nombre es: " + libro.Nombre);
                Console.WriteLine("El numero de paginas es: " + libro.NumeroPaginas);
                Console.WriteLine("Fecha de publicacion: " + libro.FechaPublicacion);
                Console.WriteLine("La edicion es: " + libro.Edicion);
                Console.WriteLine("El Id del autor es: " + libro.Autor.IdAutor);
                Console.WriteLine("La Id de la editorial es: " + libro.Editorial.IdEditorial);
                Console.WriteLine("El Id del genero es: " + libro.Genero.IdGenero);
                
            }

        }
    }
}
