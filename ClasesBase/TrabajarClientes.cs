using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

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

        //MODIFICA CLIENTE EN BD
        public static void edit_cliente(Cliente cliente)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_cliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idcliente", cliente.Cli_Id);
            cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
            cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
            cmd.Parameters.AddWithValue("@domicilio", cliente.Cli_Domicilio);
            cmd.Parameters.AddWithValue("@telefono", cliente.Cli_Telefono);
            cmd.Parameters.AddWithValue("@email", cliente.Cli_Email);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ELIMINAR CLIENTE DE LA BD
        public static DataTable delete_cliente(int cliente_ID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_cliente";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@cliente_ID", cliente_ID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }

        //TRAE TODOS LOS CLIENTES DE LA BD
        public static DataTable traerClientes()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_clientes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }


        //Creando la colección
        public ObservableCollection<Cliente> TraerClientesColeccion()
        {
            DataTable dt = traerClientes();

            ObservableCollection<Cliente> listaClientes = new ObservableCollection<Cliente>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cliente cli = new Cliente();
                cli.Cli_Id = Convert.ToInt32(dt.Rows[i]["cli_id"]);
                cli.Cli_Nombre = dt.Rows[i]["cli_nombre"].ToString();
                cli.Cli_Apellido = dt.Rows[i]["cli_apellido"].ToString();
                cli.Cli_Domicilio = dt.Rows[i]["cli_domicilio"].ToString();
                cli.Cli_Telefono = dt.Rows[i]["cli_telefono"].ToString();
                cli.Cli_Email = dt.Rows[i]["cli_email"].ToString();

                listaClientes.Add(cli);
            }
            return listaClientes;
        }

        //Traer un solo cliente por ID
        public static Cliente obtener_cliente(int cid)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_cliente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idcliente", cid);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Cliente cli = new Cliente();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cli.Cli_Id = (int)row[0];
                cli.Cli_Apellido = (string)row[1];
                cli.Cli_Nombre = (string)row[2];
                cli.Cli_Domicilio = (string)row[3];
                cli.Cli_Telefono = (string)row[4];
                cli.Cli_Email = (string)row[5];
            }

            return cli;
        }


    }
}
