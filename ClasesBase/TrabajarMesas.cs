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
