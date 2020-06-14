using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Videoclub_Herencia
{
  internal class Pelicula
  {
    //atributos
    private string titulo;

    private int codigoPelicula, genero;

    //propiedades
    public string Titulo { get => titulo; set => titulo = value; }

    public int CodigoPelicula { get => codigoPelicula; set => codigoPelicula = value; }
    public int Genero { get => genero; set => genero = value; }

    //constructores
    public Pelicula()
    {
      Titulo = "";
      CodigoPelicula = Genero = 0;
    }

    public Pelicula(string titulo, int codigoPelicula, int genero)
    {
      this.titulo = titulo;
      this.codigoPelicula = codigoPelicula;
      this.genero = genero;
    }

    //metodos
    public string GetGenero()
    {
      switch (Genero)
      {
        case 1: return "Terror";
        case 2: return "Ficcion";
        default: return "Comedia";
      }
    }

    public string GetDatosPelicula()
    {
      return
        $"Datos de la Pelicula:\n" +
        $"Codigo: {CodigoPelicula}\n" +
        $"Titulo: {Titulo}\n" +
        $"Genero: {GetGenero()}";
    }
  }
}