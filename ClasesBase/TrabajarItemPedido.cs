using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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

    }
}
