using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_RecuperacionFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombreCliente.Text;
            string tipoCliente = txtTipoCliente.Text;
            string nombreRuta = txtNombreRuta.Text;
            int cantidadPersonas = Convert.ToInt32(txtCantidadPersonas.Text);

            // Obtener el ID del cliente
            int clienteID = ObtenerClienteID(nombreCliente);

            // Obtener el ID de la ruta turística
            int rutaTuristicaID = ObtenerRutaTuristicaID(nombreRuta);

            // Calcular el monto total
            double precioBase = ObtenerPrecioBase(nombreRuta);
            double descuento = CalcularDescuento(cantidadPersonas);
            double montoTotal = precioBase * cantidadPersonas * (1 - descuento);

            // Registrar la venta de boletos
            RegistrarVenta(clienteID, rutaTuristicaID, cantidadPersonas, montoTotal);
        }

    private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {

        }
        private int ObtenerClienteID(string nombreCliente)
        {
            int clienteID = 0;
            string connectionString = "Data Source=LAPTOP-PK2H1RHP;Initial Catalog=BD_RUTASTURISTICAS;Integrated Security=True";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "SELECT ID FROM Clientes WHERE Nombre = @Nombre";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombreCliente);

                try
                {
                    conexion.Open();
                    clienteID = (int)comando.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener ID del cliente: " + ex.Message);
                }
            }

            return clienteID;
        }
        private int ObtenerRutaTuristicaID(string nombreRuta)
        {
            int rutaTuristicaID = 0;
            string connectionString = "Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;Integrated Security=True";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "SELECT ID FROM RutasTuristicas WHERE Nombre = @Nombre";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombreRuta);

                try
                {
                    conexion.Open();
                    rutaTuristicaID = (int)comando.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener ID de la ruta turística: " + ex.Message);
                }
            }

            return rutaTuristicaID;
        }
        private double ObtenerPrecioBase(string nombreRuta)
        {
            double precioBase = 0;
            string connectionString = "Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;Integrated Security=True";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "SELECT PrecioBase FROM RutasTuristicas WHERE Nombre = @Nombre";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombreRuta);

                try
                {
                    conexion.Open();
                    precioBase = Convert.ToDouble(comando.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el precio base: " + ex.Message);
                }
            }

            return precioBase;
        }
        private double CalcularDescuento(int cantidadPersonas)
        {
            if (cantidadPersonas == 1)
                return 0;
            else if (cantidadPersonas >= 2 && cantidadPersonas <= 7)
                return 0.08;
            else if (cantidadPersonas >= 8 && cantidadPersonas <= 16)
                return 0.13;
            else
                return 0.15;
        }

        private void RegistrarVenta(int clienteID, int rutaTuristicaID, int cantidadPersonas, double montoTotal)
        {
            string connectionString = "Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DE_DATOS;Integrated Security=True";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO VentasBoletos (ClienteID, RutaTuristicaID, CantidadPersonas, MontoTotal) VALUES (@ClienteID, @RutaTuristicaID, @CantidadPersonas, @MontoTotal)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@ClienteID", clienteID);
                comando.Parameters.AddWithValue("@RutaTuristicaID", rutaTuristicaID);
                comando.Parameters.AddWithValue("@CantidadPersonas", cantidadPersonas);
                comando.Parameters.AddWithValue("@MontoTotal", montoTotal);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Venta registrada correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar la venta: " + ex.Message);
                }
            }
        }

        private void MostrarClientes()
        {
         
        }

    }
}
