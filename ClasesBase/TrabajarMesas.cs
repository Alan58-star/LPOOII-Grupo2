using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarMesas
    {
        //GUARDA ARTICULO EN BD
        public static void add_mesa(Mesa mesa)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_mesa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@posicion", mesa.Mesa_Posicion);
            cmd.Parameters.AddWithValue("@estado", mesa.Mesa_Estado);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //TRAE TODOS LAS MESAS
        public static DataTable traerMesas()
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
        //TRAE TODOS LAS MESAS HABILITADAS
        public static DataTable traerMesasHabilitadas()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_mesas_habilitadas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }

        public static void edit_mesa(Mesa mesa)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_mesa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idmesa", mesa.Mesa_Id);
            cmd.Parameters.AddWithValue("@posicion", mesa.Mesa_Posicion);
            cmd.Parameters.AddWithValue("@estado", mesa.Mesa_Estado);
            
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

         //TRAER UN SOLO ARTICULO POR ID
        public static Mesa obtener_mesa(int idmesa)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_mesa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idmesa", idmesa);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Mesa mesa = new Mesa();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                mesa.Mesa_Id = (int)row[0];
                mesa.Mesa_Posicion = (int)row[1];
                mesa.Mesa_Estado = (string)row[2];



            }
            return mesa;
        }
        public static ObservableCollection<Mesa> traerMesasColeccion()
        {
            DataTable dt = traerMesas();

            ObservableCollection<Mesa> listaMesas = new ObservableCollection<Mesa>();

             for (int i = 0; i < dt.Rows.Count; i++)
            {
                Mesa mesa = new Mesa();
                mesa.Mesa_Id = Convert.ToInt32(dt.Rows[i]["mesa_id"]);
                mesa.Mesa_Posicion = Convert.ToInt32(dt.Rows[i]["mesa_posicion"]);
                mesa.Mesa_Estado = dt.Rows[i]["mesa_estado"].ToString();
                listaMesas.Add(mesa);
            }

            return listaMesas;
        }

    }
}
