using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarUsuarios
    {
        public Usuario TraerUsuario()
        {
            Usuario oUsuario = new Usuario();
            oUsuario.Usr_ApellidoNombre= "";
            oUsuario.Usr_NombreUsuario = "";
            oUsuario.Usr_Password = "";
            return oUsuario;
        }

        //GUARDA USUARIO EN BD
        public static void add_usuario(Usuario usuario)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_usuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@rol", usuario.Rol_Id);
            cmd.Parameters.AddWithValue("@usuario", usuario.Usr_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", usuario.Usr_Password);
            cmd.Parameters.AddWithValue("@ap_nombre", usuario.Usr_ApellidoNombre);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //ELIMINAR USUARIO DE LA BD
        public static DataTable delete_usuario(int usuario_ID)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_usuario";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@usuario_id", usuario_ID);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }

        //TRAE TODOS LOS USUARIOS
        public static DataTable traer_usuarios()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_usuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }

        //CARGA ROLES EN COMBO BOX
        public static DataTable list_roles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_roles";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }

        //Creando la colección
        public ObservableCollection<Usuario> TraerUsuariosColeccion()
        {
            DataTable dt = traer_usuarios();

            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Usuario usu = new Usuario();
                usu.Usr_Id = Convert.ToInt32(dt.Rows[i]["usu_id"]);
                usu.Usr_ApellidoNombre = dt.Rows[i]["usu_apnombre"].ToString();
                usu.Usr_NombreUsuario = dt.Rows[i]["usu_usuario"].ToString();
                usu.Usr_Password = dt.Rows[i]["usu_password"].ToString();

                Rol rol = new Rol();
                rol.Rol_Id = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                usu.Rol = rol;

                listaUsuarios.Add(usu);
            }
            return listaUsuarios;
        }



        public static DataTable login(string usuario, string password)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            string query = "SELECT usu_usuario, usu_password, rol_id, usu_apnombre FROM Usuario WHERE usu_usuario = '" + usuario + "' AND usu_password = '" + password + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
