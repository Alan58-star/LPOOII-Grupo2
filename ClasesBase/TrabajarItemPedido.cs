using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarItemPedido
    {
        //GUARDA ITEM PEDIDO EN BD
        public static void add_item_pedido(Item_Pedido item_pedido)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_item_pedido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@pedido", item_pedido.Ped_Id);
            cmd.Parameters.AddWithValue("@articulo", item_pedido.Art_Id);
            cmd.Parameters.AddWithValue("@precio_art", item_pedido.Item_Ped_Precio);
            cmd.Parameters.AddWithValue("@cantidad", item_pedido.Item_Ped_Cantidad);
            cmd.Parameters.AddWithValue("@importe", item_pedido.Item_Ped_Importe);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ELIMINAR ITEM PEDIDO DE LA BD
        public static DataTable delete_item_pedido(int item_pedido_ID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_item_pedido";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@item_pedido_id", item_pedido_ID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }


        //CARGA ARTICULO EN COMBO BOX
        public static DataTable list_articulos()
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

        //CALCULA EL IMPORTE DEL ITEM PEDIDO
        public static decimal calcular_importe_item(int precio, int cantidad)
        {
            decimal importe_item = precio * cantidad;
            return importe_item;
        }

        public static DataTable traer_items(int id)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            
            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "listar_items_pedido";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@idpedido", id);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;
        }
        //obtener item
        public static Item_Pedido obtener_item(int idarticulo, int idpedido)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_item";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idarticulo", idarticulo);
            cmd.Parameters.AddWithValue("@idpedido", idpedido);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Item_Pedido item = new Item_Pedido();
           

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.Item_Ped_Id = (int)row[0];
                item.Item_Ped_Precio = (decimal)row[1];
                item.Item_Ped_Cantidad = (int)row[2];
                item.Item_Ped_Importe = (decimal)row[3];
                
            }


            return item;
        }

        public static void edit_item(Item_Pedido item)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_item";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@iditem", item.Item_Ped_Id);
            cmd.Parameters.AddWithValue("@precio", item.Item_Ped_Precio);
            cmd.Parameters.AddWithValue("@cantidad", item.Item_Ped_Cantidad);
            cmd.Parameters.AddWithValue("@importe", item.Item_Ped_Importe);
            cmd.Parameters.AddWithValue("@ped", item.Ped_Id);
            cmd.Parameters.AddWithValue("@art", item.Art_Id);
            
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Coleccion item pedido
        public static ObservableCollection<Item_Pedido> TraerItemsColeccion(int id)
        {
            DataTable dt = traer_items(id);

            ObservableCollection<Item_Pedido> listaItems = new ObservableCollection<Item_Pedido>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Item_Pedido item = new Item_Pedido();
                item.Item_Ped_Id= Convert.ToInt32(dt.Rows[i]["itemPed_id"]);
                item.Item_Ped_Cantidad = Convert.ToInt32(dt.Rows[i]["itemPed_cantidad"]);
                item.Item_Ped_Importe = Convert.ToDecimal(dt.Rows[i]["itemPed_importe"]);
                item.Item_Ped_Precio = Convert.ToDecimal(dt.Rows[i]["itemPed_precio"]);

                Pedido ped = new Pedido();
                ped.Ped_Id = Convert.ToInt32(dt.Rows[i]["ped_id"]);

                Articulo art = new Articulo();
                art.Art_Id = Convert.ToInt32(dt.Rows[i]["art_id"]);
                art.Art_Descrip = dt.Rows[i]["art_descripcion"].ToString();

                item.Pedido = ped;
                item.Articulo = art;

                listaItems.Add(item);
            }

            return listaItems;
        }
    }
}
