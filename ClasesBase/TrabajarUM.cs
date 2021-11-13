using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarUM
    {
        public Unidad_Medida TraerUM()
        {
            Unidad_Medida oUnidad_Medida = new Unidad_Medida();
            oUnidad_Medida.Um_Descrip = "";
            oUnidad_Medida.Um_Abrev = "";
            return oUnidad_Medida;
        }

        //GUARDA UM EN BD
        public static void add_UM(Unidad_Medida um)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_UM";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descripcion", um.Um_Descrip);
            cmd.Parameters.AddWithValue("@abreviatura", um.Um_Abrev);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //MODIFICA UM EN BD
        public static void edit_UM(Unidad_Medida um)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_UM";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idUM", um.Um_Id);
            cmd.Parameters.AddWithValue("@descripcion", um.Um_Descrip);
            cmd.Parameters.AddWithValue("@abreviatura", um.Um_Abrev);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ELIMINAR UM DE LA BD
        public static DataTable delete_UM(int um_ID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_UM";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@UM_ID", um_ID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }

        //TRAE TODAS LAS UM DE LA BD
        public static DataTable traerUM()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_UM";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }


        //Creando la colección
        public ObservableCollection<Unidad_Medida> TraerUMColeccion()
        {
            DataTable dt = traerUM();

            ObservableCollection<Unidad_Medida> listaUM = new ObservableCollection<Unidad_Medida>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Unidad_Medida UM = new Unidad_Medida();
                UM.Um_Id = Convert.ToInt32(dt.Rows[i]["UM_id"]);
                UM.Um_Descrip = dt.Rows[i]["UM_descripcion"].ToString();
                UM.Um_Abrev = dt.Rows[i]["UM_abreviatura"].ToString();

                listaUM.Add(UM);
            }
            return listaUM;
        }

        //Traer una sola UM por ID
        public static Unidad_Medida obtener_UM(int UMid)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_UM";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idUM", UMid);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Unidad_Medida UM = new Unidad_Medida();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                UM.Um_Id = (int)row[0];
                UM.Um_Descrip = (string)row[1];
                UM.Um_Abrev = (string)row[2];
            }

            return UM;
        }
    }
}
