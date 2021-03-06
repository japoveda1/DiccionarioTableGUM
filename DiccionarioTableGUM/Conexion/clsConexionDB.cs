﻿using System;
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

        public class ParametrosSP
        {
            public string ParamName { get; set; }
            public object ParamValue { get; set; }
            public SqlDbType? Type { get; set; }
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
                prvSqlConnection.Close();
                prvSqlConnection.Dispose();
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


        public DataSet EjecutarCommand( string stp_name, List<ParametrosSP> paramsStp)
        {
            DataSet vDataSet = new DataSet();

            //Create Command
            SqlCommand vCommand = new SqlCommand
            {
                CommandText = stp_name,
                CommandTimeout = 600,
                Connection = prvSqlConnection,
                CommandType = CommandType.StoredProcedure
            };

            foreach (var item in paramsStp)
                vCommand.Parameters.Add("@" + item.ParamName, item.Type).Value = item.ParamValue;

            //SqlDataReader dataReader = vCommand.ExecuteReader();

            using (SqlDataReader dataReader = vCommand.ExecuteReader())
            {
                //Create a new DataSet.
                DataSet dsCustomers = new DataSet();
                vDataSet.Tables.Add("Customers");

                //Load DataReader into the DataTable.
                vDataSet.Tables[0].Load(dataReader);
            }


            //var rows = new List<Dictionary<string, object>>();

            //while (dataReader.Read())
            //{
            //    var row = new Dictionary<string, object>();

            //    for (int i = 0; i < dataReader.FieldCount; i++)
            //    {
            //        try
            //        {
            //            row.Add(dataReader.GetName(i), dataReader[i]);
            //            vDataSet.Tables.Add(dataReader.GetName(i));
            //            vDataSet.Tables[0].Load(dataReader);

            //        }
            //        catch
            //        {
            //            string name = dataReader.GetName(i);

            //            //row.Add(name, "");
            //            vDataSet.Tables.Add(name);
            //            //vDataSet.Tables[0].Load(dataReader);
            //        }

            //    }


            //    //rows.Add(row);

            //    //row = null;
            //}

            //vDataSet.Tables.Add("table");

            //vDataSet.Tables[0].Load(dataReader);


            //dataReader.Close();
            //dataReader.Dispose();
            vCommand.Dispose();

           

            return vDataSet;
        }


    }
}
