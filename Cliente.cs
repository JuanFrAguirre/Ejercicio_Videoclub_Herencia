using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Videoclub_Herencia
{
  internal class Cliente
  {
    //atributos
    private string nombre;

    private int dni, sexo, codigoSocio;

    //propiedades
    public int DNI { get => dni; set => dni = value; }

    public int Sexo { get => sexo; set => sexo = value; }
    public int CodigoSocio { get => codigoSocio; set => codigoSocio = value; }
    public string Nombre { get => nombre; set => nombre = value; }

    //constructores
    public Cliente()
    {
      Nombre = "";
      DNI = Sexo = CodigoSocio = 0;
    }

    public Cliente(int dni, int sexo, int codigoSocio, string nombre)
    {
      DNI = dni;
      Sexo = sexo;
      CodigoSocio = codigoSocio;
      Nombre = nombre;
    }

    //metodos
    public string GetSexo()
    {
      switch (Sexo)
      {
        case 1: return "Masculino";
        case 2: return "Femenino";
        default: return "Otro";
      }
    }

    public string GetDatosCliente()
    {
      return
        $"Datos del Cliente:\n" +
        $"Nombre: {Nombre}\n" +
        $"DNI: {DNI}\n" +
        $"Sexo: {GetSexo()}\n" +
        $"Codigo de Socio: {CodigoSocio}";
    }
  }
}