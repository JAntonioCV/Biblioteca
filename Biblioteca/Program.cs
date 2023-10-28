using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Program
    {
        static List<Libro> libros = new List<Libro>();
        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine();
                int opcion = Menu();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine();
                        AgregarLibro();
                        break;

                    case 2:
                        Console.WriteLine();
                        PrestarLibro();
                        break;

                    case 3:
                        Console.WriteLine();
                        DevolverLibro();
                        break;

                    case 4:
                        Console.WriteLine();
                        InactivarLibro();
                        break;

                    case 5:
                        Console.WriteLine();
                        int opcionsubmenu = Submenu();
                        bool estado = false;

                        switch (opcionsubmenu)
                        {
                            case 1:
                                estado = true;
                                break;
                            case 2:
                                estado = false;
                                break;
                            default:
                                Console.WriteLine("Opción Invalida, por favor vuelva a intentarlo");
                                break;
                        }
                        Console.WriteLine();
                        MostrarLibroPorEstado(estado);
                        break;

                    case 6:
                        Console.WriteLine();
                        MostrarLibroPorISBN();
                        break;
                    case 7:
                        Console.WriteLine();
                        Libro.Informativo();
                        break;
                    case 8:
                        salir = true;
                        Console.WriteLine("Gracias por utilizar el programa");
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Opción Invalida, por favor vuelva a intentarlo");
                        break;
                }
            }

        }

        public static void AgregarLibro()
        {
            Console.Write("Ingrese el ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Ingrese el Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingrese el Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Ingrese el Número de copias: ");
            int numCopias = int.Parse(Console.ReadLine());

            Libro libro = new Libro(isbn, titulo, autor, true, numCopias, 0);
            libros.Add(libro);

            Console.WriteLine("Libro Agregado Correctamente");
        }

        public static void PrestarLibro()
        {
            Console.Write("Ingrese el ISBN del libro a prestar: ");
            string isbn = Console.ReadLine();

            Libro libro = libros.Find(x => x.ISBN == isbn);


            if (libro != null)
            {
                if (libro.Estado)
                {
                    if (libro.Prestamo())
                    {
                        Console.WriteLine("Préstamo realizado con exito");
                    }
                    else
                    {
                        Console.WriteLine("No hay copias disponibles para prestar");
                    }
                }
                else
                {
                    Console.WriteLine("No se puede prestar por que el libro se encuentra inactivo");
                }
            }
            else
            {
                Console.WriteLine("No se encontró el libro con ese ISBN");
            }


        }

        public static void DevolverLibro()
        {
            Console.Write("Ingrese el ISBN del libro a devolver: ");
            string isbn = Console.ReadLine();

            Libro libro = libros.Find(x => x.ISBN == isbn);

            if (libro != null)
            {
                if (libro.Devolucion())
                {
                    Console.WriteLine("Devolución realizada Correctamente");
                }
                else
                {
                    Console.WriteLine("Este libro no está prestado actualmente");
                }
            }
            else
            {
                Console.WriteLine("No se encontró el libro con ese ISBN");
            }
        }

        public static void InactivarLibro()
        {
            Console.Write("Ingrese el ISBN del libro a Inactivar: ");
            string isbn = Console.ReadLine();

            Libro libroInactivar = libros.Find(x => x.ISBN == isbn);

            if (libroInactivar != null)
            {
                if (libroInactivar.Inactivar())
                {
                    Console.WriteLine("Libro Inactivado con exito");
                }
                else
                {
                    Console.WriteLine("No se puede Inactivar porque tiene copias prestadas");
                }
            }
            else
            {
                Console.WriteLine("No se encontró el libro con ese ISBN");
            }
        }

        public static void MostrarLibroPorEstado(bool estado)
        {
            foreach (Libro Libro in libros)
            {
                Libro.MostrarLibro(estado);
            }

        }

        public static void MostrarLibroPorISBN()
        {
            Console.Write("Ingrese el ISBN a buscar: ");
            string isbn = Console.ReadLine();

            Libro libro = libros.Find(x => x.ISBN == isbn);

            if (libro != null)
            {
                libro.MostrarLibro(isbn);
            }
            else
            {
                Console.WriteLine("No se encontró el libro con ese ISBN");
            }
        }

        public static int Menu()
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Prestar libro");
            Console.WriteLine("3. Devolver libro");
            Console.WriteLine("4. Inactivar libro");
            Console.WriteLine("5. Mostrar libros por estado");
            Console.WriteLine("6. Mostrar libro por ISBN");
            Console.WriteLine("7. Información general");
            Console.WriteLine("8. Salir");

            Console.Write("Ingrese una opción del menú: ");
            int opcion = int.Parse(Console.ReadLine());

            return opcion;

        }

        public static int Submenu()
        {
            Console.WriteLine("Seleccione el estado:");
            Console.WriteLine("1. Libros Activos");
            Console.WriteLine("2. Libros Inactivos");

            Console.WriteLine("Ingrese una opción del menú: ");
            int opcion = int.Parse(Console.ReadLine());
            return opcion;

        }


    }
}
