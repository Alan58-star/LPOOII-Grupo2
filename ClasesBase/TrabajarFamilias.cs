using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarFamilias
    {
        public Familia TraerFamilia()
        {
            Familia oFamilia = new Familia();
            oFamilia.Fam_Descrip = "";
            return oFamilia;
        }

        //GUARDA FAMILIA EN BD
        public static void add_familia(Familia fam)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_familia";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descripcion", fam.Fam_Descrip);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //MODIFICA FAMILIA EN BD
        public static void edit_familia(Familia familia)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_familia";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idfamilia", familia.Fam_Id);
            cmd.Parameters.AddWithValue("@descripcion", familia.Fam_Descrip);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ELIMINAR FAMILIA DE LA BD
        public static DataTable delete_familia(int familia_ID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_familia";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@familia_ID", familia_ID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }

        //TRAE TODAS LAS FAMILIAS DE LA BD
        public static DataTable traerFamilias()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_familias";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }


        //Creando la colección
        public ObservableCollection<Familia> TraerFamiliasColeccion()
        {
            DataTable dt = traerFamilias();

            ObservableCollection<Familia> listaFamilias = new ObservableCollection<Familia>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Familia fam = new Familia();
                fam.Fam_Id = Convert.ToInt32(dt.Rows[i]["fam_id"]);
                fam.Fam_Descrip = dt.Rows[i]["fam_descripcion"].ToString();

                listaFamilias.Add(fam);
            }
            return listaFamilias;
        }

        //Traer una sola familia por ID
        public static Familia obtener_familia(int fid)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_familia";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idfamilia", fid);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Familia fam = new Familia();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                fam.Fam_Id = (int)row[0];
                fam.Fam_Descrip = (string)row[1];
            }

            return fam;
        }
    }
}
