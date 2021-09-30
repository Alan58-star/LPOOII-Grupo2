using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarClientes
    {
        public Cliente TraerCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.Cli_Apellido = "";
            oCliente.Cli_Nombre = "";
            oCliente.Cli_Telefono = "";
            return oCliente;
        }

        //GUARDA CLIENTE EN BD
        public static void add_cliente(Cliente cli)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_cliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@apellido", cli.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre", cli.Cli_Nombre);
            cmd.Parameters.AddWithValue("@domicilio", cli.Cli_Domicilio);
            cmd.Parameters.AddWithValue("@tel", cli.Cli_Telefono);
            cmd.Parameters.AddWithValue("@email", cli.Cli_Email);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

    }
}
