using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

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
        public static DataTable traerArticulos() 
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


        //CARGA FAMILIA EN COMBO BOX
        public static DataTable list_familias()
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


        //CARGA UM EN COMBO BOX
        public static DataTable list_UM()
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

        public ObservableCollection<Articulo> TraerArticulosColeccion()
        {
            DataTable dt = traerArticulos();

            ObservableCollection<Articulo> listaArticulos = new ObservableCollection<Articulo>();

            Familia oFamilia = new Familia(1,"Bebidas");
            Categoria oCategoria = new Categoria(1, "si");
            Unidad_Medida oUM = new Unidad_Medida(1, "Litros", "L");

            //listaArticulos.Add(new Articulo(1, "descripcion", 1, 2, 450, true, oFamilia, oCategoria, oUM));
            //listaArticulos.Add(new Articulo(2, "descripcion", 1, 2, 430, true, oFamilia, oCategoria, oUM));
            //listaArticulos.Add(new Articulo(3, "descripcion", 1, 2, 420, true, oFamilia, oCategoria, oUM));
            //listaArticulos.Add(new Articulo(4, "descripcion", 1, 2, 410, true, oFamilia, oCategoria, oUM));
            //listaArticulos.Add(new Articulo(5, "descripcion", 1, 2, 470, true, oFamilia, oCategoria, oUM));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Articulo art = new Articulo();
                art.Art_Id = Convert.ToInt32(dt.Rows[i]["art_id"]);
                art.Art_Descrip = dt.Rows[i]["art_descripcion"].ToString();
                art.Art_Precio = Convert.ToDecimal(dt.Rows[i]["art_precio"]);
                art.Art_Manejo_Stock = Convert.ToBoolean(dt.Rows[i]["art_stock"]);
                art.Fam_Id = Convert.ToInt32(dt.Rows[i]["fam_id"]);
                art.Um_Id = Convert.ToInt32(dt.Rows[i]["UM_id"]);

                listaArticulos.Add(art);
            }
            
            return listaArticulos;
        }

    }
        
}
