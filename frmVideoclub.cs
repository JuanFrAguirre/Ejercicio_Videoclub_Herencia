using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Videoclub_Herencia
{
  public partial class frmVideoclub : Form
  {
    private int totalRegistros, cantTerror, cantFiccion, cantComedia, cantMujeresPeliculasTerror;
    private double recaudacionTotal, recaudacionPromedio, cantSociosVarones;
    private Alquiler alquilerMasCaro;

    public frmVideoclub()
    {
      InitializeComponent();
      GroupBoxRenderer.RenderMatchingApplicationState = false;
      groupBox1.ForeColor = groupBox2.ForeColor = groupBox3.ForeColor = groupBox4.ForeColor = groupBox5.ForeColor = groupBox6.ForeColor = Color.Gold;
      recaudacionTotal = recaudacionPromedio = cantSociosVarones = totalRegistros = cantTerror = cantFiccion = cantComedia = cantMujeresPeliculasTerror = 0;
      alquilerMasCaro = null;
    }

    private void btnRegistrar_Click(object sender, EventArgs e)
    {
      ////////////---variable sexo para radio buttons de cliente
      int sexo = 1;
      if (rdoFem.Checked) sexo = 2;
      if (rdoOtro.Checked) sexo = 3;

      ////////////---instanciacion de clases
      Cliente cliente1 = new Cliente(int.Parse(txtDNI.Text), sexo, int.Parse(txtCodigoSocio.Text), txtNombreCliente.Text);

      Pelicula pelicula1 = new Pelicula(txtTituloPelicula.Text, int.Parse(txtCodigoPelicula.Text), cboGeneroPelicula.SelectedIndex + 1);

      Alquiler alquiler1 = new Alquiler(int.Parse(txtNumAlquiler.Text), dtpFechaAlquiler.Value, double.Parse(txtMontoAlquiler.Text), cliente1, pelicula1);

      ////////////---registros
      totalRegistros++;
      ///---cantidad de peliculas x genero
      if (alquiler1.Pelicula.Genero == 1)
      {
        cantTerror++;
        lblCantTerror.Text = cantTerror.ToString();
        ///cantidad mujeres que alquilaron peliculas de terror
        if (alquiler1.Cliente.Sexo == 2)
        {
          cantMujeresPeliculasTerror++;
          lblCantMujeresTerror.Text = cantMujeresPeliculasTerror.ToString();
        }
      }
      if (alquiler1.Pelicula.Genero == 2) { cantFiccion++; lblCantFiccion.Text = cantFiccion.ToString(); }
      if (alquiler1.Pelicula.Genero == 3) { cantComedia++; lblCantComedia.Text = cantComedia.ToString(); }

      ///---recaudacion promedio
      recaudacionTotal += alquiler1.Monto;
      recaudacionPromedio = recaudacionTotal / totalRegistros;

      lblRecaudacionPromedio.Text = "$ " + Math.Round(recaudacionPromedio, 2).ToString();

      ///---porcentaje de socios varones
      if (alquiler1.Cliente.Sexo == 1)
      {
        cantSociosVarones++;
        lblPorcSociosVarones.Text = Math.Round(((cantSociosVarones * 100) / totalRegistros), 2).ToString() + "%";
      }

      ///---cliente y pelicula del alquiler mas caro
      if (alquilerMasCaro == null || alquiler1.Monto > alquilerMasCaro.Monto) alquilerMasCaro = alquiler1;

      lblNombreClienteMax.Text = alquilerMasCaro.Cliente.Nombre;
      lblCodigoClienteMax.Text = alquilerMasCaro.Cliente.CodigoSocio.ToString();
      lblFechaAlquilerMax.Text = alquilerMasCaro.Fecha.ToShortDateString();
      lblCodigoPeliculaMax.Text = alquilerMasCaro.Pelicula.CodigoPelicula.ToString();
      lblTituloPeliculaMax.Text = alquilerMasCaro.Pelicula.Titulo;
      lblGeneroPeliculaMax.Text = alquilerMasCaro.Pelicula.GetGenero();

      ////////////---mensaje de registro
      MessageBox.Show(alquiler1.GetDatosAlquiler(), "Carga exitosa!", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}