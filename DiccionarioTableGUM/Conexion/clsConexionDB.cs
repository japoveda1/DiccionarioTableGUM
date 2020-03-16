using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiccionarioTableGUM.Conexion
{
    class clsConexionDB
    {

        private SqlConnection prvSqlConnection;

        private SqlConnection connection;
        private string server;
        private string uid;
        private string password;
        private string SibiDatabaseName;

        public class conectionReturn
        {
            public SqlConnection Connection { get; set; }
            public bool connected { get; set; }
        }

        public class ParamsStoreProcedure
        {
            public string ParamName { get; set; }
            public object ParamValue { get; set; }
            public SqlDbType Type { get; set; }
        }

 

        private void Inicializar()
        {
            prvSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["UNOEE_CadeneConexion"].ConnectionString);
        }

        public bool AbrirConexion()
        {
            try
            {
                Inicializar();
                prvSqlConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool CerrarConexion()
        {
            try
            {
                connection.Close();
                connection.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public DataSet EjecutarCommand( string pvStrQuery)
        {

            SqlCommand vCommand = new SqlCommand();
            SqlDataAdapter vSqlDataAdapter = new SqlDataAdapter();
            DataSet vDataSet = new DataSet();
            
            vCommand.CommandText = pvStrQuery;
            vCommand.CommandTimeout = 600;
            vCommand.Connection = prvSqlConnection;

            vSqlDataAdapter.SelectCommand = vCommand;

            vSqlDataAdapter.Fill(vDataSet);

            return vDataSet;
        }



    }
}
