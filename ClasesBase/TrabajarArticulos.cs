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
            cmd.Parameters.AddWithValue("@cat", art.Cat_Id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ACTUALIZA ARTICULO EN BD
        public static void edit_articulo(Articulo art)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_articulo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idarticulo", art.Art_Id);
            cmd.Parameters.AddWithValue("@descrip", art.Art_Descrip);
            cmd.Parameters.AddWithValue("@precio", art.Art_Precio);
            cmd.Parameters.AddWithValue("@stock", art.Art_Manejo_Stock);
            cmd.Parameters.AddWithValue("@fam", art.Fam_Id);
            cmd.Parameters.AddWithValue("@UM", art.Um_Id);
            cmd.Parameters.AddWithValue("@cat", art.Cat_Id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ELIMINAR ARTICULO DE LA BD
        public static DataTable delete_articulo(int artID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_articulo";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@aid", artID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

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

        //TRAER UN SOLO ARTICULO POR ID
        public static Articulo obtener_articulo(int idarticulo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_articulo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idarticulo", idarticulo);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Articulo art1 = new Articulo();
            Unidad_Medida um = new Unidad_Medida();
            Categoria cat = new Categoria();
            Familia fam = new Familia();

            if (dt.Rows.Count > 0) {
                DataRow row = dt.Rows[0];
                art1.Art_Id = (int)row[0];
                art1.Art_Descrip = (string)row[1];
                um.Um_Abrev = (string)row[2];
                art1.Art_Precio = (decimal)row[3];
                art1.Art_Manejo_Stock = (bool)row[4];
                fam.Fam_Descrip = (string)row[5];
                um.Um_Id = (int)row[6];
                cat.Cat_Id = (int)row[7];
                cat.Cat_Descrip = (string)row[8];
                fam.Fam_Id =(int)row[9];
                um.Um_Descrip = (string)row[10];

                art1.Unidad_Medida = um;
                art1.Familia = fam;
                art1.Categoria = cat;
            }
        
            
            return art1;
        }

        //CARGA CATEGORIA EN COMBO BOX
        public static DataTable list_categorias()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_categorias";
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

        //Creando la colección
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
                
                Categoria cat = new Categoria();
                cat.Cat_Id=Convert.ToInt32(dt.Rows[i]["cat_id"]);
                cat.Cat_Descrip = dt.Rows[i]["cat_descripcion"].ToString();
                art.Categoria = cat;

                Unidad_Medida Um = new Unidad_Medida();
                Um.Um_Id=Convert.ToInt32(dt.Rows[i]["UM_id"]);
                Um.Um_Descrip=dt.Rows[i]["UM_descripcion"].ToString();
                Um.Um_Abrev = dt.Rows[i]["UM_abreviatura"].ToString();
                art.Unidad_Medida = Um;

                Familia fam = new Familia();
                fam.Fam_Id = Convert.ToInt32(dt.Rows[i]["fam_id"]);
                fam.Fam_Descrip = dt.Rows[i]["fam_descripcion"].ToString();
                art.Familia = fam;

                listaArticulos.Add(art);
            }
            
            return listaArticulos;
        }

    }
        
}
