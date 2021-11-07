using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarHistorialLogin
    {
        //GUARDA LOG EN BD
        public static void add_log(Historial_Login hLogin)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "alta_log";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fechaHora", hLogin.Log_Fecha_Hora);
            cmd.Parameters.AddWithValue("@descripcion", hLogin.Log_Descrip);
            cmd.Parameters.AddWithValue("@usuario", hLogin.Usr_Id);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //MOFICIAR USUARIO EN BD
        public static void edit_log(int id_log, string descripcion_log)
        {

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificar_log";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idLog", id_log);
            cmd.Parameters.AddWithValue("@descripcion", descripcion_log);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //TRAE TODOS LOS LOGS
        public static DataTable traer_logs()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listar_logs";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);
            return dt;
        }

        public ObservableCollection<Historial_Login> TraerLogsColeccion()
        {
            DataTable dt = traer_logs();
            
            ObservableCollection<Historial_Login> listaLogs = new ObservableCollection<Historial_Login>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Historial_Login log = new Historial_Login();
                log.Log_Id = Convert.ToInt32(dt.Rows[i]["log_id"]);
                log.Log_Fecha_Hora = Convert.ToDateTime(dt.Rows[i]["log_fechaHora"]);
                log.Log_Descrip = dt.Rows[i]["log_descripcion"].ToString();
            
                Usuario usu = new Usuario();
                usu.Usr_Id = Convert.ToInt32(dt.Rows[i]["usu_id"]);
                usu.Usr_NombreUsuario = dt.Rows[i]["usu_usuario"].ToString();
                usu.Usr_ApellidoNombre = dt.Rows[i]["usu_apnombre"].ToString();
                usu.Usr_Password = dt.Rows[i]["usu_password"].ToString();
                
                Rol rol = new Rol();
                rol.Rol_Id = Convert.ToInt32(dt.Rows[i]["rol_id"]);
                rol.Rol_Descrip = dt.Rows[i]["rol_descripcion"].ToString();
                usu.Rol = rol;

                log.Usuario = usu;

                listaLogs.Add(log);
            }
            return listaLogs;
        }


        //Traer un solo log por ID
        public static Historial_Login obtener_log(int idLog)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "obtener_log";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@idLog", idLog);
            SqlDataAdapter ds = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ds.Fill(dt);

            Historial_Login log = new Historial_Login();
            Usuario usu = new Usuario();
            Rol rol = new Rol();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                log.Log_Id = (int)row[0];
                log.Log_Fecha_Hora = (DateTime)row[3];
                log.Log_Descrip = (string)row[4];
                usu.Usr_NombreUsuario = (string)row[1];
                usu.Usr_ApellidoNombre = (string)row[2];
                usu.Usr_Id = (int)row[5];
                usu.Usr_Password = (string)row[6];
                rol.Rol_Descrip = (string)row[7];
                rol.Rol_Id = (int)row[8];

                usu.Rol = rol;
                log.Usuario = usu;
            }

            return log;
        }

        //ELIMINAR LOG DE LA BD
        public static DataTable delete_log(int log_id)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.pasteleriaConnectionString);

            SqlDataAdapter dAdapter = new SqlDataAdapter(); //primero el dataadapter
            dAdapter.SelectCommand = new SqlCommand();      // despues se agrega el command
            dAdapter.SelectCommand.Connection = cnn;        // y despues se le establece la conexion

            dAdapter.SelectCommand.CommandText = "eliminar_log";
            dAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdapter.SelectCommand.Parameters.AddWithValue("@idLog", log_id);

            DataTable dTable = new DataTable();
            dAdapter.Fill(dTable);
            return dTable;

        }


    }
}
