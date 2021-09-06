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

namespace CuartaClase
{
    public partial class frmAgregarPersona : Form
    {
        public frmAgregarPersona()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Inyeccion SQL
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8DIVAMC;Initial Catalog=ProgramacionDB;Integrated Security=True");
            try
            {
                
                connection.Open();
                SqlCommand command = new
                    SqlCommand(
                    "INSERT INTO Personas VALUES ('"+ txtNombres.Text+ "','" + txtApellidos.Text +"', '1988-04-05','2020-05-04')"
                    , connection);

                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Registro Satisfactorio");
                this.Close();
            }
            catch (Exception)
            {
                connection.Close();
                MessageBox.Show("Error, Comunicarse con el administrador");
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-8DIVAMC;Initial Catalog=ProgramacionDB;Integrated Security=True");
            try
            {

                connection.Open();
                SqlCommand command = new SqlCommand("USP_InsertarPersonas", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                SqlParameter parameter1 = new SqlParameter();                
                parameter1.ParameterName = "@Nombres";
                parameter1.SqlDbType = SqlDbType.VarChar;
                parameter1.Value = txtNombres.Text;

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@Apellidos";
                parameter2.SqlDbType = SqlDbType.VarChar;
                parameter2.Value = txtApellidos.Text;

                SqlParameter parameter3 = new SqlParameter();
                parameter3.ParameterName = "@FechaNacimiento";
                parameter3.SqlDbType = SqlDbType.DateTime;
                parameter3.Value = dtpFechaIngreso.Value;

                SqlParameter parameter4 = new SqlParameter();
                parameter4.ParameterName = "@FechaIngreso";
                parameter4.SqlDbType = SqlDbType.DateTime;
                parameter4.Value = dtpFechaIngreso.Value;

                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                command.Parameters.Add(parameter3);
                command.Parameters.Add(parameter4);


                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Registro Satisfactorio");
                this.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("Error, Comunicarse con el administrador");
            }
        }
    }
}