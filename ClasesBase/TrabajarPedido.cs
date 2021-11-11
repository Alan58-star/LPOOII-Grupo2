using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarPedido
    {

        //GUARDA PEDIDO EN BD
        public static void add_pedido(Pedido pedido)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_pedido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@usuario", pedido.Usr_Id);
            cmd.Parameters.AddWithValue("@mesa", pedido.Mesa_Id);
            cmd.Parameters.AddWithValue("@cliente", pedido.Cli_Id);
            cmd.Parameters.AddWithValue("@fecha_emision", pedido.Ped_Fecha_Emision);
            cmd.Parameters.AddWithValue("@fecha_entrega", pedido.Ped_Fecha_Entrega);
            cmd.Parameters.AddWithValue("@comensales", pedido.Ped_Comensales);
            cmd.Parameters.AddWithValue("@facturado", pedido.Ped_Facturado);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public static void edit_pedido(Boolean facturado, int idpedido)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_pedidoFacturado";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idpedido", idpedido);
            cmd.Parameters.AddWithValue("@facturado", facturado);
         

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //TRAER UN SOLO PEDIDO POR ID
        public static Pedido obtener_pedido(int idpedido)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_pedido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idarticulo", idpedido);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Pedido ped1 = new Pedido();
            Mesa mesa = new Mesa();
            Usuario usu = new Usuario();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                ped1.Ped_Id = (int)row[0];
                ped1.Ped_Fecha_Emision = (DateTime)row[1];
                mesa.Mesa_Id = (int)row[5];
                usu.Usr_NombreUsuario = (string)row[8];
                ped1.Usuario = usu;
                ped1.Mesa = mesa;

            }


            return ped1;
        }
        //ELIMINAR PEDIDO DE LA BD
        public static DataTable delete_pedido(int pedido_ID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_pedido";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@pedido_id", pedido_ID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }


        //TRAE TODOS LOS PEDIDOS
        public static DataTable traer_pedidos()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_pedidos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }


        //CARGA MESAS EN COMBO BOX
        public static DataTable list_mesas()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_mesas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }

        //CARGA CLIENTE EN COMBO BOX
        public static DataTable list_clientes()
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


        public ObservableCollection<Pedido> TraerPedidosColeccion()
        {
            DataTable dt = traer_pedidos();

            ObservableCollection<Pedido> listaPedido = new ObservableCollection<Pedido>();
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Pedido ped = new Pedido();
                ped.Ped_Id = Convert.ToInt32(dt.Rows[i]["ped_id"]);
                ped.Ped_Fecha_Emision = Convert.ToDateTime(dt.Rows[i]["ped_fechaEmision"]);
                ped.Ped_Fecha_Entrega = Convert.ToDateTime(dt.Rows[i]["ped_fechaEntrega"]);
                ped.Ped_Facturado = Convert.ToBoolean(dt.Rows[i]["ped_facturado"]);
                ped.Ped_Comensales = Convert.ToInt32(dt.Rows[i]["ped_comensales"]);

                Usuario usu = new Usuario();
                usu.Usr_Id = Convert.ToInt32(dt.Rows[i]["usu_id"]);
                usu.Usr_NombreUsuario = dt.Rows[i]["usu_usuario"].ToString();
                usu.Usr_ApellidoNombre = dt.Rows[i]["usu_apnombre"].ToString();
                usu.Rol_Id = Convert.ToInt32(dt.Rows[i]["rol_id"]);

                Cliente cli = new Cliente();
                cli.Cli_Id = Convert.ToInt32(dt.Rows[i]["cli_id"]);
                cli.Cli_Apellido = dt.Rows[i]["cli_apellido"].ToString();
                cli.Cli_Nombre = dt.Rows[i]["cli_nombre"].ToString();
                cli.Cli_Domicilio = dt.Rows[i]["cli_domicilio"].ToString();
                cli.Cli_Telefono = dt.Rows[i]["cli_telefono"].ToString();
                cli.Cli_Email = dt.Rows[i]["cli_email"].ToString();

                Mesa mesa = new Mesa();                
                mesa.Mesa_Id = Convert.ToInt32(dt.Rows[i]["mesa_id"]);
                mesa.Mesa_Posicion = Convert.ToInt32(dt.Rows[i]["mesa_posicion"]);
                mesa.Mesa_Estado = dt.Rows[i]["mesa_estado"].ToString();

                ped.Usuario = usu;
                ped.Cliente = cli;
                ped.Mesa = mesa;
                
                listaPedido.Add(ped);
            }

            return listaPedido;
        }

    }
}
