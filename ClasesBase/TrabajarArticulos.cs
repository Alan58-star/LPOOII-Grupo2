using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarArticulos
    {
        public Articulo TraerArticulo()
        {
            Articulo oArticulo = new Articulo();
            //oArticulo.Art_Id = ;
            oArticulo.Art_Precio = 0;
            oArticulo.Art_Descrip = "";
            return oArticulo;
        }

        //GUARDA ARTICULO EN BD
        public static void add_articulo(Articulo art)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_articulo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descrip", art.Art_Descrip);
            cmd.Parameters.AddWithValue("@precio", art.Art_Precio);
            cmd.Parameters.AddWithValue("@stock", art.Art_Manejo_Stock);
            cmd.Parameters.AddWithValue("@fam", art.Fam_Id);
            cmd.Parameters.AddWithValue("@UM", art.Um_Id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //TRAE TODOS LOS ARTICULOS
        public DataTable traerArticulos() 
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_articulos";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }
    }
        
}
