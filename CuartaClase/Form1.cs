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
using CapaNegocio;

namespace CuartaClase
{
    public partial class Form1 : Form
    {
        List<Persona> personas = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarPersona frmAgregar = new frmAgregarPersona();
            frmAgregar.ShowDialog();
            BuscarStore();


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            BuscarStore();

        }
        private void Buscar()
        {
            //Connection=>Command=>Adapter=>DataTable=>Grilla

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8DIVAMC;Initial Catalog=ProgramacionDB;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from personas", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtPersonas = new DataTable();
            dataAdapter.Fill(dtPersonas);
            connection.Close();

            dgvPersonas.DataSource = dtPersonas;
        }

        private void BuscarStore()
        {
            //Connection=>Command=>Adapter=>DataTable=>Grilla

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8DIVAMC;Initial Catalog=ProgramacionDB;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("USP_BuscarPersonas", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@Nombres";
            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter1.Value = txtNombres.Text;

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@Apellidos";
            parameter2.SqlDbType = SqlDbType.VarChar;
            parameter2.Value = txtApellidos.Text;

            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);




            DataTable dtPersonas = new DataTable();
            dataAdapter.Fill(dtPersonas);
            connection.Close();
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = dtPersonas;
        }
    }
}
