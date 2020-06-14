using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Videoclub_Herencia
{
  internal class Alquiler
  {
    //atributos
    private int numeroAlquiler;

    private DateTime fecha;
    private double monto;
    private Cliente cliente;
    private Pelicula pelicula;

    //propiedades

    public DateTime Fecha { get => fecha; set => fecha = value; }
    public double Monto { get => monto; set => monto = value; }
    internal Cliente Cliente { get => cliente; set => cliente = value; }
    internal Pelicula Pelicula { get => pelicula; set => pelicula = value; }
    public int NumeroAlquiler { get => numeroAlquiler; set => numeroAlquiler = value; }

    //constructores
    public Alquiler()
    {
      Monto = NumeroAlquiler = 0;
      Fecha = DateTime.Today;
      Cliente = null;
      Pelicula = null;
    }

    public Alquiler(int numeroAlquiler, DateTime fecha, double monto, Cliente cliente, Pelicula pelicula)
    {
      NumeroAlquiler = numeroAlquiler;
      Fecha = fecha;
      Monto = monto;
      Cliente = cliente;
      Pelicula = pelicula;
    }

    //metodos
    public string GetDatosAlquiler()
    {
      return
        $"Datos del Alquiler:\n" +
        $"Numero: {NumeroAlquiler}\n" +
        $"Fecha: {Fecha.ToShortDateString()}\n" +
        $"Monto: ${Monto}\n\n" +
        $"{Cliente.GetDatosCliente()}\n\n" +
        $"{Pelicula.GetDatosPelicula()}";
    }
  }
}