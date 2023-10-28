using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Libro
    {
        //Campos estaticos
        public static int CantidadLibros=0;
        public static int CantidadCopias=0;

        //Atributos de la clase

        private string _isbn;
        private string _titulo;
        private string _autor;
        private bool _estado;
        private int _copiasDisponibles;
        private int _copiasPrestadas;

        public string ISBN
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int Copias
        {
            get { return _copiasDisponibles; }
            set { _copiasDisponibles = value; }
        }

        public int CopiasPrestadas
        {
            get { return _copiasPrestadas; }
            set { _copiasPrestadas = value; }
        }

       

        //Constructores
        public Libro()
        {

        }

        public Libro(string isbn, string titulo, string autor, bool estado, int copias, int copiasPrestadas)
        {
            _isbn = isbn;
            _titulo = titulo;
            _autor = autor;
            _estado = estado;
            _copiasDisponibles = copias;
            _copiasPrestadas = copiasPrestadas;
            CantidadLibros++;
            CantidadCopias += copias;
        }

        //Metodos

        public bool Prestamo() 
        {
            if (_copiasDisponibles > 0)
            {
                _copiasPrestadas++;
                _copiasDisponibles--;
                return true;

            }
            return false;
        }

        public bool Devolucion()
        {
            if (_copiasPrestadas > 0)
            {
                _copiasPrestadas--;
                _copiasDisponibles++;
                return true;
            }
            return false;
        }

        public bool Inactivar()
        {
            if (_copiasPrestadas == 0)
            {
                _estado = false;
                return true;
            }
            return false;
        }

        public void MostrarLibro(bool estado)
        {
            if (_estado == estado)
            {
                Console.WriteLine("ISBN:" + _isbn);
                Console.WriteLine("Titulo:" + _titulo);
                Console.WriteLine("Autor:" + _autor);
                Console.WriteLine("Estado: " + _estado);
                Console.WriteLine("Copias Disponibles: " + _copiasDisponibles);
                Console.WriteLine("Copias Prestadas: " + _copiasPrestadas);
            }
        }

        public void MostrarLibro(string isbn)
        {
            if (_isbn == isbn)
            {
                Console.WriteLine("ISBN:" + _isbn);
                Console.WriteLine("Titulo:" + _titulo);
                Console.WriteLine("Autor:" + _autor);
                Console.WriteLine("Estado: " + _estado);
                Console.WriteLine("Copias Disponibles: " + _copiasDisponibles);
                Console.WriteLine("Copias Prestadas: " + _copiasPrestadas);
            }
            else
            {
                Console.WriteLine("No se encontro el Libro con ese ISBN a buscar");
            }
        }

        //Metodo Estatico
        public static void Informativo()
        {
            Console.WriteLine("Total de Libros:" + CantidadLibros);
            Console.WriteLine("Total de Copias:" + CantidadCopias);
        }


    }
}
