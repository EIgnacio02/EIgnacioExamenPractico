using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Por favor seleccione una opcion");
            Console.WriteLine("1.- Mostrar libros");
            Console.WriteLine("2.- Mostrar libro por Id");
            Console.WriteLine("3.- Agregar libro");
            Console.WriteLine("4.- Actualiza libro");
            Console.WriteLine("5.- Elimina libro");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    Libro.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Libro.GetAllById();
                    Console.ReadKey();
                    break;
                case 3:
                    Libro.Add();
                    Console.ReadKey();
                    break;
                case 4:
                    Libro.Update();
                    Console.ReadKey();
                    break;
                case 5:
                    Libro.Delete();
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Ingresaste una opcion no valida");
                    break;

            }
        }
    }
}
