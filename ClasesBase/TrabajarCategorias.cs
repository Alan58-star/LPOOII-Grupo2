using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarCategorias
    {
        public Categoria TraerCategoria()
        {
            Categoria oCategoria = new Categoria();
            oCategoria.Cat_Descrip = "";
            return oCategoria;
        }

        //GUARDA CATEGORIA EN BD
        public static void add_categoria(Categoria cat)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_categoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descripcion", cat.Cat_Descrip);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //MODIFICA CATEGORIA EN BD
        public static void edit_categoria(Categoria cat)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_categoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idcategoria", cat.Cat_Id);
            cmd.Parameters.AddWithValue("@descripcion", cat.Cat_Descrip);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ELIMINAR CATEGORIA DE LA BD
        public static DataTable delete_categoria(int categoria_ID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_categoria";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@categoria_ID", categoria_ID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }

        //TRAE TODAS LAS CATEGORIAS DE LA BD
        public static DataTable traerCategorias()
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


        //Creando la colección
        public ObservableCollection<Categoria> TraerCategoriasColeccion()
        {
            DataTable dt = traerCategorias();

            ObservableCollection<Categoria> listaCategorias = new ObservableCollection<Categoria>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Categoria cat = new Categoria();
                cat.Cat_Id = Convert.ToInt32(dt.Rows[i]["cat_id"]);
                cat.Cat_Descrip = dt.Rows[i]["cat_descripcion"].ToString();

                listaCategorias.Add(cat);
            }
            return listaCategorias;
        }

        //Traer una sola categoria por ID
        public static Categoria obtener_categoria(int cid)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_categoria";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idcategoria", cid);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Categoria cat = new Categoria();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cat.Cat_Id = (int)row[0];
                cat.Cat_Descrip = (string)row[1];
            }

            return cat;
        }

    }
}
